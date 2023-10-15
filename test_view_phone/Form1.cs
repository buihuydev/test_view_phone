using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_view_phone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread((ThreadStart)delegate
            {
                string deviceID = "749bcc7c";
                string deviceName = "SM-J810Y";              
                method_7(deviceID, deviceName);
            });
            thread2.IsBackground = true;
            thread2.Start();
        }
        private void method_7(string deviceID = "", string string_1 = "")
        {
            if (deviceID == "")
            {
                //nếu deviceID = null thì thực hiện lấy lại ở đây
                deviceID = "";
            }
            string windowText = $"MaxTikTok TDS/TTC | DeviceID : {deviceID}";
            string text3 = "scrcpy -s " + deviceID + " --window-title=\"" + windowText + "\"";
            text3 += $" --max-fps=60";
            //thực hiện view tại void này
            D22E1AB1(text3, 1);
            for (int i = 0; i < 30; i++)
            {
                if ((from FEB91717 in Process.GetProcessesByName("scrcpy")
                     where FEB91717.MainWindowTitle.Contains(deviceID)
                     select FEB91717).Count() > 0)
                {
                    break;
                }
                DelayTime(1.0);
            }
        }
        public static void DelayTime(double A9898F27)
        {
            Application.DoEvents();
            Thread.Sleep(Convert.ToInt32(A9898F27 * 1000.0));
        }
        public static string D22E1AB1(string CFA80123, int A8B7D59D = 10)
        {
            int num = 0;
            int num2 = 3;
            string result = "";
            try
            {
                string string_0;
                string E698B615;
                while (true)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/c " + Environment.GetEnvironmentVariable("ANDROID_HOME", EnvironmentVariableTarget.Machine) + "\\platform-tools\\" + CFA80123;
                    process.StartInfo.Verb = "runas";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                    string_0 = "";
                    process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            string_0 = string_0 + e.Data + "\n";
                        }
                    };
                    E698B615 = "";
                    process.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            E698B615 = E698B615 + e.Data + "\n";
                        }
                    };
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    bool flag = !process.WaitForExit((A8B7D59D >= 0) ? (A8B7D59D * 1000) : (-1));
                    process.Close();
                    if (flag && !CFA80123.StartsWith("scrcpy"))
                    {
                        if (num > 0 && num % num2 == 0)
                        {
                            smethod_2();
                        }
                        num++;
                        continue;
                    }
                    if (!(E698B615 != ""))
                    {
                        break;
                    }
                    if (E698B615.Contains("daemon not running") && !E698B615.Contains("daemon started successfully"))
                    {
                        continue;
                    }
                    if (Regex.Match(E698B615, "device (.*?) not found").Groups[1].Value != "")
                    {
                    }
                    break;
                }
                result = string_0.Trim();
            }
            catch
            {
            }
            return result;
        }
        public static void smethod_2()
        {
            try
            {
                RunCMD("taskkill /f /im adb.exe");
            }
            catch
            {
            }
        }
        public static string RunCMD(string string_1, int A908E9A9 = 10)
        {
            string result = "";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + string_1;
                process.StartInfo.Verb = "runas";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                StringBuilder stringBuilder_0 = new StringBuilder();
                process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        stringBuilder_0.Append(e.Data + "\n");
                    }
                };
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit((A908E9A9 < 0) ? (-1) : (A908E9A9 * 1000));
                process.Close();
                result = stringBuilder_0.ToString().Trim();
            }
            catch
            {
            }
            return result;
        }

    }
}
