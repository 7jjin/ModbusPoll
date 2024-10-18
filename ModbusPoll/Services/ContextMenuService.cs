using ModbusPoll.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll.Services
{
    public class ContextMenuService : IContextMenuService
    {
        private ContextMenuStrip _contextMenuStrip;
        private DataGridView _dataView;
        private string _selectedDataType = "Signed"; // 기본값을 Signed로 설정
        public string SelectedDataType => _selectedDataType; // 선택된 데이터 타입 접근

        /// <summary>
        /// ContextMenu 메뉴 생성
        /// </summary>
        public ContextMenuService()
        {
            _contextMenuStrip = new ContextMenuStrip();
            // 각 항목 추가
            var signedItem = _contextMenuStrip.Items.Add("Signed");
            var unsignedItem = _contextMenuStrip.Items.Add("Unsigned");
            var hexItem = _contextMenuStrip.Items.Add("Hex");
            //var asciiItem = _contextMenuStrip.Items.Add("ASCII");
            var binaryItem = _contextMenuStrip.Items.Add("Binary");
            var signed32Item = _contextMenuStrip.Items.Add("32-bit Signed");
            var unsigned32Item = _contextMenuStrip.Items.Add("32-bit Unsigned");
            var signed64Item = _contextMenuStrip.Items.Add("64-bit Signed");
            var unsigned64Item = _contextMenuStrip.Items.Add("64-bit Unsigned");

            signedItem.Click += OnSignedClick;
            unsignedItem.Click += OnUnsignedClick;
            hexItem.Click += OnHexClick;
            //asciiItem.Click += OnAsciiClick;
            binaryItem.Click += OnBinaryClick;
        }

        /// <summary>
        /// 클릭시 위치에 ContextMenu 띄우는 함수
        /// </summary>
        /// <param name="dataView"></param>
        /// <param name="e"></param>
        public void ShowContextMenu(DataGridView dataView, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataView.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 1)
                {
                    dataView.ClearSelection();
                    dataView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected = true ;

                    _dataView = dataView;
                    _contextMenuStrip.Show(dataView,e.Location);
                }
            }
        }

        /// <summary>
        /// Signed 값으로 변환
        /// </summary>
        private void OnSignedClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            //string currentValue = selectedCell.Value.ToString();
            if (selectedCell.Value == null)
            {
                _selectedDataType = "Signed";
            }
            else
            {
                int signedValue = ConvertToSigned(selectedCell.Value.ToString());
                if(signedValue > 32767)
                {
                    selectedCell.Value = signedValue - 65536;
                }
                else
                {
                    selectedCell.Value = signedValue.ToString(); // 부호 있는 값으로 변환
                }
                _selectedDataType = "Signed";
            }
            
        }

        /// <summary>
        /// Unsigned 값으로 변환
        /// </summary>
        private void OnUnsignedClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            if (selectedCell.Value == null)
            {
                _selectedDataType = "Unsigned";
            }
            else
            {
                ushort unsignedValue = ConvertToUnsigned16(selectedCell.Value.ToString());
                selectedCell.Value = unsignedValue.ToString(); // 부호 없는 값으로 변환
                _selectedDataType = "Unsigned";

                // 변환 후 Signed 값으로 변환
                int signedValue = ConvertToSignedFromUnsigned(unsignedValue);
                // 이곳에서 signedValue를 필요한 위치에 표시
                // 예를 들어, DataGridView의 셀에 표시
                _dataView.SelectedCells[1].Value = unsignedValue.ToString();
            }
        }

        /// <summary>
        /// 10진수 -> 16진수 변환
        /// </summary>
        private void OnHexClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            if (selectedCell.Value == null)
            {
                _selectedDataType = "Hex";
            }
            else
            {
                int value = ConvertToSigned(selectedCell.Value.ToString()); // 먼저 10진수로 변환
                selectedCell.Value = $"0x{value:X4}"; // 16진수로 변환
                _selectedDataType = "Hex";
            }

            
        }

        /// <summary>
        /// 10진수 -> ASCII 변환
        /// </summary>
        //private void OnAsciiClick(object sender, EventArgs e)
        //{
        //    var selectedCell = _dataView.SelectedCells[1];
        //    string currentValue = selectedCell.Value.ToString();

        //    int asciiValue = ConvertToSigned(currentValue);
        //    selectedCell.Value = ((char)asciiValue).ToString(); // ASCII 문자로 변환
        //}

        /// <summary>
        /// 10진수 -> 2진수 변환
        /// </summary>
        private void OnBinaryClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            if (selectedCell.Value == null)
            {
                _selectedDataType = "Binary";
            }
            else
            {
                int binaryValue = ConvertToSigned(selectedCell.Value.ToString());
                selectedCell.Value = Convert.ToString(binaryValue, 2); // 2진수로 변환
                _selectedDataType = "Binary";
            }
        }

        /// <summary>
        /// 형식에 따라 10진수로 변환
        /// </summary>
        private int ConvertToSigned(string value)
        {
            // 16진수 처리
            if (value.StartsWith("0x"))
            {
                return int.Parse(value.Substring(2), NumberStyles.HexNumber);
            }
            // 이진수 처리
            else if (value.All(c => c == '0' || c == '1'))
            {
                return Convert.ToInt32(value, 2);
            }
            // ASCII 문자 처리
            else if (value.Length == 1 && char.IsLetterOrDigit(value[0]))
            {
                return (int)value[0];
            }
            // 기본적으로 10진수로 처리
            return int.Parse(value);
        }

        /// <summary>
        /// Signed 값으로 변경 함수(16bit)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="OverflowException"></exception>
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
        /// Unsigned 값으로 변경 함수(16bit)
        /// </summary>
        /// <param name="unsignedValue"></param>
        /// <returns></returns>
        private int ConvertToSignedFromUnsigned(ushort unsignedValue)
        {
            // Unsigned 값이 32768 이상이면 Signed로 변환 시 2의 보수를 적용
            if (unsignedValue >= 32768)
            {
                return unsignedValue - 65536;  // 65536(2^16)을 빼서 Signed 변환
            }
            return unsignedValue;  // 32767 이하인 경우 그대로 반환
        }
    }
}
