using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class LoginAccountsForm : Form
    {
        public LoginAccountsForm()
        {
            InitializeComponent();
        }

        private void LoginAccountsForm_Load(object sender, EventArgs e)
        {
            dgvLoginAccounts.ColumnCount = 3;
            dgvLoginAccounts.Columns[0].Name = "Account Name";
            dgvLoginAccounts.Columns[1].Name = "Type";
            dgvLoginAccounts.Columns[2].Name = "Sync Enabled";
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                string output = ExecuteADBCommand("shell dumpsys account");

                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("No account data retrieved. Ensure the device is connected.");
                    return;
                }

                dgvLoginAccounts.Rows.Clear();

                string[] lines = output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                string accountName = "", accountType = "", syncEnabled = "";

                foreach (string line in lines)
                {
                    if (line.Contains("Account {name="))
                    {
                        int nameStart = line.IndexOf("name=") + 5;
                        int nameEnd = line.IndexOf(",", nameStart);
                        int typeStart = line.IndexOf("type=") + 5;
                        int typeEnd = line.IndexOf("}", typeStart);

                        if (nameStart > 0 && nameEnd > nameStart && typeStart > 0 && typeEnd > typeStart)
                        {
                            accountName = line.Substring(nameStart, nameEnd - nameStart).Trim();
                            accountType = line.Substring(typeStart, typeEnd - typeStart).Trim();
                        }
                    }

                    if (line.Trim().StartsWith("syncEnabled"))
                    {
                        syncEnabled = line.Contains("true") ? "Yes" : "No";
                        dgvLoginAccounts.Rows.Add(accountName, accountType, syncEnabled);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading login accounts: " + ex.Message);
            }
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADBapp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                foreach (DataGridViewRow row in dgvLoginAccounts.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Cells["Account Name"].Value?.ToString() ?? "";
                    string type = row.Cells["Type"].Value?.ToString() ?? "";
                    string sync = row.Cells["Sync Enabled"].Value?.ToString() ?? "";

                    string query = "INSERT INTO LoginAccountsTable (AccountName, AccountType, SyncEnabled) " +
                                   "VALUES (@AccountName, @AccountType, @SyncEnabled)";

                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@AccountName", name);
                    cmd.Parameters.AddWithValue("@AccountType", type);
                    cmd.Parameters.AddWithValue("@SyncEnabled", sync);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Login accounts saved to database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report generation not implemented yet.");
        }

        private string ExecuteADBCommand(string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using Process process = Process.Start(startInfo)!;
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
