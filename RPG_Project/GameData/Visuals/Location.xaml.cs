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
        Frame mainFrame;
        public Location(Frame frame)
        {
            mainFrame = frame;
            InitializeComponent();
        }

        private void LoadUpButtons()
        {
            SQLController sql = new SQLController();

            List<LocationModel> list = sql.queryAllLocation(CurrentSession.WorldId);

            foreach (LocationModel model in list)
            {
                Button button = new Button();
                button.Content = model.name;
                button.Name = model.name;
                button.Click =

                Grid.SetColumn(button, model.CoordianteY);
                Grid.SetRow(button, model.CoordianteX);

                Grid.Children.Add(button);
            } 
        }
    }
}
