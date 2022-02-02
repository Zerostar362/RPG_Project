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

namespace RPG_Project.GameData.Visuals.Shop
{
    /// <summary>
    /// Interaction logic for ShopMainPage.xaml
    /// </summary>
    public partial class ShopMainPage : Page
    {
        SQLController sql;
        Random rng;
        public ShopMainPage()
        {
            rng = new Random();
            sql = new SQLController();
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                Button btn = new Button();
                btn.Content = getRandomItem();
                Grid.SetColumn(btn, i);
                ShopGrid.Children.Add(btn);
            }
        }

        private string getRandomItem()
        {
            ItemTemplateModel itemTemplate = new ItemTemplateModel();
            itemTemplate = sql.queryTemplate(rng.Next(1, 50));
            ItemsModel items = new ItemsModel();
            return itemTemplate.Name;
        }
    }
}
