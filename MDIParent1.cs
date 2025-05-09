using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class MDIParent1 : Form
    {
        public MDIParent1()
        {
            InitializeComponent();
        }

        private bool IsDeviceConnected()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = "get-state",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using Process process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();

                return output.Equals("device", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking device connection: " + ex.Message);
                return false;
            }
        }

        private void ShowFormIfDeviceConnected(Form form)
        {
            if (IsDeviceConnected())
            {
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("No device connected. Please connect your Android device and enable ADB.", "ADB Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sMSMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfDeviceConnected(new SMSForm());
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfDeviceConnected(new ContactForm());
        }

        private void callLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfDeviceConnected(new CallLogsForm());
        }

        private void deviceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfDeviceConnected(new DeviceInfoForm());
        }

        private void loginAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfDeviceConnected(new LoginAccountsForm());
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox tb && !string.IsNullOrEmpty(tb.SelectedText))
            {
                Clipboard.SetText(tb.SelectedText);
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            // Optionally validate ADB installation
            if (!IsADBInstalled())
            {
                MessageBox.Show("ADB is not installed or not added to the PATH.", "ADB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private bool IsADBInstalled()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = "version",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using Process process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output.Contains("Android Debug Bridge");
            }
            catch
            {
                return false;
            }
        }
    }
}
