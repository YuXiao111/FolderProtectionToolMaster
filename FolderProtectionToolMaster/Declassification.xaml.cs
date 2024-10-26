using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace FolderProtectionToolMaster
{
    /// <summary>
    /// Declassification.xaml 的交互逻辑
    /// </summary>
    public partial class Declassification : Window
    {
        public string pass;
        public bool status;

        public Declassification()
        {
            InitializeComponent();
        }

        private void Encrypted_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Password_Txt.Password.Equals(pass))
            {
                status = true;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                this.DialogResult = false;
                MessageBox.Show("密码输入错误！", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
                status = false;
            }
        }
    }
}
