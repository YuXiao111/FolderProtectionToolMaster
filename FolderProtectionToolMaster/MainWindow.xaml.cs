using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Text;

namespace FolderProtectionToolMaster
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string status;
        string[] arr;
        private string _pathkey;
        private string SelectWindowPath = string.Empty;

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultval"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string defaultval, string filePath);

        //密码保存文件
        private static string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\FolderProtectionToolMaster.ini";

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultval"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern bool GetPrivateProfileString(string section, string key, string defaultval, StringBuilder stringBuilder, int size, string filePath);

        /// <summary>
        /// 加密后输入的密码
        /// </summary>
        public static string FolderPassword = string.Empty;
        private static string keyCounts = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            arr = new string[6];
            status = "";
            arr[0] = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}"; //window锁标识
        }
        public string pathkey
        {
            get { return _pathkey; }
            set { _pathkey = value; }
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Btn_Click(object sender, RoutedEventArgs e)
        {
            status = arr[0];

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(dialog.SelectedPath);
                    SelectWindowPath = directoryInfo.FullName;

                    if (dialog.SelectedPath.LastIndexOf(".{") == -1)
                    {
                        //加密文件夹
                        if (Encrypted_CB.IsChecked == true)
                        {
                            Encrypted encrypted = new Encrypted();
                            encrypted.path = dialog.SelectedPath;
                            encrypted.Owner = this;
                            bool? result = encrypted.ShowDialog();
                            if (result != true)
                            {
                                return;
                            }
                        }



                        if (!directoryInfo.Root.Equals(directoryInfo.Parent.FullName))
                        {
                            directoryInfo.MoveTo(directoryInfo.Parent.FullName + "\\" + directoryInfo.Name + status);//文件夹重命名
                        }
                        else
                        {
                            directoryInfo.MoveTo(directoryInfo.FullName + directoryInfo.Name + status);
                        }
                        File_Txt.Text = SelectWindowPath.TrimEnd('.');
                        string imagePath = "pack://application:,,,/Images/lock.jpg";
                        Picture.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                        Info_Txt.Text = "加锁成功";
                        Info_Txt.Foreground = Brushes.Red;

                        WritePrivateProfileString("FolderName_Password", Convert.ToString(File_Txt), FolderPassword, rootPath);
                        FolderNums();
                    }
                    else
                    {
                        //解密文件夹
                        status = getstatus(status);
                        bool s = checkpassword();

                        if (s)
                        {
                            File.Delete(dialog.SelectedPath + "\\p.xml");
                            directoryInfo.MoveTo(dialog.SelectedPath.Substring(0, dialog.SelectedPath.LastIndexOf(".")));
                            File_Txt.Text = dialog.SelectedPath.Substring(0, dialog.SelectedPath.LastIndexOf("."));

                            string imagePath = "pack://application:,,,/Images/unlock.jpg";
                            Picture.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                            Info_Txt.Text = "解锁成功";
                            Info_Txt.Foreground = Brushes.Green;

                            WritePrivateProfileString("FolderName_Password", Convert.ToString(File_Txt), null, rootPath);
                            FolderNums();
                        }
                    }

                }

                FolderNum.Text = keyCounts;
            }

        }




        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="selectedPath"></param>
        /// <returns></returns>
        private Boolean setpassword(string selectedPath)
        {

            return true;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string getstatus(string status)
        {
            //for (int i = 0; i < 6; i++)
            //    if (stat.LastIndexOf(arr[i]) != -1)
            //        stat = stat.Substring(stat.LastIndexOf("."));
            if (status.LastIndexOf(arr[0]) != -1)
                status = status.Substring(status.LastIndexOf("."));
            return status;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        private bool checkpassword()
        {
            XmlTextReader read;
            if (pathkey == null)
                read = new XmlTextReader(SelectWindowPath + "\\p.xml");
            else
                read = new XmlTextReader(pathkey + "\\p.xml");
            if (read.ReadState == ReadState.Error)
                return true;
            else
            {
                try
                {
                    while (read.Read())
                        if (read.NodeType == XmlNodeType.Text)
                        {
                            Declassification c = new Declassification();
                            c.pass = read.Value;
                            bool? result = c.ShowDialog();
                            if (result == true)
                            {
                                read.Close();
                                return c.status;
                            }

                        }
                }
                catch { return true; }

            }
            read.Close();
            return false;
        }

        static void FolderNums()
        {
            Dictionary<string, string> iniContents = ReadIniFile(rootPath);
            //int keyCount = iniContents.Count;
            keyCounts = iniContents.Count.ToString();

        }

        public static Dictionary<string, string> ReadIniFile(string filePath)
        {
            var result = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith(";") && !line.StartsWith("[") && line.Contains("="))
                    {
                        var parts = line.Split(new[] { '=' }, 2);
                        if (parts.Length == 2)
                        {
                            var key = parts[0].Trim();
                            var value = parts[1].Trim();
                            result[key] = value;
                        }
                    }
                }
            }
            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FolderNums();
            FolderNum.Text = keyCounts;
        }
    }
}
