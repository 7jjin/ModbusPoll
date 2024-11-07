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
    public partial class ScaleSettingForm : Form
    {
        public int? MinValue { get; private set; }
        public int? MaxValue { get; private set; }
        public bool IsRangeEnabled => ckb_isScale.Checked;
        public ScaleSettingForm()
        {
            InitializeComponent();
            txt_startScale.KeyPress += textBox_KeyPress;
            txt_endScale.KeyPress += textBox_KeyPress;

            txt_startScale.TextChanged += textBox_TextChanged;
            txt_endScale.TextChanged += textBox_TextChanged;
        }

        private void ScaleSettingForm_Load(object sender, EventArgs e)
        {
            txt_startScale.Text = Properties.Settings.Default.startScale.ToString();
            txt_endScale.Text = Properties.Settings.Default.endScale.ToString();
            ckb_isScale.Checked = Properties.Settings.Default.IsRangeEnabled;

            SetTextBoxState(IsRangeEnabled); // 초기 상태에서 커서 제거
        }

        /// <summary>
        /// 숫자만 입력가능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // TextChanged 이벤트로 콤마를 추가하는 메서드
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;


            // 기존 콤마를 제거한 후 숫자만 남겨 포맷
            string value = textBox.Text.Replace(",", "");

            if (decimal.TryParse(value, out _))
            {
                // 천 단위 콤마 추가
                textBox.Text = string.Format("{0:N0}", decimal.Parse(value));

                // 기존 커서 위치를 유지하도록 설정
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void btnscaleSetting_Click(object sender, EventArgs e)
        {
            if (IsRangeEnabled)
            {
                // 텍스트에서 콤마를 제거한 후 숫자로 변환
                string startScaleText = txt_startScale.Text.Replace(",", "");
                string endScaleText = txt_endScale.Text.Replace(",", "");

                if (int.TryParse(startScaleText, out int min) && int.TryParse(endScaleText, out int max))
                {
                    if (max <= min)
                    {
                        MessageBox.Show("종료 값은 시작 값보다 커야 합니다.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_endScale.Text = ""; // 오류 발생 시 종료값 초기화
                    }
                    else
                    {
                        // 설정 저장
                        Properties.Settings.Default.startScale = min;
                        Properties.Settings.Default.endScale = max;
                        Properties.Settings.Default.IsRangeEnabled = IsRangeEnabled;
                        Properties.Settings.Default.Save(); // 설정 저장

                        MinValue = min;
                        MaxValue = max;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("유효한 숫자를 입력해주세요.");
                }
            }
            else
            {
                MessageBox.Show("Use scale이 선택이 안되었습니다.");
            }
        }


        private void ckb_isScale_CheckedChanged(object sender, EventArgs e)
        {
            SetTextBoxState(IsRangeEnabled); // 체크 상태에 따라 커서 활성화 여부 결정
        }

        private void SetTextBoxState(bool isEnabled)
        {
            txt_startScale.Enabled = isEnabled;
            txt_endScale.Enabled = isEnabled;

            // Enabled 상태에 따라 배경색 설정
            txt_startScale.BackColor = isEnabled ? Color.White : Color.LightGray;
            txt_endScale.BackColor = isEnabled ? Color.White : Color.LightGray;
        }
    }
}
