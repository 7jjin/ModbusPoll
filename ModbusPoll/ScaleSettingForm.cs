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

        private void btnscaleSetting_Click(object sender, EventArgs e)
        {
            if (IsRangeEnabled)
            {
                if (int.TryParse(txt_startScale.Text, out int min) && int.TryParse(txt_endScale.Text, out int max))
                {
                    if (max <= min)
                    {
                        MessageBox.Show("종료 값은 시작 값보다 커야 합니다.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_endScale.Text = "";
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
                MessageBox.Show("Dont't use가 선택되었습니다.");
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
