using RPG_Project.Code.Logic.Session;
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;
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

namespace RPG_Project.GameData.Visuals
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Page
    {
        public Location()
        { 
            this.ShowsNavigationUI = false;
            InitializeComponent();
            LoadUpButtons();
        }

        private void RedirectToTavern(object sender, RoutedEventArgs e)
        {
            string send = ((Button)sender).Name;

            //mainFrame.Navigate(new Tavern(mainFrame));
        }

        private void RedirectToMountains(object sender, RoutedEventArgs e)
        {
            string send = ((Button)sender).Name;

            //mainFrame.Navigate(new Tavern(mainFrame));
        }

        private void RedirectToPlains(object sender, RoutedEventArgs e)
        {
            string send = ((Button)sender).Name;

            //mainFrame.Navigate(new Tavern(mainFrame));
        }

        private void RedirectToBattleField(object sender, RoutedEventArgs e) 
        {
            string send = ((Button)sender).Name;

        }

        private RoutedEventHandler getCorrectMethod(string name) 
        {
            switch (name)
            {
                case string a when a.Contains("TAVERN"): return RedirectToTavern;
                case string b when b.Contains("MOUNTAINS"): return RedirectToBattleField;
                case string c when c.Contains("PLAINS"): return RedirectToBattleField;
                default: return null;
            }
        }

        private void LoadUpButtons()
        {
            SQLController sql = new SQLController();

            List<LocationModel> list = sql.queryLocation(CurrentSession.WorldId);

            foreach (LocationModel model in list)
            {
                Button button = new Button();
                button.Content = model.Name;
                button.Name = model.Name;
                button.Click += getCorrectMethod(model.Name);
                    
               //button.Click =

                Grid.SetColumn(button, model.CoordinateY);
                Grid.SetRow(button, model.CoordinateX);

                Grid.Children.Add(button);
            } 
        }
    }
}
