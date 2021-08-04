using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SQLite;

namespace TestUserControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "database.db";

        static string databaseDir = Environment.CurrentDirectory;

        public static string databasePath = Path.Combine(databaseDir, databaseName);

        public static string connString = "Data Source=" + databasePath;

    }
}
