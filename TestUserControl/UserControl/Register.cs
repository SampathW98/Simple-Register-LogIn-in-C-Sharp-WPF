using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace TestUserControl.UserControl
{
    class Register
    {
        private String fname;
        private String lname;
        private String uname;
        private string pwd;

        public Register () { }

        public Register(String fname, String lname, String uname, String pwd)
        {
            this.fname = fname;
            this.lname = lname;
            this.uname = uname;
            this.pwd = pwd;
        }

        public String FirstName { get => fname; set => fname = value; }

        public String LastName { get => lname; set => lname = value; }

        public String UserName { get => uname; set => uname = value; }

        public String Pwd { get => pwd; set => pwd = value; }

        public static void registerUser(Register register)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "INSERT INTO UserDetails(fname,lname,username,password) VALUES (@fname,@lname,@uname,@pwd)";

                command.Parameters.AddWithValue("@fname", register.FirstName);
                command.Parameters.AddWithValue("@lname", register.LastName);
                command.Parameters.AddWithValue("@uname", register.UserName);
                command.Parameters.AddWithValue("@pwd", register.Pwd);

                command.ExecuteNonQuery();

                MessageBox.Show("Added Successfully");

            }
        }


    }
}
