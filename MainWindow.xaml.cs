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

namespace Powell_Oliver_Y12CSC_Project2System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create a new connection to the database
            var conn = new SQLiteConnection("Data Source=mondial.db");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //conect to the db
            //connection.Open();

        }
    }
}
