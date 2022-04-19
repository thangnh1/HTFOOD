namespace HTFOOD.Forms
{
    partial class Form_ReportSold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportSold));
            this.panelHeaderRP = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.rpSold = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelLeft = new System.Windows.Forms.Panel();
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
            this.panelHeaderRP.TabIndex = 4;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(472, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(228, 21);
            this.lblHeader.TabIndex = 9;
            this.lblHeader.Text = "THỐNG KÊ SẢN PHẨM ĐÃ BÁN";
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepPink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1155, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 502);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepPink;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(6, 528);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1149, 6);
            this.panel3.TabIndex = 9;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelHeaderRP;
            this.bunifuDragControl1.Vertical = true;
            // 
            // rpSold
            // 
            this.rpSold.ActiveViewIndex = -1;
            this.rpSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpSold.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpSold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpSold.Location = new System.Drawing.Point(6, 32);
            this.rpSold.Name = "rpSold";
            this.rpSold.Size = new System.Drawing.Size(1149, 496);
            this.rpSold.TabIndex = 10;
            this.rpSold.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DeepPink;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 32);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(6, 502);
            this.panelLeft.TabIndex = 5;
            // 
            // Form_ReportSold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 534);
            this.Controls.Add(this.rpSold);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelHeaderRP);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_ReportSold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sản phẩm đã bán";
            this.panelHeaderRP.ResumeLayout(false);
            this.panelHeaderRP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderRP;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpSold;
        private System.Windows.Forms.Panel panelLeft;
    }
}