using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ADBApp1
{
    public partial class DeviceInfoForm : Form
    {
        public DeviceInfoForm()
        {
            InitializeComponent();
        }

        private void DeviceInfoForm_Load(object sender, EventArgs e)
        {
            dataGridViewDeviceInfo.ColumnCount = 2;
            dataGridViewDeviceInfo.Columns[0].Name = "Property";
            dataGridViewDeviceInfo.Columns[1].Name = "Value";
        }

        private void btnLoadDeviceInfo_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewDeviceInfo.Rows.Clear();

                string[] properties = new[]
                {
                    "ro.product.model", "ro.product.manufacturer", "ro.build.version.release",
                    "ro.build.version.sdk", "ro.serialno", "ro.hardware", "ro.board.platform"
                };

                foreach (string prop in properties)
                {
                    string value = ExecuteADBCommand($"shell getprop {prop}").Trim();
                    dataGridViewDeviceInfo.Rows.Add(prop, value);
                }

                // Also add the device ID using `adb devices`
                string devicesOutput = ExecuteADBCommand("devices");
                string deviceId = ParseDeviceId(devicesOutput);
                if (!string.IsNullOrWhiteSpace(deviceId))
                {
                    dataGridViewDeviceInfo.Rows.Add("Device ID", deviceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading device info: " + ex.Message);
            }
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADBapp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                foreach (DataGridViewRow row in dataGridViewDeviceInfo.Rows)
                {
                    if (row.IsNewRow) continue;

                    string property = row.Cells["Property"].Value?.ToString() ?? "";
                    string value = row.Cells["Value"].Value?.ToString() ?? "";

                    string query = "INSERT INTO DeviceInfoTable (Property, Value) VALUES (@Property, @Value)";
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Property", property);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Device info saved to database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving device info: " + ex.Message);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report generation for device info not implemented yet.");
        }

        private string ExecuteADBCommand(string args)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using Process proc = Process.Start(psi)!;
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            return output;
        }

        private string ParseDeviceId(string output)
        {
            // Get the first line that ends with "device" and extract the ID
            string[] lines = output.Split('\n');
            foreach (string line in lines)
            {
                if (line.Contains("device") && !line.Contains("List of"))
                {
                    return line.Split('\t')[0];
                }
            }
            return "";
        }

        private void DeviceInfoForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
