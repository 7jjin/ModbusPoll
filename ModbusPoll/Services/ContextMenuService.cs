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
            var asciiItem = _contextMenuStrip.Items.Add("ASCII");
            var binaryItem = _contextMenuStrip.Items.Add("Binary");
            var signed32Item = _contextMenuStrip.Items.Add("32-bit Signed");
            var unsigned32Item = _contextMenuStrip.Items.Add("32-bit Unsigned");
            var signed64Item = _contextMenuStrip.Items.Add("64-bit Signed");
            var unsigned64Item = _contextMenuStrip.Items.Add("64-bit Unsigned");

            signedItem.Click += OnSignedClick;
            unsignedItem.Click += OnUnsignedClick;
            hexItem.Click += OnHexClick;
            asciiItem.Click += OnAsciiClick;
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
            string currentValue = selectedCell.Value.ToString();

            int signedValue = ConvertToSigned(currentValue);
            selectedCell.Value = signedValue.ToString(); // 부호 있는 값으로 변환
        }

        /// <summary>
        /// Unsigned 값으로 변환
        /// </summary>
        private void OnUnsignedClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            string currentValue = selectedCell.Value.ToString();

            uint unsignedValue = ConvertToUnsigned(currentValue);
            selectedCell.Value = unsignedValue.ToString(); // 부호 없는 값으로 변환
        }

        /// <summary>
        /// 10진수 -> 16진수 변환
        /// </summary>
        private void OnHexClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            string currentValue = selectedCell.Value.ToString();

            int value = ConvertToSigned(currentValue); // 먼저 10진수로 변환
            selectedCell.Value = $"0x{value:X4}"; // 16진수로 변환
        }

        /// <summary>
        /// 10진수 -> ASCII 변환
        /// </summary>
        private void OnAsciiClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            string currentValue = selectedCell.Value.ToString();

            int asciiValue = ConvertToSigned(currentValue);
            selectedCell.Value = ((char)asciiValue).ToString(); // ASCII 문자로 변환
        }

        /// <summary>
        /// 10진수 -> 2진수 변환
        /// </summary>
        private void OnBinaryClick(object sender, EventArgs e)
        {
            var selectedCell = _dataView.SelectedCells[1];
            string currentValue = selectedCell.Value.ToString();

            int binaryValue = ConvertToSigned(currentValue);
            selectedCell.Value = Convert.ToString(binaryValue, 2); // 2진수로 변환
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
        /// 형식에 따라 부호 없는 값으로 변환
        /// </summary>
        private uint ConvertToUnsigned(string value)
        {
            // 부호 있는 값을 unsigned로 변환
            return (uint)ConvertToSigned(value);
        }
    }
}
