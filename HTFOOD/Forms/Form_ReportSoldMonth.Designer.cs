namespace HTFOOD.Forms
{
    partial class Form_ReportSoldMonth
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportSoldMonth));
            this.panelHeaderRP = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtmFromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dtmToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.rpSoldMonth = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelHeaderRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaderRP
            // 
            this.panelHeaderRP.BackColor = System.Drawing.Color.DeepPink;
            this.panelHeaderRP.Controls.Add(this.lblHeader);
            this.panelHeaderRP.Controls.Add(this.btnClose);
            this.panelHeaderRP.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderRP.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderRP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeaderRP.Name = "panelHeaderRP";
            this.panelHeaderRP.Size = new System.Drawing.Size(1161, 32);
            this.panelHeaderRP.TabIndex = 5;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(472, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(278, 21);
            this.lblHeader.TabIndex = 9;
            this.lblHeader.Text = "THỐNG KÊ DOANH THU THEO THÁNG";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1113, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelHeaderRP;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DeepPink;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 32);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(6, 548);
            this.panelLeft.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepPink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1155, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 548);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepPink;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(6, 574);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1149, 6);
            this.panel3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DeepPink;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DeepPink;
            this.label2.Location = new System.Drawing.Point(251, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Đến ngày";
            // 
            // dtmFromDate
            // 
            this.dtmFromDate.BackColor = System.Drawing.Color.DeepPink;
            this.dtmFromDate.BorderRadius = 0;
            this.dtmFromDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFromDate.ForeColor = System.Drawing.Color.White;
            this.dtmFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFromDate.FormatCustom = "dd/MM/yyyy";
            this.dtmFromDate.Location = new System.Drawing.Point(84, 40);
            this.dtmFromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtmFromDate.Name = "dtmFromDate";
            this.dtmFromDate.Size = new System.Drawing.Size(160, 38);
            this.dtmFromDate.TabIndex = 26;
            this.dtmFromDate.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // dtmToDate
            // 
            this.dtmToDate.BackColor = System.Drawing.Color.DeepPink;
            this.dtmToDate.BorderRadius = 0;
            this.dtmToDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmToDate.ForeColor = System.Drawing.Color.White;
            this.dtmToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmToDate.FormatCustom = "dd/MM/yyyy";
            this.dtmToDate.Location = new System.Drawing.Point(334, 40);
            this.dtmToDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtmToDate.Name = "dtmToDate";
            this.dtmToDate.Size = new System.Drawing.Size(160, 38);
            this.dtmToDate.TabIndex = 27;
            this.dtmToDate.Value = new System.DateTime(2021, 1, 19, 0, 0, 0, 0);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReport.BackColor = System.Drawing.Color.DeepPink;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(501, 40);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(111, 38);
            this.btnReport.TabIndex = 28;
            this.btnReport.Text = "Thống kê";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // rpSoldMonth
            // 
            this.rpSoldMonth.ActiveViewIndex = -1;
            this.rpSoldMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpSoldMonth.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpSoldMonth.Location = new System.Drawing.Point(11, 87);
            this.rpSoldMonth.Name = "rpSoldMonth";
            this.rpSoldMonth.Size = new System.Drawing.Size(1138, 478);
            this.rpSoldMonth.TabIndex = 29;
            this.rpSoldMonth.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Form_ReportSoldMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 580);
            this.Controls.Add(this.rpSoldMonth);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dtmToDate);
            this.Controls.Add(this.dtmFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelHeaderRP);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_ReportSoldMonth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ DOANH THU THEO THÁNG";
            this.panelHeaderRP.ResumeLayout(false);
            this.panelHeaderRP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderRP;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDatepicker dtmFromDate;
        private Bunifu.Framework.UI.BunifuDatepicker dtmToDate;
        private System.Windows.Forms.Button btnReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpSoldMonth;
    }
}