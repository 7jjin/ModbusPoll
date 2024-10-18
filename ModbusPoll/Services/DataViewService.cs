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
        private readonly ContextMenuService _contextMenuService;
        private DataGridView _dataView;
        public DataViewService(ContextMenuService contextMenuService)
        {
            _contextMenuService = contextMenuService;
        }

        /// <summary>
        /// DataView 초기화
        /// </summary>
        /// <param name="dataView"></param>
        public void InitializeDataView(DataGridView dataView)
        {
            _dataView = dataView;
            dataView.Columns.Add("Column1", "No");    // "No" 헤더
            dataView.Columns.Add("Column2", "00000"); // "00000" 헤더

            // 11개의 행 추가 (0~9번 인덱스, 총 10개)
            for (int i = 0; i < 9; i++)
            {
                dataView.Rows.Add();
            }
            dataView.CellValidating += DataView_CellValidating;
            dataView.CellDoubleClick += dataGridView_CellDoubleClick;
        }

        /// <summary>
        /// 초기 데이터 설정
        /// </summary>
        /// <param name="dataView"></param>
        public void LoadData(DataGridView dataView)
        {
            // 2~11행에 첫 번째 열에 0~9 값을 입력
            for (int i = 0; i < 10; i++)
            {
                dataView.Rows[i].Cells[0].Value = i;  // 첫 번째 열에 0부터 9까지 입력
            }
        }

        /// <summary>
        /// Cell 더블 클릭 시 발생하는 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // 예를 들어, 두 번째 열이 데이터 입력 열이라고 가정
            {
                Form2 dataInputForm = new Form2(_contextMenuService.SelectedDataType);
                if (dataInputForm.ShowDialog() == DialogResult.OK)
                {
                    // 입력된 데이터를 DataGridView에 업데이트
                    _dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataInputForm.InputValue;
                }
            }
        }

        /// <summary>
        /// DataGrid에 숫자만 입력되도록 하는 함수
        /// </summary>
        /// <param name="dataView"></param>
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
                        if (_contextMenuService.SelectedDataType == "Signed" || _contextMenuService.SelectedDataType == "Unsigned")
                        {
                            textBox.KeyPress += TextBox_KeyPress_NumericOnly;
                        }
                        else if (_contextMenuService.SelectedDataType == "Hex")
                        {
                            textBox.KeyPress += TextBox_KeyPress_HexOnly;
                        }
                        else if (_contextMenuService.SelectedDataType == "Binary")
                        {
                            textBox.KeyPress += TextBox_KeyPress_BinaryOnly;
                        }
                    }
                }
            };
        }

        private void TextBox_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_KeyPress_HexOnly(object sender, KeyPressEventArgs e)
        {
            if (!Uri.IsHexDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_KeyPress_BinaryOnly(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 유효성 검사 확인 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DataView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int value;
                if (_contextMenuService.SelectedDataType == "Signed" && int.TryParse(e.FormattedValue.ToString(), out value))
                {
                    if (value < -32768 || value > 32767)
                    {
                        MessageBox.Show("Signed 값 범위를 벗어났습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (_contextMenuService.SelectedDataType == "Unsigned" && int.TryParse(e.FormattedValue.ToString(), out value))
                {
                    if (value <= 0 || value > 65535)
                    {
                        MessageBox.Show("Unsigned 값 범위를 벗어났습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (_contextMenuService.SelectedDataType == "Hex")
                {
                    string hexValue = e.FormattedValue.ToString();

                    // '0x'로 시작하는지 확인
                    if (!hexValue.StartsWith("0x"))
                    {
                        MessageBox.Show("Hex 형식이 잘못되었습니다. '0x'로 시작해야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    else
                    {
                        // 16진수를 숫자로 변환
                        if (int.TryParse(hexValue.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out value))
                        {
                            if (value < 0x0000 || value > 0xFFFF)  // 0x0000 ~ 0xFFFF 범위 확인
                            {
                                MessageBox.Show("Hex 값 범위를 벗어났습니다. 0x0000에서 0xFFFF 사이여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("유효하지 않은 Hex 값입니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
    }
}
