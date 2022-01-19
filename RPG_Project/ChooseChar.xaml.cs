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
using RPG_Project.Code.Models;

namespace RPG_Project
{
    /// <summary>
    /// Interaction logic for ChooseChar.xaml
    /// </summary>
    public partial class ChooseChar : Page
    {

        public ChooseChar()
        {
            InitializeComponent();
            List<CharacterModel> list = CharacterModel.getCharactersList();
            int i = 0;
            foreach(var element in list) 
            {
                i++;
                TextBlock txt = new TextBlock();
                txt.Text = element.name;
                Grid.SetColumn(txt, 0);
                Grid.SetRow(txt, i);
                StackPanel_SubGrid.Children.Add(txt);

                TextBlock txtLvl = new TextBlock();
                txtLvl.Text = element.Level.ToString();
                Grid.SetColumn(txtLvl, 1);
                Grid.SetRow(txtLvl, i);
                StackPanel_SubGrid.Children.Add(txtLvl);

                TextBlock txtMoney = new TextBlock();
                txtMoney.Text = element.Money.ToString();
                Grid.SetColumn(txtMoney, 2);
                Grid.SetRow(txtMoney, i);
                StackPanel_SubGrid.Children.Add(txtMoney);

                //StackPanel_Main.Children.Add(StackPanel_SubGrid);
            }
            //StackPanel_Main.Children.Add(this);
            
        }
    }
}
