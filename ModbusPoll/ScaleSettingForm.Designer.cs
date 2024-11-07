namespace ModbusPoll
{
    partial class ScaleSettingForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnscaleSetting = new System.Windows.Forms.Button();
            this.ckb_isScale = new System.Windows.Forms.CheckBox();
            this.txt_endScale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_startScale = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnscaleSetting);
            this.panel1.Controls.Add(this.ckb_isScale);
            this.panel1.Controls.Add(this.txt_endScale);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_startScale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 138);
            this.panel1.TabIndex = 0;
            // 
            // btnscaleSetting
            // 
            this.btnscaleSetting.Location = new System.Drawing.Point(292, 93);
            this.btnscaleSetting.Name = "btnscaleSetting";
            this.btnscaleSetting.Size = new System.Drawing.Size(82, 26);
            this.btnscaleSetting.TabIndex = 7;
            this.btnscaleSetting.Text = "setting";
            this.btnscaleSetting.UseVisualStyleBackColor = true;
            this.btnscaleSetting.Click += new System.EventHandler(this.btnscaleSetting_Click);
            // 
            // ckb_isScale
            // 
            this.ckb_isScale.AutoSize = true;
            this.ckb_isScale.Location = new System.Drawing.Point(37, 71);
            this.ckb_isScale.Name = "ckb_isScale";
            this.ckb_isScale.Size = new System.Drawing.Size(95, 19);
            this.ckb_isScale.TabIndex = 6;
            this.ckb_isScale.Text = "Use scale";
            this.ckb_isScale.UseVisualStyleBackColor = true;
            this.ckb_isScale.CheckedChanged += new System.EventHandler(this.ckb_isScale_CheckedChanged);
            // 
            // txt_endScale
            // 
            this.txt_endScale.Location = new System.Drawing.Point(214, 40);
            this.txt_endScale.Margin = new System.Windows.Forms.Padding(0);
            this.txt_endScale.Name = "txt_endScale";
            this.txt_endScale.Size = new System.Drawing.Size(160, 25);
            this.txt_endScale.TabIndex = 5;
            this.txt_endScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "~";
            // 
            // txt_startScale
            // 
            this.txt_startScale.Location = new System.Drawing.Point(37, 40);
            this.txt_startScale.Margin = new System.Windows.Forms.Padding(0);
            this.txt_startScale.Name = "txt_startScale";
            this.txt_startScale.Size = new System.Drawing.Size(148, 25);
            this.txt_startScale.TabIndex = 3;
            this.txt_startScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ScaleSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 144);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScaleSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScaleSetting";
            this.Load += new System.EventHandler(this.ScaleSettingForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckb_isScale;
        private System.Windows.Forms.TextBox txt_endScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_startScale;
        private System.Windows.Forms.Button btnscaleSetting;
    }
}