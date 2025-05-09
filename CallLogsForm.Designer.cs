namespace ADBApp1
{
    partial class CallLogsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSaveToDb;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dgvCallLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCallLogs = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallLogs)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvCallLogs
            // 
            this.dgvCallLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                          | System.Windows.Forms.AnchorStyles.Left)
                                          | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCallLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCallLogs.Location = new System.Drawing.Point(30, 30);
            this.dgvCallLogs.Name = "dgvCallLogs";
            this.dgvCallLogs.RowHeadersWidth = 51;
            this.dgvCallLogs.RowTemplate.Height = 29;
            this.dgvCallLogs.Size = new System.Drawing.Size(740, 320);
            this.dgvCallLogs.TabIndex = 0;

            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLoadData.Location = new System.Drawing.Point(530, 370);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(110, 35);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveToDb.Location = new System.Drawing.Point(310, 370);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(110, 35);
            this.btnSaveToDb.TabIndex = 2;
            this.btnSaveToDb.Text = "Save to DB";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);

            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerateReport.Location = new System.Drawing.Point(90, 370);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(130, 35);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // 
            // CallLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dgvCallLogs);
            this.Name = "CallLogsForm";
            this.Text = "Call Logs";
            this.Load += new System.EventHandler(this.CallLogsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallLogs)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
