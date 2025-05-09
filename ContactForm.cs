using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("PhoneNumber", "Phone Number");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string output = ExecuteADBCommand("shell content query --uri content://contacts/phones");

                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("No contact data retrieved. Ensure the device is connected and permissions are granted.");
                    return;
                }

                dataGridView1.Rows.Clear();

                string[] entries = output.Split(new[] { "Row " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string entry in entries)
                {
                    string name = GetValue(entry, "display_name=");
                    string number = GetValue(entry, "number=");

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(number))
                    {
                        dataGridView1.Rows.Add(name, number);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading contacts: " + ex.Message);
            }
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADBapp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Cells["Name"].Value?.ToString() ?? "";
                    string number = row.Cells["PhoneNumber"].Value?.ToString() ?? "";

                    string query = "INSERT INTO ContactsTable (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
                    using SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", number);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Contacts saved to database.");
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

            using Process process = Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        private string GetValue(string input, string key)
        {
            var match = Regex.Match(input, $"{Regex.Escape(key)}(.*?)((\\s\\w+=)|$)");
            return match.Success ? match.Groups[1].Value.Trim().Trim(',') : "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No-op
        }
    }
}
