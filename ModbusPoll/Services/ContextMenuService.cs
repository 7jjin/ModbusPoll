using ModbusPoll.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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

            hexItem.Click += OnHexClick;
        }

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

        private void OnHexClick(object sender, EventArgs e)
        {
            // 선택된 셀의 값을 10진수에서 16진수로 변환
            var selectedCell = _dataView.SelectedCells[1];
            if (int.TryParse(selectedCell.Value.ToString(), out int decimalValue))
            {
                selectedCell.Value = $"0x{decimalValue:X4}"; // 16진수로 변환
            }
        }
    }
}
