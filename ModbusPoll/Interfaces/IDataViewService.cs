using ModbusPoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll.Interfaces
{
    public interface IDataViewService
    {
        void InitializeDataView(DataGridView dataView);
        void LoadData(DataGridView dataGridView);
        void SetCellsToSigned(int count);
        void UpdateCellData(int rowIndex, int columnIndex, DataType selectedType);
    }
}
