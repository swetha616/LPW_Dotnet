namespace ADBApp1
{
    partial class LoginAccountsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLoginAccounts;
        private System.Windows.Forms.Button btnLoadData;
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
            this.dgvLoginAccounts = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginAccounts)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvLoginAccounts
            // 
            this.dgvLoginAccounts.AllowUserToAddRows = false;
            this.dgvLoginAccounts.AllowUserToResizeRows = false;
            this.dgvLoginAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoginAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginAccounts.Dock = DockStyle.Top;
            this.dgvLoginAccounts.Location = new System.Drawing.Point(0, 0);
            this.dgvLoginAccounts.Name = "dgvLoginAccounts";
            this.dgvLoginAccounts.RowHeadersWidth = 51;
            this.dgvLoginAccounts.RowTemplate.Height = 29;
            this.dgvLoginAccounts.Size = new System.Drawing.Size(800, 300);
            this.dgvLoginAccounts.TabIndex = 0;

            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(550, 320);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(100, 30);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(325, 320);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(100, 30);
            this.btnSaveToDb.TabIndex = 2;
            this.btnSaveToDb.Text = "Save to DB";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);

            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(70, 320);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(130, 30);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // 
            // LoginAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dgvLoginAccounts);
            this.Name = "LoginAccountsForm";
            this.Text = "Login Accounts";
            this.Load += new System.EventHandler(this.LoginAccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginAccounts)).EndInit();
            this.ResumeLayout(false);
        }

    }
}
