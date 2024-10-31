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
            this.rtb_dataView = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbl_WritePlcAddress = new System.Windows.Forms.Label();
            this.txt_ReadAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReadData = new System.Windows.Forms.Button();
            this.lbl_ReadPlcAddress = new System.Windows.Forms.Label();
            this.lbl_ReadTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_WriteQuantity = new System.Windows.Forms.TextBox();
            this.lbl_ReadAddress = new System.Windows.Forms.Label();
            this.lbl_WriteQuantity = new System.Windows.Forms.Label();
            this.lbl_ReadQuantity = new System.Windows.Forms.Label();
            this.txt_WriteAddress = new System.Windows.Forms.TextBox();
            this.txt_ReadQuantity = new System.Windows.Forms.TextBox();
            this.lbl_WriteAddress = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_WriteTest = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.connectioncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.HeaderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowHeadersVisible = false;
            this.dataView.RowHeadersWidth = 51;
            this.dataView.RowTemplate.Height = 27;
            this.dataView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.ShowCellToolTips = false;
            this.dataView.Size = new System.Drawing.Size(446, 384);
            this.dataView.TabIndex = 6;
            // 
            // rtb_dataView
            // 
            this.rtb_dataView.BackColor = System.Drawing.Color.White;
            this.rtb_dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_dataView.Location = new System.Drawing.Point(0, 0);
            this.rtb_dataView.Name = "rtb_dataView";
            this.rtb_dataView.ReadOnly = true;
            this.rtb_dataView.Size = new System.Drawing.Size(1005, 322);
            this.rtb_dataView.TabIndex = 25;
            this.rtb_dataView.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 792);
            this.tableLayoutPanel1.TabIndex = 29;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_dataView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 433);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 322);
            this.panel2.TabIndex = 26;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 43);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbl_WritePlcAddress);
            this.splitContainer2.Panel2.Controls.Add(this.txt_ReadAddress);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.btnReadData);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_ReadPlcAddress);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_ReadTest);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.txt_WriteQuantity);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_ReadAddress);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_WriteQuantity);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_ReadQuantity);
            this.splitContainer2.Panel2.Controls.Add(this.txt_WriteAddress);
            this.splitContainer2.Panel2.Controls.Add(this.txt_ReadQuantity);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_WriteAddress);
            this.splitContainer2.Panel2.Controls.Add(this.btnWriteData);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_WriteTest);
            this.splitContainer2.Size = new System.Drawing.Size(1005, 384);
            this.splitContainer2.SplitterDistance = 446;
            this.splitContainer2.TabIndex = 27;
            // 
            // lbl_WritePlcAddress
            // 
            this.lbl_WritePlcAddress.AutoSize = true;
            this.lbl_WritePlcAddress.Location = new System.Drawing.Point(407, 251);
            this.lbl_WritePlcAddress.Name = "lbl_WritePlcAddress";
            this.lbl_WritePlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_WritePlcAddress.TabIndex = 42;
            this.lbl_WritePlcAddress.Text = "40001";
            // 
            // txt_ReadAddress
            // 
            this.txt_ReadAddress.Location = new System.Drawing.Point(98, 65);
            this.txt_ReadAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadAddress.Name = "txt_ReadAddress";
            this.txt_ReadAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_ReadAddress.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "PLC address =";
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(452, 152);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(82, 28);
            this.btnReadData.TabIndex = 25;
            this.btnReadData.Text = "Read";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // lbl_ReadPlcAddress
            // 
            this.lbl_ReadPlcAddress.AutoSize = true;
            this.lbl_ReadPlcAddress.Location = new System.Drawing.Point(407, 68);
            this.lbl_ReadPlcAddress.Name = "lbl_ReadPlcAddress";
            this.lbl_ReadPlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_ReadPlcAddress.TabIndex = 40;
            this.lbl_ReadPlcAddress.Text = "40001";
            // 
            // lbl_ReadTest
            // 
            this.lbl_ReadTest.AutoSize = true;
            this.lbl_ReadTest.Location = new System.Drawing.Point(10, 1);
            this.lbl_ReadTest.Name = "lbl_ReadTest";
            this.lbl_ReadTest.Size = new System.Drawing.Size(74, 15);
            this.lbl_ReadTest.TabIndex = 26;
            this.lbl_ReadTest.Text = "Read Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "PLC address =";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 3);
            this.label1.TabIndex = 27;
            // 
            // txt_WriteQuantity
            // 
            this.txt_WriteQuantity.Location = new System.Drawing.Point(98, 290);
            this.txt_WriteQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteQuantity.Name = "txt_WriteQuantity";
            this.txt_WriteQuantity.Size = new System.Drawing.Size(436, 25);
            this.txt_WriteQuantity.TabIndex = 38;
            // 
            // lbl_ReadAddress
            // 
            this.lbl_ReadAddress.AutoSize = true;
            this.lbl_ReadAddress.Location = new System.Drawing.Point(22, 68);
            this.lbl_ReadAddress.Name = "lbl_ReadAddress";
            this.lbl_ReadAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_ReadAddress.TabIndex = 28;
            this.lbl_ReadAddress.Text = "Address";
            // 
            // lbl_WriteQuantity
            // 
            this.lbl_WriteQuantity.AutoSize = true;
            this.lbl_WriteQuantity.Location = new System.Drawing.Point(22, 293);
            this.lbl_WriteQuantity.Name = "lbl_WriteQuantity";
            this.lbl_WriteQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_WriteQuantity.TabIndex = 37;
            this.lbl_WriteQuantity.Text = "Quantity";
            // 
            // lbl_ReadQuantity
            // 
            this.lbl_ReadQuantity.AutoSize = true;
            this.lbl_ReadQuantity.Location = new System.Drawing.Point(22, 109);
            this.lbl_ReadQuantity.Name = "lbl_ReadQuantity";
            this.lbl_ReadQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_ReadQuantity.TabIndex = 30;
            this.lbl_ReadQuantity.Text = "Quantity";
            // 
            // txt_WriteAddress
            // 
            this.txt_WriteAddress.Location = new System.Drawing.Point(98, 248);
            this.txt_WriteAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteAddress.Name = "txt_WriteAddress";
            this.txt_WriteAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_WriteAddress.TabIndex = 36;
            // 
            // txt_ReadQuantity
            // 
            this.txt_ReadQuantity.Location = new System.Drawing.Point(98, 107);
            this.txt_ReadQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadQuantity.Name = "txt_ReadQuantity";
            this.txt_ReadQuantity.Size = new System.Drawing.Size(436, 25);
            this.txt_ReadQuantity.TabIndex = 31;
            // 
            // lbl_WriteAddress
            // 
            this.lbl_WriteAddress.AutoSize = true;
            this.lbl_WriteAddress.Location = new System.Drawing.Point(22, 251);
            this.lbl_WriteAddress.Name = "lbl_WriteAddress";
            this.lbl_WriteAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_WriteAddress.TabIndex = 35;
            this.lbl_WriteAddress.Text = "Address";
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(452, 335);
            this.btnWriteData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(82, 28);
            this.btnWriteData.TabIndex = 32;
            this.btnWriteData.Text = "Write";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(11, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(523, 3);
            this.label4.TabIndex = 34;
            // 
            // lbl_WriteTest
            // 
            this.lbl_WriteTest.AutoSize = true;
            this.lbl_WriteTest.Location = new System.Drawing.Point(8, 187);
            this.lbl_WriteTest.Name = "lbl_WriteTest";
            this.lbl_WriteTest.Size = new System.Drawing.Size(73, 15);
            this.lbl_WriteTest.TabIndex = 33;
            this.lbl_WriteTest.Text = "Write Test";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.HeaderMenu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 34);
            this.panel1.TabIndex = 0;
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.BackColor = System.Drawing.SystemColors.Window;
            this.HeaderMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.HeaderMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.connectioncToolStripMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(0, 0);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(1005, 28);
            this.HeaderMenu.TabIndex = 29;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileFToolStripMenuItem.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuExit.Size = new System.Drawing.Size(224, 26);
            this.menuExit.Text = "Exit";
            // 
            // connectioncToolStripMenuItem
            // 
            this.connectioncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConnect,
            this.menuDisconnect});
            this.connectioncToolStripMenuItem.Name = "connectioncToolStripMenuItem";
            this.connectioncToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.connectioncToolStripMenuItem.Text = "Connection";
            // 
            // menuConnect
            // 
            this.menuConnect.Name = "menuConnect";
            this.menuConnect.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuConnect.Size = new System.Drawing.Size(224, 26);
            this.menuConnect.Text = "Connect";
            this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
            // 
            // menuDisconnect
            // 
            this.menuDisconnect.Name = "menuDisconnect";
            this.menuDisconnect.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuDisconnect.Size = new System.Drawing.Size(224, 26);
            this.menuDisconnect.Text = "Disconnect";
            this.menuDisconnect.Click += new System.EventHandler(this.menuDisconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1011, 792);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.HeaderMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.RichTextBox rtb_dataView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_WritePlcAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_ReadPlcAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_WriteQuantity;
        private System.Windows.Forms.Label lbl_WriteQuantity;
        private System.Windows.Forms.TextBox txt_WriteAddress;
        private System.Windows.Forms.Label lbl_WriteAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_WriteTest;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.TextBox txt_ReadQuantity;
        private System.Windows.Forms.Label lbl_ReadQuantity;
        private System.Windows.Forms.TextBox txt_ReadAddress;
        private System.Windows.Forms.Label lbl_ReadAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ReadTest;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem connectioncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuConnect;
        private System.Windows.Forms.ToolStripMenuItem menuDisconnect;
    }
}

