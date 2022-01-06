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

namespace RPG_Project.GameData.Creation
{
    /// <summary>
    /// Interaction logic for AttributeSetUp.xaml
    /// </summary>
    public partial class AttributeSetUp : Page
    {
        CharacterModel charModel;

        public AttributeSetUp(CharacterModel model)
        {
            charModel = model;
            InitializeComponent();
            InitValues();
        }

        private void InitValues() 
        {
            TextBlock_Dexterity.Text = "1";
            TextBlock_Endurace.Text = "1";
            TextBlock_Intelligence.Text = "1";
            TextBlock_Strength.Text = "1";
        }

        private void IncValue(object sender) 
        {
            string name = ((Button)sender).Name;
            switch (name) 
            {
                case string a when name.Contains("Intelligence"): 
                {
                    int i = Int32.Parse(TextBlock_Intelligence.Text);
                    i++;
                    TextBlock_Intelligence.Text = i.ToString();
                }
                break;
                case string b when name.Contains("Strength"):
                    {
                        int i = Int32.Parse(TextBlock_Strength.Text);
                        i++;
                        TextBlock_Strength.Text = i.ToString();
                    }
                    break;
                case string c when name.Contains("Dexterity"):
                    {
                        int i = Int32.Parse(TextBlock_Dexterity.Text);
                        i++;
                        TextBlock_Dexterity.Text = i.ToString();
                    }
                    break;
                case string c when name.Contains("Endurance"):
                    {
                        int i = Int32.Parse(TextBlock_Endurace.Text);
                        i++;
                        TextBlock_Endurace.Text = i.ToString();
                    }
                    break;
            }
        }

        private void DecValue(object sender)
        {
            string name = ((Button)sender).Name;
            switch (name)
            {
                case string a when name.Contains("Intelligence"):
                    {
                        int i = Int32.Parse(TextBlock_Intelligence.Text);
                        if(i == 1) { break; }
                        i--;
                        TextBlock_Intelligence.Text = i.ToString();
                    }
                    break;
                case string b when name.Contains("Strength"):
                    {
                        int i = Int32.Parse(TextBlock_Strength.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Strength.Text = i.ToString();
                    }
                    break;
                case string c when name.Contains("Dexterity"):
                    {
                        int i = Int32.Parse(TextBlock_Dexterity.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Dexterity.Text = i.ToString();
                    }
                    break;
                case string c when name.Contains("Endurance"):
                    {
                        int i = Int32.Parse(TextBlock_Endurace.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Endurace.Text = i.ToString();
                    }
                    break;
            }
        }

        private void onPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            IncValue(sender);
        }

        private void onMinus_Button_Click(object sender, RoutedEventArgs e)
        {
            DecValue(sender);
        }

        private void onSubmit_Button_Click(object sender, RoutedEventArgs e) 
        {

        }
    }
}
