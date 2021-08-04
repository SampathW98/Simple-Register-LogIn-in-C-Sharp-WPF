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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace TestUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "SELECT * FROM UserDetails WHERE username=@un AND password=@pwd";
                command.Parameters.AddWithValue("@un", usernameTxt.Text);
                command.Parameters.AddWithValue("@pwd", pwdBox.Password);

                command.ExecuteNonQuery();

                //SQLiteDataReader reader = command.ExecuteReader();

                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("You are Logged In");
                }
                else
                {
                    MessageBox.Show("LogIn Failed");
                }
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow reg = new RegisterWindow();
            reg.Show();
            this.Close();
        }
    }
}
