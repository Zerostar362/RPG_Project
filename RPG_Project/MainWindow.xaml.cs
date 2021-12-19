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
using System.IO;
using System.Data.SqlClient;

namespace RPG_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Adam\Source\Repos\Zerostar362\RPG_Project\RPG_Project\GameData\GameData.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * From World", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read() == true)
            {
                midTextBlock.Text = rd.GetString(1) + midTextBlock.Text;
            }
            con.Close();
            rd.Close();
        }

        private void OnClick_ExitButton(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
