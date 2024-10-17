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
            this.dataView = new System.Windows.Forms.DataGridView();
            this.btnReadData = new System.Windows.Forms.Button();
            this.lbl_ReadTest = new System.Windows.Forms.Label();
            this.lbl_IpAddress = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.txt_IpAddress = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ReadAddress = new System.Windows.Forms.Label();
            this.txt_ReadAddress = new System.Windows.Forms.TextBox();
            this.lbl_ReadQuantity = new System.Windows.Forms.Label();
            this.txt_ReadQuantity = new System.Windows.Forms.TextBox();
            this.txt_WriteQuantity = new System.Windows.Forms.TextBox();
            this.lbl_WriteQuantity = new System.Windows.Forms.Label();
            this.txt_WriteAddress = new System.Windows.Forms.TextBox();
            this.lbl_WriteAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_WriteTest = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_ReadPlcAddress = new System.Windows.Forms.Label();
            this.lbl_WritePlcAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(38, 97);
            this.dataView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataView.Name = "dataView";
            this.dataView.RowHeadersVisible = false;
            this.dataView.RowHeadersWidth = 51;
            this.dataView.RowTemplate.Height = 27;
            this.dataView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.ShowCellToolTips = false;
            this.dataView.Size = new System.Drawing.Size(343, 365);
            this.dataView.TabIndex = 6;
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(904, 244);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(82, 28);
            this.btnReadData.TabIndex = 7;
            this.btnReadData.Text = "Read";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // lbl_ReadTest
            // 
            this.lbl_ReadTest.AutoSize = true;
            this.lbl_ReadTest.Location = new System.Drawing.Point(460, 96);
            this.lbl_ReadTest.Name = "lbl_ReadTest";
            this.lbl_ReadTest.Size = new System.Drawing.Size(74, 15);
            this.lbl_ReadTest.TabIndex = 8;
            this.lbl_ReadTest.Text = "Read Test";
            // 
            // lbl_IpAddress
            // 
            this.lbl_IpAddress.AutoSize = true;
            this.lbl_IpAddress.Location = new System.Drawing.Point(35, 30);
            this.lbl_IpAddress.Name = "lbl_IpAddress";
            this.lbl_IpAddress.Size = new System.Drawing.Size(76, 15);
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
            this.txt_IpAddress.Location = new System.Drawing.Point(118, 21);
            this.txt_IpAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_IpAddress.Name = "txt_IpAddress";
            this.txt_IpAddress.Size = new System.Drawing.Size(106, 25);
            this.txt_IpAddress.TabIndex = 2;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(353, 21);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(83, 25);
            this.txt_Port.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(487, 21);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 26);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(616, 21);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(112, 26);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnection";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(463, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 3);
            this.label1.TabIndex = 9;
            // 
            // lbl_ReadAddress
            // 
            this.lbl_ReadAddress.AutoSize = true;
            this.lbl_ReadAddress.Location = new System.Drawing.Point(474, 160);
            this.lbl_ReadAddress.Name = "lbl_ReadAddress";
            this.lbl_ReadAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_ReadAddress.TabIndex = 10;
            this.lbl_ReadAddress.Text = "Address";
            // 
            // txt_ReadAddress
            // 
            this.txt_ReadAddress.Location = new System.Drawing.Point(550, 157);
            this.txt_ReadAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadAddress.Name = "txt_ReadAddress";
            this.txt_ReadAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_ReadAddress.TabIndex = 11;
            // 
            // lbl_ReadQuantity
            // 
            this.lbl_ReadQuantity.AutoSize = true;
            this.lbl_ReadQuantity.Location = new System.Drawing.Point(474, 202);
            this.lbl_ReadQuantity.Name = "lbl_ReadQuantity";
            this.lbl_ReadQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_ReadQuantity.TabIndex = 12;
            this.lbl_ReadQuantity.Text = "Quantity";
            // 
            // txt_ReadQuantity
            // 
            this.txt_ReadQuantity.Location = new System.Drawing.Point(550, 199);
            this.txt_ReadQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadQuantity.Name = "txt_ReadQuantity";
            this.txt_ReadQuantity.Size = new System.Drawing.Size(436, 25);
            this.txt_ReadQuantity.TabIndex = 13;
            // 
            // txt_WriteQuantity
            // 
            this.txt_WriteQuantity.Location = new System.Drawing.Point(550, 382);
            this.txt_WriteQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteQuantity.Name = "txt_WriteQuantity";
            this.txt_WriteQuantity.Size = new System.Drawing.Size(436, 25);
            this.txt_WriteQuantity.TabIndex = 20;
            // 
            // lbl_WriteQuantity
            // 
            this.lbl_WriteQuantity.AutoSize = true;
            this.lbl_WriteQuantity.Location = new System.Drawing.Point(474, 385);
            this.lbl_WriteQuantity.Name = "lbl_WriteQuantity";
            this.lbl_WriteQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_WriteQuantity.TabIndex = 19;
            this.lbl_WriteQuantity.Text = "Quantity";
            // 
            // txt_WriteAddress
            // 
            this.txt_WriteAddress.Location = new System.Drawing.Point(550, 340);
            this.txt_WriteAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteAddress.Name = "txt_WriteAddress";
            this.txt_WriteAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_WriteAddress.TabIndex = 18;
            // 
            // lbl_WriteAddress
            // 
            this.lbl_WriteAddress.AutoSize = true;
            this.lbl_WriteAddress.Location = new System.Drawing.Point(474, 343);
            this.lbl_WriteAddress.Name = "lbl_WriteAddress";
            this.lbl_WriteAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_WriteAddress.TabIndex = 17;
            this.lbl_WriteAddress.Text = "Address";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(463, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(523, 3);
            this.label4.TabIndex = 16;
            // 
            // lbl_WriteTest
            // 
            this.lbl_WriteTest.AutoSize = true;
            this.lbl_WriteTest.Location = new System.Drawing.Point(460, 279);
            this.lbl_WriteTest.Name = "lbl_WriteTest";
            this.lbl_WriteTest.Size = new System.Drawing.Size(73, 15);
            this.lbl_WriteTest.TabIndex = 15;
            this.lbl_WriteTest.Text = "Write Test";
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(904, 427);
            this.btnWriteData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(82, 28);
            this.btnWriteData.TabIndex = 14;
            this.btnWriteData.Text = "Write";
            this.btnWriteData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "PLC address =";
            // 
            // lbl_ReadPlcAddress
            // 
            this.lbl_ReadPlcAddress.AutoSize = true;
            this.lbl_ReadPlcAddress.Location = new System.Drawing.Point(859, 160);
            this.lbl_ReadPlcAddress.Name = "lbl_ReadPlcAddress";
            this.lbl_ReadPlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_ReadPlcAddress.TabIndex = 22;
            this.lbl_ReadPlcAddress.Text = "40001";
            // 
            // lbl_WritePlcAddress
            // 
            this.lbl_WritePlcAddress.AutoSize = true;
            this.lbl_WritePlcAddress.Location = new System.Drawing.Point(859, 343);
            this.lbl_WritePlcAddress.Name = "lbl_WritePlcAddress";
            this.lbl_WritePlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_WritePlcAddress.TabIndex = 24;
            this.lbl_WritePlcAddress.Text = "40001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "PLC address =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1035, 785);
            this.Controls.Add(this.lbl_WritePlcAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_ReadPlcAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_WriteQuantity);
            this.Controls.Add(this.lbl_WriteQuantity);
            this.Controls.Add(this.txt_WriteAddress);
            this.Controls.Add(this.lbl_WriteAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_WriteTest);
            this.Controls.Add(this.btnWriteData);
            this.Controls.Add(this.txt_ReadQuantity);
            this.Controls.Add(this.lbl_ReadQuantity);
            this.Controls.Add(this.txt_ReadAddress);
            this.Controls.Add(this.lbl_ReadAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ReadTest);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IpAddress);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.lbl_IpAddress);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Label lbl_ReadTest;
        private System.Windows.Forms.Label lbl_IpAddress;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox txt_IpAddress;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ReadAddress;
        private System.Windows.Forms.TextBox txt_ReadAddress;
        private System.Windows.Forms.Label lbl_ReadQuantity;
        private System.Windows.Forms.TextBox txt_ReadQuantity;
        private System.Windows.Forms.TextBox txt_WriteQuantity;
        private System.Windows.Forms.Label lbl_WriteQuantity;
        private System.Windows.Forms.TextBox txt_WriteAddress;
        private System.Windows.Forms.Label lbl_WriteAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_WriteTest;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_ReadPlcAddress;
        private System.Windows.Forms.Label lbl_WritePlcAddress;
        private System.Windows.Forms.Label label5;
    }
}

