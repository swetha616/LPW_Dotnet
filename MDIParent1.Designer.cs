namespace ADBApp1
{
    partial class MDIParent1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem callLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smsMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.callLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smsMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.callLogsToolStripMenuItem,
                this.contactsToolStripMenuItem,
                this.smsMessagesToolStripMenuItem,
                this.loginAccountsToolStripMenuItem,
                this.deviceInfoToolStripMenuItem,
                this.exitToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // 
            // callLogsToolStripMenuItem
            // 
            this.callLogsToolStripMenuItem.Name = "callLogsToolStripMenuItem";
            this.callLogsToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.callLogsToolStripMenuItem.Text = "Call Logs";
            this.callLogsToolStripMenuItem.Click += new System.EventHandler(this.callLogsToolStripMenuItem_Click);

            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);

            // 
            // smsMessagesToolStripMenuItem
            // 
            this.smsMessagesToolStripMenuItem.Name = "smsMessagesToolStripMenuItem";
            this.smsMessagesToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.smsMessagesToolStripMenuItem.Text = "SMS";
            this.smsMessagesToolStripMenuItem.Click += new System.EventHandler(this.sMSMessageToolStripMenuItem_Click);

            // 
            // loginAccountsToolStripMenuItem
            // 
            this.loginAccountsToolStripMenuItem.Name = "loginAccountsToolStripMenuItem";
            this.loginAccountsToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.loginAccountsToolStripMenuItem.Text = "Login Accounts";
            this.loginAccountsToolStripMenuItem.Click += new System.EventHandler(this.loginAccountsToolStripMenuItem_Click);

            // 
            // deviceInfoToolStripMenuItem
            // 
            this.deviceInfoToolStripMenuItem.Name = "deviceInfoToolStripMenuItem";
            this.deviceInfoToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.deviceInfoToolStripMenuItem.Text = "Device Info";
            this.deviceInfoToolStripMenuItem.Click += new System.EventHandler(this.deviceInfoToolStripMenuItem_Click);

            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);

            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIParent1";
            this.Text = "Android ADB Dashboard";
            this.Load += new System.EventHandler(this.MDIParent1_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
