namespace ADBApp1
{
    partial class ContactForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadContacts;
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadContacts = new System.Windows.Forms.Button();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(700, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLoadContacts
            // 
            this.btnLoadContacts.Location = new System.Drawing.Point(550, 350);
            this.btnLoadContacts.Name = "btnLoadContacts";
            this.btnLoadContacts.Size = new System.Drawing.Size(100, 30);
            this.btnLoadContacts.TabIndex = 1;
            this.btnLoadContacts.Text = "Load Contacts";
            this.btnLoadContacts.UseVisualStyleBackColor = true;
            this.btnLoadContacts.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(300, 350);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(100, 30);
            this.btnSaveToDb.TabIndex = 2;
            this.btnSaveToDb.Text = "Save to DB";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(50, 350);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(130, 30);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.btnLoadContacts);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ContactForm";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.ContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

    }
}
