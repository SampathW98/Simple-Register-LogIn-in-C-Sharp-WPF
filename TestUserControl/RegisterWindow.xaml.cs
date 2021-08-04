using System;
using System.Collections.Generic;
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
using TestUserControl.UserControl;

namespace TestUserControl
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();

            reg.FirstName = fnameTxt.Text;
            reg.LastName = lnameTxt.Text;
            reg.UserName = unameTxt.Text;
            reg.Pwd = pwdTxt.Text;

            Register.registerUser(reg);

            

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }
    }
}
