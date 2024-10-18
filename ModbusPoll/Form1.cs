using ModbusPoll.Interfaces;
using ModbusPoll.Models;
using ModbusPoll.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Form1(IModbusConnection modbusConnection, IDataViewService dataViewService, IContextMenuService contextMenuService)
        {
            InitializeComponent();
            _modbusConnection = modbusConnection;
            _dataViewService = dataViewService;
            _contextMenuService = contextMenuService;

            dataView.MouseDown += DataView_MouseDown;
            txt_ReadAddress.TextChanged += Txt_ReadAddress_TextChanged;
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
        /// Modbus Tcp 연결
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txt_IpAddress.Text;
            int port = int.Parse(txt_Port.Text);
            _settings = new ModbusConnectionSettings(ipAddress, port);
            try
                {
                _modbusConnection.Connect(_settings.IpAddress, _settings.Port);
                MessageBox.Show("Connected to Modbus Slave");
            }catch(Exception ex) {
                MessageBox.Show($"Connection failed : {ex.Message}");
            }
        }


        /// <summary>
        /// Modbus Tcp 연결 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _modbusConnection.Disconnect();
            MessageBox.Show("Disconnected from Modbus Slave");
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

            // 첫 번째 열에 대한 유효성 검사 추가
            _dataViewService.AddKeyPressValidation(dataView);

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
            _contextMenuService.ShowContextMenu(dataView, e);
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
            try
            {
                ushort startAddress;
                if (!ushort.TryParse(txt_ReadAddress.Text, out startAddress))
                {
                    MessageBox.Show("올바른 주소 값을 입력해주세요.");
                    return;
                }
                ushort quantity;
                if (!ushort.TryParse(txt_ReadQuantity.Text, out quantity))
                {
                    MessageBox.Show("올바른 수량 값을 입력해주세요.");
                    return;
                }
                var data = await _modbusConnection.ReadHoldingRegistersAsync(startAddress, quantity);
                dataView.Rows.Clear();
                rtb_dataView.Clear();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
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
                    dataView.Rows.Add(new object[] { i + startAddress, displayedValue });
                    dataView.AllowUserToAddRows = false;

                    // RichTextView에 값 입력
                    string hexValue = $"0x{data[i]:X4}";
                    string binaryValue = Convert.ToString(data[i], 2).PadLeft(16, '0');
                    sb.AppendLine($"Address: {i + startAddress}\tSigned -> {signedValue}\tUnsigned -> {data[i]}\tHex -> {hexValue}\tBinary -> {FormatBinary(binaryValue)}");
                }
                rtb_dataView.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("02 Illegal Data Address");
            }
        }

    }
}
