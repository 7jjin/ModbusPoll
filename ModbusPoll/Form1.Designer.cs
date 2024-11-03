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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.rtb_dataView = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbx_writeTest = new System.Windows.Forms.GroupBox();
            this.txt_WriteAddress = new System.Windows.Forms.TextBox();
            this.lbl_WriteAddress = new System.Windows.Forms.Label();
            this.txt_WriteQuantity = new System.Windows.Forms.TextBox();
            this.lbl_WriteQuantity = new System.Windows.Forms.Label();
            this.lbl_WritePlcAddress = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gbx_readTest = new System.Windows.Forms.GroupBox();
            this.txt_ReadAddress = new System.Windows.Forms.TextBox();
            this.lbl_ReadAddress = new System.Windows.Forms.Label();
            this.txt_ReadQuantity = new System.Windows.Forms.TextBox();
            this.lbl_ReadPlcAddress = new System.Windows.Forms.Label();
            this.btnReadData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_ReadQuantity = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.connectioncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStautsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.stlbl_statusCircle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_conectText = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbx_writeTest.SuspendLayout();
            this.gbx_readTest.SuspendLayout();
            this.panel1.SuspendLayout();
            this.HeaderMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Margin = new System.Windows.Forms.Padding(0);
            this.dataView.MultiSelect = false;
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersVisible = false;
            this.dataView.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataView.RowTemplate.Height = 27;
            this.dataView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.ShowCellToolTips = false;
            this.dataView.Size = new System.Drawing.Size(433, 359);
            this.dataView.TabIndex = 6;
            // 
            // rtb_dataView
            // 
            this.rtb_dataView.BackColor = System.Drawing.Color.White;
            this.rtb_dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_dataView.Location = new System.Drawing.Point(0, 0);
            this.rtb_dataView.Name = "rtb_dataView";
            this.rtb_dataView.ReadOnly = true;
            this.rtb_dataView.Size = new System.Drawing.Size(978, 373);
            this.rtb_dataView.TabIndex = 25;
            this.rtb_dataView.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 373F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 795);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_dataView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 388);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 373);
            this.panel2.TabIndex = 26;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 29);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer2.Panel2.Controls.Add(this.gbx_writeTest);
            this.splitContainer2.Panel2.Controls.Add(this.gbx_readTest);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(978, 359);
            this.splitContainer2.SplitterDistance = 433;
            this.splitContainer2.TabIndex = 27;
            // 
            // gbx_writeTest
            // 
            this.gbx_writeTest.BackColor = System.Drawing.SystemColors.Menu;
            this.gbx_writeTest.Controls.Add(this.txt_WriteAddress);
            this.gbx_writeTest.Controls.Add(this.lbl_WriteAddress);
            this.gbx_writeTest.Controls.Add(this.txt_WriteQuantity);
            this.gbx_writeTest.Controls.Add(this.lbl_WriteQuantity);
            this.gbx_writeTest.Controls.Add(this.lbl_WritePlcAddress);
            this.gbx_writeTest.Controls.Add(this.btnWriteData);
            this.gbx_writeTest.Controls.Add(this.label5);
            this.gbx_writeTest.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbx_writeTest.Location = new System.Drawing.Point(25, 184);
            this.gbx_writeTest.Name = "gbx_writeTest";
            this.gbx_writeTest.Size = new System.Drawing.Size(484, 152);
            this.gbx_writeTest.TabIndex = 44;
            this.gbx_writeTest.TabStop = false;
            this.gbx_writeTest.Text = "Write Test";
            // 
            // txt_WriteAddress
            // 
            this.txt_WriteAddress.Location = new System.Drawing.Point(105, 33);
            this.txt_WriteAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteAddress.Name = "txt_WriteAddress";
            this.txt_WriteAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_WriteAddress.TabIndex = 36;
            // 
            // lbl_WriteAddress
            // 
            this.lbl_WriteAddress.AutoSize = true;
            this.lbl_WriteAddress.Location = new System.Drawing.Point(29, 36);
            this.lbl_WriteAddress.Name = "lbl_WriteAddress";
            this.lbl_WriteAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_WriteAddress.TabIndex = 35;
            this.lbl_WriteAddress.Text = "Address";
            // 
            // txt_WriteQuantity
            // 
            this.txt_WriteQuantity.Location = new System.Drawing.Point(105, 74);
            this.txt_WriteQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_WriteQuantity.Name = "txt_WriteQuantity";
            this.txt_WriteQuantity.Size = new System.Drawing.Size(178, 25);
            this.txt_WriteQuantity.TabIndex = 38;
            // 
            // lbl_WriteQuantity
            // 
            this.lbl_WriteQuantity.AutoSize = true;
            this.lbl_WriteQuantity.Location = new System.Drawing.Point(29, 77);
            this.lbl_WriteQuantity.Name = "lbl_WriteQuantity";
            this.lbl_WriteQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_WriteQuantity.TabIndex = 37;
            this.lbl_WriteQuantity.Text = "Quantity";
            // 
            // lbl_WritePlcAddress
            // 
            this.lbl_WritePlcAddress.AutoSize = true;
            this.lbl_WritePlcAddress.Location = new System.Drawing.Point(404, 36);
            this.lbl_WritePlcAddress.Name = "lbl_WritePlcAddress";
            this.lbl_WritePlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_WritePlcAddress.TabIndex = 42;
            this.lbl_WritePlcAddress.Text = "40001";
            // 
            // btnWriteData
            // 
            this.btnWriteData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWriteData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWriteData.FlatAppearance.BorderSize = 0;
            this.btnWriteData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnWriteData.Location = new System.Drawing.Point(32, 113);
            this.btnWriteData.Margin = new System.Windows.Forms.Padding(0);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(419, 28);
            this.btnWriteData.TabIndex = 32;
            this.btnWriteData.Text = "Write Register";
            this.btnWriteData.UseVisualStyleBackColor = false;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "PLC address =";
            // 
            // gbx_readTest
            // 
            this.gbx_readTest.BackColor = System.Drawing.SystemColors.Menu;
            this.gbx_readTest.Controls.Add(this.txt_ReadAddress);
            this.gbx_readTest.Controls.Add(this.lbl_ReadAddress);
            this.gbx_readTest.Controls.Add(this.txt_ReadQuantity);
            this.gbx_readTest.Controls.Add(this.lbl_ReadPlcAddress);
            this.gbx_readTest.Controls.Add(this.btnReadData);
            this.gbx_readTest.Controls.Add(this.label2);
            this.gbx_readTest.Controls.Add(this.lbl_ReadQuantity);
            this.gbx_readTest.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbx_readTest.Location = new System.Drawing.Point(25, 12);
            this.gbx_readTest.Name = "gbx_readTest";
            this.gbx_readTest.Size = new System.Drawing.Size(484, 152);
            this.gbx_readTest.TabIndex = 43;
            this.gbx_readTest.TabStop = false;
            this.gbx_readTest.Text = "Read Test";
            // 
            // txt_ReadAddress
            // 
            this.txt_ReadAddress.Location = new System.Drawing.Point(105, 32);
            this.txt_ReadAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadAddress.Name = "txt_ReadAddress";
            this.txt_ReadAddress.Size = new System.Drawing.Size(178, 25);
            this.txt_ReadAddress.TabIndex = 29;
            // 
            // lbl_ReadAddress
            // 
            this.lbl_ReadAddress.AutoSize = true;
            this.lbl_ReadAddress.Location = new System.Drawing.Point(29, 35);
            this.lbl_ReadAddress.Name = "lbl_ReadAddress";
            this.lbl_ReadAddress.Size = new System.Drawing.Size(60, 15);
            this.lbl_ReadAddress.TabIndex = 28;
            this.lbl_ReadAddress.Text = "Address";
            // 
            // txt_ReadQuantity
            // 
            this.txt_ReadQuantity.Location = new System.Drawing.Point(105, 73);
            this.txt_ReadQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ReadQuantity.Name = "txt_ReadQuantity";
            this.txt_ReadQuantity.Size = new System.Drawing.Size(178, 25);
            this.txt_ReadQuantity.TabIndex = 31;
            // 
            // lbl_ReadPlcAddress
            // 
            this.lbl_ReadPlcAddress.AutoSize = true;
            this.lbl_ReadPlcAddress.Location = new System.Drawing.Point(404, 42);
            this.lbl_ReadPlcAddress.Name = "lbl_ReadPlcAddress";
            this.lbl_ReadPlcAddress.Size = new System.Drawing.Size(47, 15);
            this.lbl_ReadPlcAddress.TabIndex = 40;
            this.lbl_ReadPlcAddress.Text = "40001";
            // 
            // btnReadData
            // 
            this.btnReadData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReadData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReadData.FlatAppearance.BorderSize = 0;
            this.btnReadData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReadData.Location = new System.Drawing.Point(32, 111);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(419, 28);
            this.btnReadData.TabIndex = 25;
            this.btnReadData.Text = "Read Register";
            this.btnReadData.UseVisualStyleBackColor = false;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "PLC address =";
            // 
            // lbl_ReadQuantity
            // 
            this.lbl_ReadQuantity.AutoSize = true;
            this.lbl_ReadQuantity.Location = new System.Drawing.Point(29, 75);
            this.lbl_ReadQuantity.Name = "lbl_ReadQuantity";
            this.lbl_ReadQuantity.Size = new System.Drawing.Size(62, 15);
            this.lbl_ReadQuantity.TabIndex = 30;
            this.lbl_ReadQuantity.Text = "Quantity";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.HeaderMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 29);
            this.panel1.TabIndex = 0;
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.AutoSize = false;
            this.HeaderMenu.BackColor = System.Drawing.SystemColors.Window;
            this.HeaderMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.HeaderMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.connectioncToolStripMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(0, 0);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Padding = new System.Windows.Forms.Padding(0);
            this.HeaderMenu.Size = new System.Drawing.Size(976, 27);
            this.HeaderMenu.TabIndex = 29;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.fileFToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(36, 27);
            this.fileFToolStripMenuItem.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.AutoSize = false;
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuExit.Size = new System.Drawing.Size(300, 26);
            this.menuExit.Text = "Exit              ";
            // 
            // connectioncToolStripMenuItem
            // 
            this.connectioncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConnect,
            this.menuDisconnect});
            this.connectioncToolStripMenuItem.Name = "connectioncToolStripMenuItem";
            this.connectioncToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.connectioncToolStripMenuItem.Size = new System.Drawing.Size(92, 27);
            this.connectioncToolStripMenuItem.Text = "Connection";
            // 
            // menuConnect
            // 
            this.menuConnect.AutoSize = false;
            this.menuConnect.Name = "menuConnect";
            this.menuConnect.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuConnect.Size = new System.Drawing.Size(500, 26);
            this.menuConnect.Text = "Connect          ";
            this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
            // 
            // menuDisconnect
            // 
            this.menuDisconnect.AutoSize = false;
            this.menuDisconnect.Name = "menuDisconnect";
            this.menuDisconnect.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuDisconnect.Size = new System.Drawing.Size(500, 26);
            this.menuDisconnect.Text = "Disconnect";
            this.menuDisconnect.Click += new System.EventHandler(this.menuDisconnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStautsLabel,
            this.tslbl_status,
            this.toolStripStatusLabel1,
            this.tslbl_timer,
            this.stlbl_statusCircle,
            this.tslbl_conectText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 761);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 34);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStautsLabel
            // 
            this.toolStripStautsLabel.Name = "toolStripStautsLabel";
            this.toolStripStautsLabel.Size = new System.Drawing.Size(63, 28);
            this.toolStripStautsLabel.Text = "Status : ";
            // 
            // tslbl_status
            // 
            this.tslbl_status.AutoSize = false;
            this.tslbl_status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslbl_status.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tslbl_status.Name = "tslbl_status";
            this.tslbl_status.Size = new System.Drawing.Size(400, 28);
            this.tslbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 28);
            this.toolStripStatusLabel1.Text = "Time : ";
            // 
            // tslbl_timer
            // 
            this.tslbl_timer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslbl_timer.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tslbl_timer.Name = "tslbl_timer";
            this.tslbl_timer.Size = new System.Drawing.Size(156, 28);
            this.tslbl_timer.Text = "toolStripStatusLabel2";
            // 
            // stlbl_statusCircle
            // 
            this.stlbl_statusCircle.AutoSize = false;
            this.stlbl_statusCircle.BackColor = System.Drawing.Color.Transparent;
            this.stlbl_statusCircle.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stlbl_statusCircle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stlbl_statusCircle.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.stlbl_statusCircle.Name = "stlbl_statusCircle";
            this.stlbl_statusCircle.Size = new System.Drawing.Size(22, 28);
            this.stlbl_statusCircle.Text = "      ";
            // 
            // tslbl_conectText
            // 
            this.tslbl_conectText.Margin = new System.Windows.Forms.Padding(6, 4, 0, 2);
            this.tslbl_conectText.Name = "tslbl_conectText";
            this.tslbl_conectText.Size = new System.Drawing.Size(83, 28);
            this.tslbl_conectText.Text = "Connected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(978, 795);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.HeaderMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus Poll";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbx_writeTest.ResumeLayout(false);
            this.gbx_writeTest.PerformLayout();
            this.gbx_readTest.ResumeLayout(false);
            this.gbx_readTest.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.TextBox txt_ReadQuantity;
        private System.Windows.Forms.Label lbl_ReadQuantity;
        private System.Windows.Forms.TextBox txt_ReadAddress;
        private System.Windows.Forms.Label lbl_ReadAddress;
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
        private System.Windows.Forms.GroupBox gbx_readTest;
        private System.Windows.Forms.GroupBox gbx_writeTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStautsLabel;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_timer;
        private System.Windows.Forms.ToolStripStatusLabel stlbl_statusCircle;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_conectText;
    }
}

