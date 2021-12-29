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
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;
using RPG_Project.Code.Logic.Session;

namespace RPG_Project.GameData.Visuals
{
    /// <summary>
    /// Interaction logic for WorldMap.xaml
    /// </summary>
    public partial class WorldMap : Page
    {
        Frame mainFrame;
        public WorldMap(Frame frame)
        {
            InitializeComponent();
            LoadUpButtons();
        }

        private void RedirectToLocation(object sender, RoutedEventArgs e) 
        {
            string send = ((Button)sender).Name;

            CurrentSession.setWorldId(send);

            mainFrame.Navigate(new Location(mainFrame));
        }

        private void LoadUpButtons() 
        {
            SQLController sql = new SQLController();

            List<WorldModel> list = sql.queryAllWorld();

            foreach (WorldModel model in list) 
            {
                Button button = new Button();
                button.Content = model.name;
                button.Name = model.name;
                button.Click += RedirectToLocation;
                button.Tag = model.ID;

                Grid.SetColumn(button, model.CoordianteY);
                Grid.SetRow(button, model.CoordianteX);

                Grid.Children.Add(button);
            }
        }
    }
}
