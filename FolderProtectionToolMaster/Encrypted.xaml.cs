using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace FolderProtectionToolMaster
{
    /// <summary>
    /// Encrypted.xaml 的交互逻辑
    /// </summary>
    public partial class Encrypted : Window
    {
        public string path;
        public Encrypted()
        {
            InitializeComponent();
        }


        private void Encrypted_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password1.Password))
            {
                MessageBox.Show("请填写密码！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(Password2.Password))
            {
                MessageBox.Show("请再次填写密码！", "提示", MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            if (Password1.Password.Equals(Password2.Password))
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem;
                XmlNode xmlnode;
                XmlText xmltext;
                xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                xmldoc.AppendChild(xmlnode);
                xmlelem = xmldoc.CreateElement("", "ROOT", "");
                xmltext = xmldoc.CreateTextNode(Password1.Password);
                xmlelem.AppendChild(xmltext);
                xmldoc.AppendChild(xmlelem);
                xmldoc.Save(path + "\\p.xml");
                this.DialogResult = true;
                MainWindow.FolderPassword = Password1.Password;
                this.Close();
            }
            else
            {
                MessageBox.Show("输入两次的密码不一致，请重新输入！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                Password1.Password = string.Empty;
                Password2.Password = string.Empty; 
                Password1.Focus();
            }
        }

    }
}
