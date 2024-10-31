﻿namespace ModbusPoll
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_SlaveId = new System.Windows.Forms.Label();
            this.txt_SlaveId = new System.Windows.Forms.TextBox();
            this.lbl_FunctionCode = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lbl_IpAddress = new System.Windows.Forms.Label();
            this.txt_IpAddress = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Modbus TCP/IP"});
            this.comboBox1.Location = new System.Drawing.Point(18, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Modbus TCP/IP";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(348, 23);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "OK";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(348, 57);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.lbl_FunctionCode);
            this.groupBox2.Controls.Add(this.txt_SlaveId);
            this.groupBox2.Controls.Add(this.lbl_SlaveId);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 135);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slave Definition";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_Port);
            this.groupBox3.Controls.Add(this.lbl_Port);
            this.groupBox3.Controls.Add(this.txt_IpAddress);
            this.groupBox3.Controls.Add(this.lbl_IpAddress);
            this.groupBox3.Location = new System.Drawing.Point(12, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 107);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TCP/IP Server";
            // 
            // lbl_SlaveId
            // 
            this.lbl_SlaveId.AutoSize = true;
            this.lbl_SlaveId.Location = new System.Drawing.Point(26, 43);
            this.lbl_SlaveId.Name = "lbl_SlaveId";
            this.lbl_SlaveId.Size = new System.Drawing.Size(62, 15);
            this.lbl_SlaveId.TabIndex = 0;
            this.lbl_SlaveId.Text = "Slave ID";
            // 
            // txt_SlaveId
            // 
            this.txt_SlaveId.Location = new System.Drawing.Point(110, 37);
            this.txt_SlaveId.Name = "txt_SlaveId";
            this.txt_SlaveId.Size = new System.Drawing.Size(96, 25);
            this.txt_SlaveId.TabIndex = 1;
            // 
            // lbl_FunctionCode
            // 
            this.lbl_FunctionCode.AutoSize = true;
            this.lbl_FunctionCode.Location = new System.Drawing.Point(26, 91);
            this.lbl_FunctionCode.Name = "lbl_FunctionCode";
            this.lbl_FunctionCode.Size = new System.Drawing.Size(79, 19);
            this.lbl_FunctionCode.TabIndex = 2;
            this.lbl_FunctionCode.Text = "Function";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "03 Holding Register (4x)"});
            this.comboBox2.Location = new System.Drawing.Point(110, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(258, 23);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Text = "03 Holding Register (4x)";
            // 
            // lbl_IpAddress
            // 
            this.lbl_IpAddress.AutoSize = true;
            this.lbl_IpAddress.Location = new System.Drawing.Point(15, 32);
            this.lbl_IpAddress.Name = "lbl_IpAddress";
            this.lbl_IpAddress.Size = new System.Drawing.Size(98, 19);
            this.lbl_IpAddress.TabIndex = 0;
            this.lbl_IpAddress.Text = "IP Address";
            // 
            // txt_IpAddress
            // 
            this.txt_IpAddress.Location = new System.Drawing.Point(18, 54);
            this.txt_IpAddress.Name = "txt_IpAddress";
            this.txt_IpAddress.Size = new System.Drawing.Size(235, 25);
            this.txt_IpAddress.TabIndex = 1;
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(288, 32);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(43, 19);
            this.lbl_Port.TabIndex = 2;
            this.lbl_Port.Text = "Port";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(291, 54);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(79, 25);
            this.txt_Port.TabIndex = 3;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(435, 372);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Setup";
            this.Load += new System.EventHandler(this.ConnectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_SlaveId;
        private System.Windows.Forms.Label lbl_SlaveId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lbl_FunctionCode;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox txt_IpAddress;
        private System.Windows.Forms.Label lbl_IpAddress;
    }
}