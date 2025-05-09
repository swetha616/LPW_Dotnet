using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class CallLogsForm : Form
    {
        public CallLogsForm()
        {
            InitializeComponent();
        }

        private void CallLogsForm_Load(object sender, EventArgs e)
        {
            dgvCallLogs.ColumnCount = 4;
            dgvCallLogs.Columns[0].Name = "Number";
            dgvCallLogs.Columns[1].Name = "Call Type";
            dgvCallLogs.Columns[2].Name = "Date";
            dgvCallLogs.Columns[3].Name = "Duration";

            dgvCallLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeviceConnected())
                {
                    MessageBox.Show("No device connected. Please connect a device via ADB.");
                    return;
                }

                string output = ExecuteADBCommand("shell content query --uri content://call_log/calls");

                File.WriteAllText("adb_calllog_output.txt", output); // Optional for debugging

                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("No data retrieved. Make sure the device grants call log access.");
                    return;
                }

                dgvCallLogs.Rows.Clear();

                var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var rows = new List<string>();
                string currentRow = "";

                foreach (string line in lines)
                {
                    if (line.StartsWith("Row "))
                    {
                        if (!string.IsNullOrEmpty(currentRow))
                            rows.Add(currentRow.Trim());

                        currentRow = line;
                    }
                    else
                    {
                        currentRow += " " + line;
                    }
                }

                if (!string.IsNullOrEmpty(currentRow))
                    rows.Add(currentRow.Trim());

                foreach (string row in rows)
                {
                    string number = GetValue(row, "number=");
                    string type = GetCallType(GetValue(row, "type="));
                    string date = GetUnixDateTime(GetValue(row, "date="));
                    string duration = GetValue(row, "duration=");

                    dgvCallLogs.Rows.Add(number, type, date, duration);
                }

                if (dgvCallLogs.Rows.Count == 0)
                {
                    MessageBox.Show("Parsed 0 rows. Check permissions or ADB output.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading call logs: " + ex.Message);
            }
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADBapp;Integrated Security=True;";
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                foreach (DataGridViewRow row in dgvCallLogs.Rows)
                {
                    if (row.IsNewRow) continue;

                    string number = row.Cells["Number"].Value?.ToString() ?? "";
                    string type = row.Cells["Call Type"].Value?.ToString() ?? "";
                    string date = row.Cells["Date"].Value?.ToString() ?? "";
                    string duration = row.Cells["Duration"].Value?.ToString() ?? "";

                    string query = "INSERT INTO CallLogsTable (Number, CallType, Duration, Timestamp) " +
                                   "VALUES (@Number, @CallType, @Duration, @Timestamp)";

                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Number", number);
                    cmd.Parameters.AddWithValue("@CallType", type);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@Timestamp", date);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Call logs saved to database.");
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

        private bool IsDeviceConnected()
        {
            try
            {
                string output = ExecuteADBCommand("get-state").Trim();
                return output.Equals("device", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private string GetValue(string row, string key)
        {
            string pattern = $"{Regex.Escape(key)}(.*?)((\\s\\w+=)|$)";
            Match match = Regex.Match(row, pattern);
            return match.Success ? match.Groups[1].Value.Trim().Trim(',') : "";
        }

        private string GetCallType(string typeCode)
        {
            return typeCode switch
            {
                "1" => "Incoming",
                "2" => "Outgoing",
                "3" => "Missed",
                "4" => "Voicemail",
                "5" => "Rejected",
                "6" => "Blocked",
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
    }
}
