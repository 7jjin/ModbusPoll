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
            dataView.CellValidating += DataView_CellValidating;
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

        /// <summary>
        /// 숫자와 백스페이스만 입력되도록하는 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void DataView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 첫 번째 열에 대해서만 유효성 검증 적용
            if (e.ColumnIndex == 1)
            {
                int value;

                // 입력된 값이 숫자인지 확인
                if (int.TryParse(e.FormattedValue.ToString(), out value))
                {
                    // 입력 값이 -32768 ~ 32767 범위 안에 있는지 확인
                    if (value < -32768 || value > 32767)
                    {
                        // 오류 메시지 표시
                        MessageBox.Show("입력값이 -32768에서 32767 사이여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true; // 값이 유효하지 않으면 수정 모드 유지
                    }
                }
            }
        }
    }
}
