using System.Text.RegularExpressions;
using System;
using System.Windows.Forms;

namespace ModbusPoll
{
    public partial class Form2 : Form
    {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;
        public string InputValue { get; private set; }
        public Form2(string dataType)
        {
            InitializeComponent();
            this.Text = $"{dataType} 입력";

            // 데이터 타입에 따라 폼 설정
            textBox = new TextBox { Dock = DockStyle.Fill };
            this.Controls.Add(textBox);
            okButton = new Button { Text = "확인", Dock = DockStyle.Bottom };
            cancelButton = new Button { Text = "취소", Dock = DockStyle.Bottom };

            okButton.Click += (s, e) =>
            {
                if (ValidateInput(dataType))
                {
                    InputValue = txt_Value.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }

        private bool ValidateInput(string dataType)
        {
            // 유효성 검사
            int value;
            switch (dataType)
            {
                case "Signed":
                    if (!int.TryParse(textBox.Text, out value) || value < -32768 || value > 32767)
                    {
                        MessageBox.Show("Signed 값은 -32768 ~ 32767 사이여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                case "Unsigned":
                    if (!int.TryParse(textBox.Text, out value) || value <= 0 || value > 65535)
                    {
                        MessageBox.Show("Unsigned 값은 0 ~ 65535 사이여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                case "Hex":
                    string hexValue = textBox.Text;

                    // '0x'로 시작하는지 확인하고, 16진수 값의 범위를 확인
                    if (!hexValue.StartsWith("0x"))
                    {
                        MessageBox.Show("Hex 형식은 '0x'로 시작해야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        // 16진수로 변환 및 범위 검사
                        if (int.TryParse(hexValue.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out value))
                        {
                            if (value < 0x0000 || value > 0xFFFF)
                            {
                                MessageBox.Show("Hex 값은 0x0000 ~ 0xFFFF 사이여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("유효하지 않은 Hex 값입니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    break;
                case "Binary":
                    // Binary 형식 검사 (0과 1만 허용) 및 길이 제한 (예: 16비트 이하)
                    string binaryValue = textBox.Text.Replace(" ", "");
                    if (!Regex.IsMatch(binaryValue, "^[01]+$"))
                    {
                        MessageBox.Show("Binary 형식은 0과 1로만 구성되어야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // 16비트 이하로 제한 (최대 16자리)
                    if (binaryValue.Length > 16)
                    {
                        MessageBox.Show("Binary 값은 최대 16비트여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                default:
                    MessageBox.Show("알 수 없는 데이터 타입입니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            return true;
        }
    }
}
