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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<String>> TablesToCreate = new Dictionary<string, List<String>>()
            { { "Supplier",new List<String>() { "SupplierID~IPA", "Contact~V064N", "ShippingState~V064" , "Title~V020N" } },
            { "Order",new List<String>() { "OrderID~IPA", "SupplierID~IF", "Subtotal~CN" , "ArrivalDate~D" } },
            { "Item",new List<String>() {"ProductID~IF", "OrderID~IF", "Quatnity~IN" , "ShippingCost~CN", "Total~CN" } },
            { "Product",new List<String>() { "ProductID~IPA", "SeriesID~IF", "Name~TN", "Description~T", "Type~V032N", "Colour~V032N", "Size~V032N", "UnitCost~CN" , "Discount~IN" } },
            { "Series",new List<String>() { "SeriesID~IPA", "EmployeeID~IF", "Name~TN", "Description~TN", "TotalProducts~V020N", "StartDate~D"} },
            { "Customer",new List<String>() { "CustomerID~IPA","FirstName~V020N","LastName~V020N", "PostCode~IN" , "ContactInfo~T064N" } },
            { "Employee",new List<String>() { "EmployeeID~IPA", "FirstName~V020N","LastName~V020N","JobTitle~V020N", "PostCode~IN" , "ContactInfo~T064N" } },
            { "Social",new List<String>() { "SocialID~IPA","EmployeeID~IF","Name~V040N","Type~V020N"} }, };
            Dictionary<char, string> DataTypes = new Dictionary<char, string>() 
            { { 'I', "INTEGER" },{ 'A', "AUTOINCREMENT" },{ 'P', "PRIMARY KEY" },{ 'A', "AUTOINCREMENT" },{ 'T', "TEXT" },{ 'N', "NOT NULL" },{ 'C', "DOUBLE(20,2)" },{ 'D', "DATE" }};
            /* 
             * V003 - Var Char(3)
             * F - foreign key
             */
            //Setting up the database tables
            foreach (var Tb in TablesToCreate.Keys)
            {
                string toQuery = "";
                string AtName;
                string AtConstraints;
                toQuery += $"DROP TABLE IF EXISTS {Tb}";
                foreach (string Attr in TablesToCreate[Tb])
                {
                    AtName  = Attr.Split('~')[0];
                    AtConstraints = Attr.Split('~')[1];
                    System.Diagnostics.Debug.WriteLine($"{AtName} and {AtConstraints}");
                }
            }
        }
        public static void QueryDatabase(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=fuelwatch.db"))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand Query = new SQLiteCommand(query, connection);
                    Query.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    connection.Close();
                    return;
                }
            }
        }

    }
}
