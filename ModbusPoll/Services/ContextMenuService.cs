using ModbusPoll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll.Services
{
    public class ContextMenuService : IContextMenuService
    {
        private ContextMenuStrip _contextMenuStrip;

        public ContextMenuService()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _contextMenuStrip.Items.Add("Signed");
            _contextMenuStrip.Items.Add("Unsigned");
            _contextMenuStrip.Items.Add("Hex");
            _contextMenuStrip.Items.Add("ASCII");
            _contextMenuStrip.Items.Add("Binary");
            _contextMenuStrip.Items.Add("32-bit Signed");
            _contextMenuStrip.Items.Add("32-bit Unsigned");
            _contextMenuStrip.Items.Add("64-bit Signed");
            _contextMenuStrip.Items.Add("64-bit Unsigned");
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
                    _contextMenuStrip.Show(dataView,e.Location);
                }
            }
        }
    }
}
