using ModbusPoll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPoll.Services
{
    public class DataViewService : IDataViewService
    {
        public void InitializeDataView(DataGridView dataView)
        {
            dataView.Columns.Add("Column1", "No");    // "No" 헤더
            dataView.Columns.Add("Column2", "00000"); // "00000" 헤더

            // 11개의 행 추가 (0~10번 인덱스, 총 11개)
            for (int i = 0; i < 9; i++)
            {
                dataView.Rows.Add();
            }
        }

        public void LoadData(DataGridView dataView)
        {
            // 2~11행에 첫 번째 열에 0~9 값을 입력
            for (int i = 0; i < 10; i++)
            {
                dataView.Rows[i].Cells[0].Value = i;  // 첫 번째 열에 0부터 9까지 입력
            }
        }

        public void AddKeyPressValidation(DataGridView dataView)
        {
            dataView.EditingControlShowing += (sender, e) =>
            {
                var grid = sender as DataGridView;

                if (grid.CurrentCell.ColumnIndex == 1)
                {
                    TextBox textBox = e.Control as TextBox;
                    if (textBox != null)
                    {
                        textBox.KeyPress -= TextBox_KeyPress_NumericOnly;
                        textBox.KeyPress += TextBox_KeyPress_NumericOnly;

                    }
                }
            };
        }

        private void TextBox_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
