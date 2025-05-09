using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class SMSForm : Form
    {
        public SMSForm()
        {
            InitializeComponent();
        }

        private void SMSForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Sender";
            dataGridView1.Columns[1].Name = "Message";
            dataGridView1.Columns[2].Name = "Timestamp";
            dataGridView1.Columns[3].Name = "Type";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeviceConnected())
                {
                    MessageBox.Show("No device connected.");
                    return;
                }

                string output = ExecuteAdbCommand("shell content query --uri content://sms");

                File.WriteAllText("sms_raw_output.txt", output); // For debugging

                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("No SMS data retrieved.");
                    return;
                }

                dataGridView1.Rows.Clear();

                var rows = output.Split(new[] { "Row " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string row in rows)
                {
                    string smsSenderVal = GetValue(row, "address=");
                    string message = GetValue(row, "body=");
                    if (message.Length > 100) message = message.Substring(0, 100) + "...";

                    string date = GetUnixDateTime(GetValue(row, "date="));
                    string type = GetMessageType(GetValue(row, "type="));

                    dataGridView1.Rows.Add(smsSenderVal, message, date, type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading SMS: " + ex.Message);
            }
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADBapp;Integrated Security=True;";
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string smsSender = row.Cells["Sender"].Value?.ToString() ?? "";
                    string message = row.Cells["Message"].Value?.ToString() ?? "";
                    string timestamp = row.Cells["Timestamp"].Value?.ToString() ?? "";
                    string type = row.Cells["Type"].Value?.ToString() ?? "";

                    string query = "INSERT INTO MessagesTable (Sender, Message, Timestamp, Type) VALUES (@Sender, @Message, @Timestamp, @Type)";
                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Sender", smsSender);
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("SMS data saved to database.");
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

        private string ExecuteAdbCommand(string arguments)
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

        private bool IsDeviceConnected()
        {
            try
            {
                string state = ExecuteAdbCommand("get-state").Trim();
                return state.Equals("device", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private string GetValue(string row, string key)
        {
            // Example line: body=Hello there! address=+1234567890
            var pattern = $"{Regex.Escape(key)}(.*?)((\\s\\w+=)|$)";
            var match = Regex.Match(row, pattern);
            return match.Success ? match.Groups[1].Value.Trim().Trim(',') : "";
        }

        private string GetMessageType(string typeCode)
        {
            return typeCode switch
            {
                "1" => "Inbox",
                "2" => "Sent",
                "3" => "Draft",
                "4" => "Outbox",
                _ => "Unknown"
            };
        }

        private string GetUnixDateTime(string timestamp)
        {
            if (long.TryParse(timestamp, out long unix))
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unix);
                return dateTimeOffset.LocalDateTime.ToString("g");
            }
            return "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional
        }
    }
}
