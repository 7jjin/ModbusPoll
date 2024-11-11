using ModbusPoll.Interfaces;
using ModbusPoll.Models;
using ModbusPoll.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll
{
    public partial class Form1 : Form
    {
        private IModbusConnection _modbusConnection;
        private ModbusConnectionSettings _settings;
        private readonly IDataViewService _dataViewService;
        private readonly IContextMenuService _contextMenuService;
        private List<CellData> _cellDataList;
        private int minValue;
        private int maxValue;
        public string LogMessage { get; set; }
        public Boolean IsConnected { get; set; }

        public Form1(IModbusConnection modbusConnection, IDataViewService dataViewService, IContextMenuService contextMenuService)
        {
            InitializeComponent();
            _modbusConnection = modbusConnection;
            _dataViewService = dataViewService;
            _contextMenuService = contextMenuService;

            dataView.MouseDown += DataView_MouseDown;
            txt_ReadAddress.TextChanged += Txt_ReadAddress_TextChanged;
            txt_WriteAddress.TextChanged += Txt_WriteAddress_TextChanged;
            stlbl_statusCircle.Paint += StatusLabel_Paint;

            _cellDataList = new List<CellData>();
        }



        private void StatusLabel_Paint(object sender, PaintEventArgs e)
        {
            Color color = new Color();
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            if (IsConnected == true)
            {
                if (_modbusConnection.IsSocketConnected() == false)
                {
                    color = Color.Red;
                    tslbl_conectText.Text = "Disconnected";
                    tslbl_status.Text = "Slave와의 연결이 끊어졌습니다.";
                    tslbl_status.ForeColor = Color.Black;
                }
                else
                {
                    color = Color.Green;
                    tslbl_conectText.Text = "Connected";
                    tslbl_status.Text = LogMessage;
                }
            }
            else if(IsConnected == false)
            {
                color = Color.Red;
                tslbl_conectText.Text = "Disconnected";
                tslbl_status.Text = LogMessage != null ? LogMessage : "No connection";

            }
            
                
            using (SolidBrush brush = new SolidBrush(color))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // 부드럽게 원 그리기
                e.Graphics.FillEllipse(brush, 0, 0, stlbl_statusCircle.Width - 1, stlbl_statusCircle.Height - 1); // 원 그리기
            }
            
        }



        /// <summary>
        /// ReadAddress 텍스트 박스의 입력값이 바뀔 때마다 PLC Label값도 바뀜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_ReadAddress_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txt_ReadAddress.Text, out ushort inputValue))
            {
                // 40001을 더한 값 계산
                int result = inputValue + 40001;

                // 계산 결과를 Label에 표시
                lbl_ReadPlcAddress.Text = result.ToString();
            }
            else
            {
                // 변환이 실패하면 에러 메시지 표시
                MessageBox.Show("올바른 숫자를 입력하세요.");
            }
        }

        /// <summary>
        /// WriteAddress 텍스트 박스의 입력값이 바뀔 때마다 PLC Label값도 바뀜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_WriteAddress_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txt_WriteAddress.Text, out ushort inputValue))
            {
                // 40001을 더한 값 계산
                int result = inputValue + 40001;

                // 계산 결과를 Label에 표시
                lbl_WritePlcAddress.Text = result.ToString();
            }
            else
            {
                // 변환이 실패하면 에러 메시지 표시
                MessageBox.Show("올바른 숫자를 입력하세요.");
            }
        }

        /// <summary>
        /// Menu의 Connect를 클릭했을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuConnect_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm(_modbusConnection,this);
            connectionForm.ShowDialog();
        }

        /// <summary>
        /// Modbus 연결 해제 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDisconnect_Click(object sender, EventArgs e)
        {
            _modbusConnection.Disconnect();
            ResetSettingsToDefault();
            IsConnected = false;
            LogMessage = "No connection";
        }



        /// <summary>
        /// Data Table 구조 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView 초기화
            _dataViewService.InitializeDataView(dataView);
            // Data Load
            _dataViewService.LoadData(dataView);


            txt_ReadAddress.Text = "0";
            txt_ReadQuantity.Text = "10";  
            txt_WriteAddress.Text = "0";
            txt_WriteQuantity.Text = "10";
           
        }


        /// <summary>
        /// DataView 1열 클릭시 ContextMenu 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataView.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 1)
                {
                    int rowIndex = hitTestInfo.RowIndex;
                    int columnIndex = hitTestInfo.ColumnIndex;

                    _contextMenuService.ShowContextMenu(dataView, rowIndex, columnIndex);

                }
            }

        }

        /// <summary>
        /// 이진수를 4자리마다 공백으로 나누어 형식을 맞추는 함수
        /// 예: "0000000000001011" -> "0000 0000 0000 1011"
        /// </summary>
        private string FormatBinary(string binary)
        {
            StringBuilder formattedBinary = new StringBuilder();
            for (int i = 0; i < binary.Length; i++)
            {
                if (i > 0 && i % 4 == 0)
                {
                    formattedBinary.Append(" "); // 4자리마다 공백 추가
                }
                formattedBinary.Append(binary[i]);
            }
            return formattedBinary.ToString();
        }

        /// <summary>
        /// Slave 데이터 읽기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReadData_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            try
            {
                ushort startAddress;
                if (!ushort.TryParse(txt_ReadAddress.Text, out startAddress))
                {
                    MessageBox.Show("올바른 주소 값을 입력해주세요.");
                    LogMessage = "Write Correct Address";
                    return;
                }
                ushort quantity;
                if (!ushort.TryParse(txt_ReadQuantity.Text, out quantity))
                {
                    MessageBox.Show("올바른 수량 값을 입력해주세요.");
                    LogMessage = "Write Correct Quantity (0~10)";
                    return;
                }
                var data = await _modbusConnection.ReadHoldingRegistersAsync(startAddress, quantity);
                //dataView.Rows.Clear();
                //rtb_dataView.Clear();

                StringBuilder sb = new StringBuilder();
                if (data !=null)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        dataView.Rows[i].Cells[1].Value = 0;
                        // Signed 범위 값 처리
                        int signedValue = (short)data[i]; // 16-bit Signed 처리
                        string displayedValue;


                        if (signedValue < -32768 || signedValue > 32767)
                        {
                            // Signed 범위를 넘어설 경우 Unsigned로 변환
                            displayedValue = data[i].ToString(); // Unsigned 값 그대로 표시
                        }
                        else
                        {
                            // Signed 범위 내의 값일 경우 Signed 값 표시
                            displayedValue = signedValue.ToString();
                        }

                        // DataGridView 2열에 값 저장 
                        //dataView.Rows.Add(new object[] { i + startAddress, displayedValue });
                        dataView.Rows[i].Cells[1].Value = displayedValue;
                        dataView.AllowUserToAddRows = true;



                        // 32bit big-endian 값 저장
                        //string bigEndian = Convert.ToString(ConverToBigEndian(data[i], data[i+1]));

                        // RichTextView에 값 입력
                        string hexValue = $"0x{data[i]:X4}";
                        string binaryValue = Convert.ToString(data[i], 2).PadLeft(16, '0');
                        sb.AppendLine($"{currentTime}\t Address: {i + startAddress}\t Signed -> {signedValue}\t Unsigned -> {data[i]}\t Hex -> {hexValue}\t Binary -> {FormatBinary(binaryValue)}");
                    }
                    var firstCelData = dataView.Rows[0].Cells[1].Value.ToString();
                    var secondData = dataView.Rows[1].Cells[1].Value.ToString();
                    var thirdData = dataView.Rows[2].Cells[1].Value.ToString();
                    var fourthData = dataView.Rows[3].Cells[1].Value.ToString();

                    string signedBigEndian32Bit = Convert.ToString(ConverTo32BitBigEndian(firstCelData, secondData));
                    string signedLittleEndian32Bit = Convert.ToString(ConvertTo32BitLittleEndian(firstCelData, secondData));
                    string signedBigEndian32BitByteSwap = Convert.ToString(ConvertTo32BitBigEndianByteSwap(firstCelData, secondData));
                    string signedLittleEndian32BitByteSwap = Convert.ToString(ConvertTo32BitLittleEndianByteSwap(firstCelData, secondData));

                    string unSignedBigEndian32Bit = Convert.ToString(ConvertTo32BitUnsignedBigEndian(firstCelData, secondData));
                    string unSignedLittleEndian32Bit = Convert.ToString(ConvertTo32BitLittleEndianUnsigned(firstCelData, secondData));
                    string unSignedBigEndian32BitByteSwap = Convert.ToString(ConvertTo32BitBigEndianByteSwapUnsigned(firstCelData, secondData));
                    string unSignedLittleEndian32BitByteSwap = Convert.ToString(ConvertTo32BitLittleEndianByteSwapUnsigned(firstCelData, secondData));

                    string signedBigEndian64Bit = Convert.ToString(ConvertTo64BitBigEndian(firstCelData, secondData, thirdData, fourthData));
                    string signelLittleEndian64Bit = Convert.ToString(ConvertTo64BitLittleEndian(firstCelData, secondData, thirdData, fourthData));
                    string signedBigEndian64BitByteSwap = Convert.ToString(ConvertTo64BitBigEndianByteSwap(firstCelData, secondData, thirdData, fourthData));
                    string signedLittleEndian64BitByteSwap = Convert.ToString(ConvertTo64BitLittleEndianByteSwap(firstCelData, secondData, thirdData, fourthData));

                    string unSignedBigEndian64Bit = Convert.ToString(ConvertTo64BitUnsignedBigEndian(firstCelData, secondData, thirdData, fourthData));
                    string unSignelLittleEndian64Bit = Convert.ToString(ConvertTo64UnsignedBitLittleEndian(firstCelData, secondData, thirdData, fourthData));
                    string unSignedBigEndian64BitByteSwap = Convert.ToString(ConvertTo64BitUnsignedBigEndianByteSwap(firstCelData, secondData, thirdData, fourthData));
                    string unSignedLittleEndian64BitByteSwap = Convert.ToString(ConvertTo64BitUnsignedLittleEndianByteSwap(firstCelData, secondData, thirdData, fourthData));
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------");
                    if (quantity == 2)
                    {
                        sb.AppendLine($"{currentTime}\t 32bit Signed big-endian : {signedBigEndian32Bit}");
                        sb.AppendLine($"{currentTime}\t 32bit Signed little-endian : {signedLittleEndian32Bit}");
                        sb.AppendLine($"{currentTime}\t 32bit Signed big-endian Byte Swap : {signedBigEndian32BitByteSwap}");
                        sb.AppendLine($"{currentTime}\t 32bit Signed little-endian Byte Swap : {signedLittleEndian32BitByteSwap}");

                        sb.AppendLine("------------------------------------------------------------------------------------------------------------------------------------");

                        sb.AppendLine($"{currentTime}\t 32bit unSigned big-endian : {unSignedBigEndian32Bit}");
                        sb.AppendLine($"{currentTime}\t 32bit unSigned little-endian : {unSignedLittleEndian32Bit}");
                        sb.AppendLine($"{currentTime}\t 32bit unSigned big-endian Byte Swap : {unSignedBigEndian32BitByteSwap}");
                        sb.AppendLine($"{currentTime}\t 32bit unSigned little-endian Byte Swap : {unSignedLittleEndian32BitByteSwap}");
                    }
                    else if (quantity == 4)
                    {
                        sb.AppendLine($"{currentTime}\t 64bit Signed big-endian : {signedBigEndian64Bit}");
                        sb.AppendLine($"{currentTime}\t 64bit Signed little-endian : {signelLittleEndian64Bit}");
                        sb.AppendLine($"{currentTime}\t 64bit Signed big-endian Byte Swap : {signedBigEndian64BitByteSwap}");
                        sb.AppendLine($"{currentTime}\t 64bit Signed little-endian Byte Swap : {signedLittleEndian64BitByteSwap}");

                        sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------");

                        sb.AppendLine($"{currentTime}\t 64bit unSigned big-endian : {unSignedBigEndian64Bit}");
                        sb.AppendLine($"{currentTime}\t 64bit unSigned little-endian : {unSignelLittleEndian64Bit}");
                        sb.AppendLine($"{currentTime}\t 64bit unSigned big-endian Byte Swap : {unSignedBigEndian64BitByteSwap}");
                        sb.AppendLine($"{currentTime}\t 64bit unSigned little-endian Byte Swap : {unSignedLittleEndian64BitByteSwap}");
                    }
                    _dataViewService.SetCellsToSigned(data.Length - 1);
                    rtb_dataView.Text = sb.ToString();
                    LogMessage = $"{currentTime} Read {40001 + startAddress} ~ {40001 + startAddress + quantity} data ";
                    if (ushort.TryParse(txt_ReadAddress.Text, out ushort inputValue))
                    {
                        // 40001을 더한 값 계산
                        int result = inputValue + 40001;
                        dataView.Columns[1].HeaderText = $"{result}";
                    }
                    tslbl_status.ForeColor = Color.Black;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                if(tslbl_status.Text != "No connection")
                {
                    MessageBox.Show("Data 주소와 수량이 올바르지 않습니다.", "Illeagal Data Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    LogMessage = $"{currentTime} 02 illegal Data Address";
                    tslbl_status.ForeColor = Color.Red;
                }
                
               
            }
        }

        /// <summary>
        /// Slave로 데이터 쓰기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnWriteData_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            try
            {
                ushort startAddress;
                if (!ushort.TryParse(txt_WriteAddress.Text, out startAddress))
                {
                    MessageBox.Show("올바른 주소 값을 입력해주세요.");
                    LogMessage = "Write Correct Address";
                    return;
                }
                ushort quantity;
                if (!ushort.TryParse(txt_WriteQuantity.Text, out quantity))
                {
                    MessageBox.Show("올바른 수량 값을 입력해주세요.");
                    LogMessage = "Write Correct Quantity (0~10)";
                    return;
                }

                ushort[] valuesToWrite = new ushort[quantity];
                for (int i = 0; i < quantity; i++)
                {
                    string cellValue = dataView.Rows[i].Cells[1].Value?.ToString();
                    if (string.IsNullOrEmpty(cellValue))
                    {
                        MessageBox.Show("입력한 수량의 모든 셀에 데이터를 입력해주세요.");
                        return;
                    }

                    ushort unsignedValue;
                    if (cellValue.StartsWith("0x"))
                    {
                        unsignedValue = ushort.Parse(cellValue.Substring(2), NumberStyles.HexNumber);
                    }
                    else if (short.TryParse(cellValue, out short signedValue))
                    {
                        unsignedValue = (ushort)signedValue;
                    }
                    else if (cellValue.All(c => c == '0' || c == '1') && (cellValue.Length == 8 || cellValue.Length == 16))
                    {
                        unsignedValue = Convert.ToUInt16(cellValue.Substring(2), 2);
                    }
                    else if (!ushort.TryParse(cellValue, out unsignedValue))
                    {
                        MessageBox.Show("데이터 형식이 올바르지 않습니다.");
                        return;
                    }
                    valuesToWrite[i] = unsignedValue;
                }

                // Slave에 데이터 쓰기 (Function code 16번 사용)
                await _modbusConnection.WriteHoldingRegistersAsync(startAddress, valuesToWrite);
                LogMessage = $"{currentTime} Write {40001 + startAddress} ~ {40001 + startAddress + quantity} data ";
                if (ushort.TryParse(txt_WriteAddress.Text, out ushort inputValue))
                {
                    // 40001을 더한 값 계산
                    int result = inputValue + 40001;

                    dataView.Columns[1].HeaderText = $"{result}";
                }
                tslbl_status.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                if(tslbl_status.Text != "No connection")
                {
                    MessageBox.Show("Data 주소와 수량이 올바르지 않습니다.", "Illeagal Data Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    LogMessage = $"{currentTime} 02 illegal Data Address";
                    tslbl_status.ForeColor = Color.Red;
                }
            }
        }

        //---------------------------------------------------------- 32bit Signed -------------------------------------------------// 

        /// <summary>
        /// 32bit Signed big-endian
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private long ConverTo32BitBigEndian(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // Big-endian으로 변환
            uint bigEndianValue = ((uint)upperValue << 16) | lowerValue;

            // 32bit signed로 변환 (부호 있는 값을 처리)
            int result = unchecked((int)bigEndianValue);

            return result;
        }

        /// <summary>
        /// 32bit Signed Little-endian
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private long ConvertTo32BitLittleEndian(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환 (값 순서 반대로)
            uint littleEndianValue = ((uint)reversedLower << 16) | reversedUpper;

            // 32bit signed로 변환 (부호 있는 값을 처리)
            int result = unchecked((int)littleEndianValue);

            // 결과 출력
            return result;
        }

        /// <summary>
        /// 32bit Signed Big-endian Byte Swap
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private long ConvertTo32BitBigEndianByteSwap(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어오기
            ushort upperValue = ConvertToUnsigned16(firstCellData);  // 예: 1111 -> 0x0457
            ushort lowerValue = ConvertToUnsigned16(secondCellData); // 예: 2222 -> 0x08AE

            // Big-endian으로 결합: upperValue가 상위 비트로, lowerValue가 하위 비트로 결합
            uint bigEndianValue = ((uint)upperValue << 16) | lowerValue; // 0x0457 08AE

            // Byte Swap 수행: 각 바이트의 순서를 뒤집음
            uint swappedValue = ((bigEndianValue & 0xFF000000) >> 8) |  // 상위 8비트 -> 두 번째 상위 8비트로 이동
                        ((bigEndianValue & 0x00FF0000) << 8) |  // 두 번째 상위 8비트 -> 상위 8비트로 이동
                        ((bigEndianValue & 0x0000FF00) >> 8) |  // 세 번째 상위 8비트 -> 하위 8비트로 이동
                        ((bigEndianValue & 0x000000FF) << 8);    // 하위 8비트 -> 세 번째 상위 8비트로 이동


            int result = unchecked((int)swappedValue);
            return result;  // 결과 값 반환
        }

        /// <summary>
        /// 32bit Signed Little-endian Byte Swap
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private long ConvertTo32BitLittleEndianByteSwap(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환 (값 순서 반대로)
            uint littleEndianValue = ((uint)reversedLower << 16) | reversedUpper;

            uint swappedValue = ((littleEndianValue & 0xFF000000) >> 8) |  // 상위 8비트 -> 두 번째 상위 8비트로 이동
                         ((littleEndianValue & 0x00FF0000) << 8) |  // 두 번째 상위 8비트 -> 상위 8비트로 이동
                         ((littleEndianValue & 0x0000FF00) >> 8) |  // 세 번째 상위 8비트 -> 하위 8비트로 이동
                         ((littleEndianValue & 0x000000FF) << 8);    // 하위 8비트 -> 세 번째 상위 8비트로 이동

            int result = unchecked((int)swappedValue);
            return result;  // 결과 값 반환
        }

        //---------------------------------------------------------- 32bitUnsigned -------------------------------------------------// 

        /// <summary>
        /// 32bit Unsigned big-endian
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private ulong ConvertTo32BitUnsignedBigEndian(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // Big-endian으로 변환
            ulong bigEndianValue = ((ulong)upperValue << 16) | lowerValue;

            // Unsigned의 경우, 별도의 부호 처리 없이 그대로 반환
            return bigEndianValue;
        }

        /// <summary>
        /// 32bit Unsigned little-endian
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private ulong ConvertTo32BitLittleEndianUnsigned(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환 (값 순서 반대로)
            ulong littleEndianValue = ((ulong)reversedLower << 16) | reversedUpper;

            // Unsigned의 경우, 별도의 부호 처리 없이 그대로 반환
            return littleEndianValue;
        }

        /// <summary>
        /// 32bit Unsigned big-endian Byte swap
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private ulong ConvertTo32BitBigEndianByteSwapUnsigned(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어오기
            ushort upperValue = ConvertToUnsigned16(firstCellData);  // 예: 1111 -> 0x0457
            ushort lowerValue = ConvertToUnsigned16(secondCellData); // 예: 2222 -> 0x08AE

            // Big-endian으로 결합: upperValue가 상위 비트로, lowerValue가 하위 비트로 결합
            uint bigEndianValue = ((uint)upperValue << 16) | lowerValue; // 0x0457 08AE

            // Byte Swap 수행: 각 바이트의 순서를 뒤집음
            uint swappedValue = ((bigEndianValue & 0xFF000000) >> 8) |  // 상위 8비트 -> 두 번째 상위 8비트로 이동
                                ((bigEndianValue & 0x00FF0000) << 8) |  // 두 번째 상위 8비트 -> 상위 8비트로 이동
                                ((bigEndianValue & 0x0000FF00) >> 8) |  // 세 번째 상위 8비트 -> 하위 8비트로 이동
                                ((bigEndianValue & 0x000000FF) << 8);    // 하위 8비트 -> 세 번째 상위 8비트로 이동

            // Unsigned 값으로 반환
            return (ulong)swappedValue;  // 결과 값 반환
        }

        /// <summary>
        /// 32bit Unsigned little-endian Byte swap
        /// </summary>
        /// <param name="firstCellData"></param>
        /// <param name="secondCellData"></param>
        /// <returns></returns>
        private ulong ConvertTo32BitLittleEndianByteSwapUnsigned(string firstCellData, string secondCellData)
        {
            // 두 셀의 값을 16-bit로 읽어와 결합
            ushort upperValue = ConvertToUnsigned16(firstCellData);
            ushort lowerValue = ConvertToUnsigned16(secondCellData);

            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환 (값 순서 반대로)
            uint littleEndianValue = ((uint)reversedLower << 16) | reversedUpper;

            // Byte Swap 수행: 각 바이트의 순서를 뒤집음
            uint swappedValue = ((littleEndianValue & 0xFF000000) >> 8) |  // 상위 8비트 -> 두 번째 상위 8비트로 이동
                                ((littleEndianValue & 0x00FF0000) << 8) |  // 두 번째 상위 8비트 -> 상위 8비트로 이동
                                ((littleEndianValue & 0x0000FF00) >> 8) |  // 세 번째 상위 8비트 -> 하위 8비트로 이동
                                ((littleEndianValue & 0x000000FF) << 8);    // 하위 8비트 -> 세 번째 상위 8비트로 이동

            // Unsigned 값으로 반환
            return (ulong)swappedValue;  // 결과 값 반환
        }

        //---------------------------------------------------------64bit Singed------------------------------------------------------//


        /// <summary>
        /// 64bit Signed big-endian
        /// </summary>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <returns></returns>
        private long ConvertTo64BitBigEndian(string cell0, string cell1, string cell2, string cell3)
        {
            uint upperValue = ConvertTo32BitBigEndian(cell0, cell1, cell2, cell3);
            uint lowerValue = ConvertTo32BitBigEndian(cell2, cell3, cell0, cell1);

            ulong bigEndianValue = ((ulong)upperValue << 32) | lowerValue;

            // Signed 처리
            if ((bigEndianValue & 0x8000000000000000) != 0)
            {
                return unchecked((long)bigEndianValue);
            }

            return (long)bigEndianValue;
        }

        /// <summary>
        /// 64bit Signed little-endian
        /// </summary>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <returns></returns>
        private long ConvertTo64BitLittleEndian(string cell2, string cell3, string cell0, string cell1)
        {
            uint upperValue = ConvertTo32BitLittleEndian(cell2, cell3, cell0, cell1);
            uint lowerValue = ConvertTo32BitLittleEndian(cell0, cell1, cell2, cell3);

            ulong littleEndianValue = ((ulong)lowerValue << 32) | upperValue;

            // Signed 처리
            if ((littleEndianValue & 0x8000000000000000) != 0)
            {
                return unchecked((long)littleEndianValue);
            }

            return (long)littleEndianValue;
        }

        /// <summary>
        /// 64bit Signed Big-endian Byte Swap
        /// </summary>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <returns></returns>
        private long ConvertTo64BitBigEndianByteSwap(string cell0, string cell1, string cell2, string cell3)
        {
            uint upperValue = ConvertTo32BitBigEndian(cell0, cell1, cell2, cell3);
            uint lowerValue = ConvertTo32BitBigEndian(cell2, cell3, cell0, cell1);

            ulong bigEndianValue = ((ulong)upperValue << 32) | lowerValue;

            // Byte Swap
            ulong swappedValue = ((bigEndianValue & 0xFF00000000000000) >> 8) |
                                 ((bigEndianValue & 0x00FF000000000000) << 8) |
                                 ((bigEndianValue & 0x0000FF0000000000) >> 8) |
                                 ((bigEndianValue & 0x000000FF00000000) << 8) |
                                 ((bigEndianValue & 0x00000000FF000000) >> 8) |
                                 ((bigEndianValue & 0x0000000000FF0000) << 8) |
                                 ((bigEndianValue & 0x000000000000FF00) >> 8) |
                                 ((bigEndianValue & 0x00000000000000FF) << 8);

            // Signed 처리
            if ((swappedValue & 0x8000000000000000) != 0)
            {
                return unchecked((long)swappedValue);
            }

            return (long)swappedValue;
        }

        /// <summary>
        /// 64bit Signed Little-endian Byte Swap
        /// </summary>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <returns></returns>
        private long ConvertTo64BitLittleEndianByteSwap(string cell2, string cell3, string cell0, string cell1)
        {
            uint upperValue = ConvertTo32BitLittleEndian(cell2, cell3, cell0, cell1);
            uint lowerValue = ConvertTo32BitLittleEndian(cell0, cell1, cell2, cell3);

            ulong littleEndianValue = ((ulong)lowerValue << 32) | upperValue;

            // Byte Swap
            ulong swappedValue = ((littleEndianValue & 0xFF00000000000000) >> 8) |
                                 ((littleEndianValue & 0x00FF000000000000) << 8) |
                                 ((littleEndianValue & 0x0000FF0000000000) >> 8) |
                                 ((littleEndianValue & 0x000000FF00000000) << 8) |
                                 ((littleEndianValue & 0x00000000FF000000) >> 8) |
                                 ((littleEndianValue & 0x0000000000FF0000) << 8) |
                                 ((littleEndianValue & 0x000000000000FF00) >> 8) |
                                 ((littleEndianValue & 0x00000000000000FF) << 8);

            // Signed 처리
            if ((swappedValue & 0x8000000000000000) != 0)
            {
                return unchecked((long)swappedValue);
            }

            return (long)swappedValue;
        }

        //--------------------------------------------------------64bit Unsigned-----------------------------------------------------//
        /// <summary>
        /// 64bit Unsigned big-endian
        /// </summary>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <returns></returns>
        private ulong ConvertTo64BitUnsignedBigEndian(string cell0, string cell1, string cell2, string cell3)
        {
            uint upperValue = ConvertTo32BitBigEndianUnsigned(cell0, cell1, cell2, cell3);
            uint lowerValue = ConvertTo32BitBigEndianUnsigned(cell2, cell3, cell0, cell1);

            // Big-endian 64비트 값 생성
            return ((ulong)upperValue << 32) | lowerValue;
        }

        /// <summary>
        /// 64bit Unsigned little-endian
        /// </summary>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <returns></returns>
        private ulong ConvertTo64UnsignedBitLittleEndian(string cell2, string cell3, string cell0, string cell1)
        {
            uint upperValue = ConvertTo32BitLittleEndianUnsigned(cell2, cell3, cell0, cell1);
            uint lowerValue = ConvertTo32BitLittleEndianUnsigned(cell0, cell1, cell2, cell3);

            // Little-endian 64비트 값 생성
            return ((ulong)lowerValue << 32) | upperValue;
        }

        /// <summary>
        /// 64bit Unsigned Big-endian Byte Swap
        /// </summary>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <returns></returns>
        private ulong ConvertTo64BitUnsignedBigEndianByteSwap(string cell0, string cell1, string cell2, string cell3)
        {
            uint upperValue = ConvertTo32BitBigEndian(cell0, cell1, cell2, cell3);
            uint lowerValue = ConvertTo32BitBigEndian(cell2, cell3, cell0, cell1);

            ulong bigEndianValue = ((ulong)upperValue << 32) | lowerValue;

            // Byte Swap
            ulong swappedValue = ((bigEndianValue & 0xFF00000000000000) >> 8) |
                                 ((bigEndianValue & 0x00FF000000000000) << 8) |
                                 ((bigEndianValue & 0x0000FF0000000000) >> 8) |
                                 ((bigEndianValue & 0x000000FF00000000) << 8) |
                                 ((bigEndianValue & 0x00000000FF000000) >> 8) |
                                 ((bigEndianValue & 0x0000000000FF0000) << 8) |
                                 ((bigEndianValue & 0x000000000000FF00) >> 8) |
                                 ((bigEndianValue & 0x00000000000000FF) << 8);

            return swappedValue;
        }

        /// <summary>
        /// 64bit Unsigned Little-endian Byte Swap
        /// </summary>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <returns></returns>
        private ulong ConvertTo64BitUnsignedLittleEndianByteSwap(string cell2, string cell3, string cell0, string cell1)
        {
            uint upperValue = ConvertTo32BitLittleEndian(cell2, cell3, cell0, cell1);
            uint lowerValue = ConvertTo32BitLittleEndian(cell0, cell1, cell2, cell3);

            ulong littleEndianValue = ((ulong)lowerValue << 32) | upperValue;

            // Byte Swap
            ulong swappedValue = ((littleEndianValue & 0xFF00000000000000) >> 8) |
                                 ((littleEndianValue & 0x00FF000000000000) << 8) |
                                 ((littleEndianValue & 0x0000FF0000000000) >> 8) |
                                 ((littleEndianValue & 0x000000FF00000000) << 8) |
                                 ((littleEndianValue & 0x00000000FF000000) >> 8) |
                                 ((littleEndianValue & 0x0000000000FF0000) << 8) |
                                 ((littleEndianValue & 0x000000000000FF00) >> 8) |
                                 ((littleEndianValue & 0x00000000000000FF) << 8);

            return swappedValue;
        }


        //-------------------------------------------------------32bit 정의 시 필요 함수--------------------------------------------//
        private ushort ConvertToUnsigned16(string value)
        {
            int signedValue = ConvertToSigned(value);

            // 부호 있는 값을 16-bit unsigned로 변환
            if (signedValue < 0)
            {
                return (ushort)(signedValue + (1 << 16)); // 16-bit 2's complement 변환
            }

            // 16-bit 범위를 벗어나는 경우 처리
            if (signedValue > ushort.MaxValue)
            {
                throw new OverflowException("값이 16-bit 범위를 초과했습니다.");
            }
            return (ushort)signedValue;
        }
        /// <summary>
        /// Signed 값으로 바꾸는 함수(16bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int ConvertToSigned(string value)
        {
            // 기본적으로 10진수로 처리
            return int.Parse(value);
        }



        //-------------------------------------------------------64bit 정의 시 필요 함수--------------------------------------------//
        /// <summary>
        /// 64bit big-endian, little-endian 정의 할 때 필요한 함수
        /// </summary>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <returns></returns>
        private uint ConvertTo32BitBigEndian(string cell0, string cell1, string cell2, string cell3)
        {
            ushort upperValue = ConvertToUnsigned16(cell0); // 상위 16비트
            ushort lowerValue = ConvertToUnsigned16(cell1); // 하위 16비트

            // Big-endian으로 변환
            return ((uint)upperValue << 16) | lowerValue;
        }

        /// <summary>
        /// 64bit big-endian, little-endian 정의 할 때 필요한 함수
        /// </summary>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        /// <param name="cell0"></param>
        /// <param name="cell1"></param>
        /// <returns></returns>
        private uint ConvertTo32BitLittleEndian(string cell2, string cell3, string cell0, string cell1)
        {
            ushort upperValue = ConvertToUnsigned16(cell2); // 상위 16비트
            ushort lowerValue = ConvertToUnsigned16(cell3); // 하위 16비트

            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환
            return ((uint)reversedLower << 16) | reversedUpper;
        }
        private uint ConvertTo32BitBigEndianUnsigned(string cell0, string cell1, string cell2, string cell3)
        {
            ushort upperValue = ConvertToUnsigned16(cell0); // 상위 16비트
            ushort lowerValue = ConvertToUnsigned16(cell1); // 하위 16비트

            // Big-endian으로 변환
            return ((uint)upperValue << 16) | lowerValue;
        }

        private uint ConvertTo32BitLittleEndianUnsigned(string cell2, string cell3, string cell0, string cell1)
        {
            ushort upperValue = ConvertToUnsigned16(cell2); // 상위 16비트
            ushort lowerValue = ConvertToUnsigned16(cell3); // 하위 16비트
                                                            // 각 16-bit 값을 little-endian 방식으로 바이트 순서를 바꿈
            ushort reversedUpper = (ushort)((upperValue >> 8) | (upperValue << 8));
            ushort reversedLower = (ushort)((lowerValue >> 8) | (lowerValue << 8));

            // Little-endian으로 변환
            return ((uint)reversedLower << 16) | reversedUpper;

        }

       

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslbl_timer.Text = DateTime.Now.ToString("yyyy-MM-dd HH시 mm분 ss초 ");
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            ResetSettingsToDefault();
            this.Close();
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            using (var rangeForm = new ScaleSettingForm())
            {
                if (rangeForm.ShowDialog() == DialogResult.OK && rangeForm.IsRangeEnabled)
                {
                    minValue = rangeForm.MinValue ?? 0;
                    maxValue = rangeForm.MaxValue ?? 0;
                    // 받은 minValue와 maxValue 값을 활용하는 로직 추가
                }
            }
        }

        private void ScaleSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetSettingsToDefault();
        }

        private void ResetSettingsToDefault()
        {
            Properties.Settings.Default.ipAddress = "127.0.0.1";
            Properties.Settings.Default.port = "502";
            Properties.Settings.Default.slaveId = "1";
            Properties.Settings.Default.startScale = 0;  // 원하는 기본값으로 설정
            Properties.Settings.Default.endScale = 0;    // 원하는 기본값으로 설정
            Properties.Settings.Default.IsRangeEnabled = false;  // 기본값

            Properties.Settings.Default.Save();
        } 
    }
}
