namespace ModbusPoll
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_IpAddress = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.txt_IpAddress = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_IpAddress
            // 
            this.lbl_IpAddress.AutoSize = true;
            this.lbl_IpAddress.Location = new System.Drawing.Point(35, 30);
            this.lbl_IpAddress.Name = "lbl_IpAddress";
            this.lbl_IpAddress.Size = new System.Drawing.Size(95, 19);
            this.lbl_IpAddress.TabIndex = 0;
            this.lbl_IpAddress.Text = "Ip Address";
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(302, 30);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(34, 15);
            this.lbl_Port.TabIndex = 1;
            this.lbl_Port.Text = "Port";
            // 
            // txt_IpAddress
            // 
            this.txt_IpAddress.Location = new System.Drawing.Point(121, 24);
            this.txt_IpAddress.Name = "txt_IpAddress";
            this.txt_IpAddress.Size = new System.Drawing.Size(133, 25);
            this.txt_IpAddress.TabIndex = 2;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(355, 27);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(104, 25);
            this.txt_Port.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(517, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 28);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(655, 24);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(109, 28);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnection";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IpAddress);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.lbl_IpAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_IpAddress;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox txt_IpAddress;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

