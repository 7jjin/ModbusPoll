using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll.Interfaces
{
    public interface IContextMenuService
    {
        void ShowContextMenu(DataGridView dataView, MouseEventArgs e);
    }
}
