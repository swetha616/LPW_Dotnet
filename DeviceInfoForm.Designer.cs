namespace ADBApp1
{
    partial class DeviceInfoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDeviceInfo;
        private System.Windows.Forms.Button btnLoadDeviceInfo;
        private System.Windows.Forms.Button btnSaveToDb;
        private System.Windows.Forms.Button btnGenerateReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewDeviceInfo = new System.Windows.Forms.DataGridView();
            this.btnLoadDeviceInfo = new System.Windows.Forms.Button();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeviceInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDeviceInfo
            // 
            this.dataGridViewDeviceInfo.AllowUserToAddRows = false;
            this.dataGridViewDeviceInfo.AllowUserToDeleteRows = false;
            this.dataGridViewDeviceInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDeviceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeviceInfo.Location = new System.Drawing.Point(50, 40);
            this.dataGridViewDeviceInfo.Name = "dataGridViewDeviceInfo";
            this.dataGridViewDeviceInfo.ReadOnly = true;
            this.dataGridViewDeviceInfo.RowHeadersWidth = 51;
            this.dataGridViewDeviceInfo.RowTemplate.Height = 29;
            this.dataGridViewDeviceInfo.Size = new System.Drawing.Size(700, 300);
            this.dataGridViewDeviceInfo.TabIndex = 0;
            // 
            // btnLoadDeviceInfo
            // 
            this.btnLoadDeviceInfo.Location = new System.Drawing.Point(500, 360);
            this.btnLoadDeviceInfo.Name = "btnLoadDeviceInfo";
            this.btnLoadDeviceInfo.Size = new System.Drawing.Size(120, 30);
            this.btnLoadDeviceInfo.TabIndex = 1;
            this.btnLoadDeviceInfo.Text = "Load Info";
            this.btnLoadDeviceInfo.UseVisualStyleBackColor = true;
            this.btnLoadDeviceInfo.Click += new System.EventHandler(this.btnLoadDeviceInfo_Click);
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(370, 360);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(120, 30);
            this.btnSaveToDb.TabIndex = 2;
            this.btnSaveToDb.Text = "Save to DB";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(240, 360);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 30);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // DeviceInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.btnLoadDeviceInfo);
            this.Controls.Add(this.dataGridViewDeviceInfo);
            this.Name = "DeviceInfoForm";
            this.Text = "Device Info";
            this.Load += new System.EventHandler(this.DeviceInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeviceInfo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
