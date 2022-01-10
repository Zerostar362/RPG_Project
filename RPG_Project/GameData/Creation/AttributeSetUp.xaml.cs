using RPG_Project.Code.Logic.Session;
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
        CharacterModel model;

        public AttributeSetUp(CharacterModel charModel)
        {
            model = charModel;
            InitializeComponent();
            InitValues();
        }

        private void InitValues() 
        {
            TextBlock_Dexterity.Text = "1";
            TextBlock_Endurace.Text = "1";
            TextBlock_Intelligence.Text = "1";
            TextBlock_Strength.Text = "1";
            TextBlock_MaxPoints.Text = "20";
        }
        /// <summary>
        /// Increases or decreases value of max points
        /// </summary>
        /// <param name="Increase">if true, the number increases. If false, number decrease</param>
        private void updateMaxPoints_TextBlock(bool Increase) 
        {
            if(Increase == true) 
            {
                 int i  = Int32.Parse(TextBlock_MaxPoints.Text);
                 TextBlock_MaxPoints.Text = (++i).ToString();
            }
            else 
            {
                int i = Int32.Parse(TextBlock_MaxPoints.Text);
                TextBlock_MaxPoints.Text = (--i).ToString();
            }
        }

        private void IncValue(object sender) 
        {
            string name = ((Button)sender).Name;
            switch (name) 
            {
                case string a when name.Contains("Intelligence"): 
                {
                        if (TextBlock_MaxPoints.Text != "0")
                        {
                            int i = Int32.Parse(TextBlock_Intelligence.Text);
                            i++;
                            TextBlock_Intelligence.Text = i.ToString();
                            updateMaxPoints_TextBlock(false);
                        }
                }
                break;
                case string b when name.Contains("Strength"):
                    {
                        if (TextBlock_MaxPoints.Text != "0")
                        {
                            int i = Int32.Parse(TextBlock_Strength.Text);
                            i++;
                            TextBlock_Strength.Text = i.ToString();
                            updateMaxPoints_TextBlock(false);
                        }
                    }
                    break;
                case string c when name.Contains("Dexterity"):
                    {
                        if (TextBlock_MaxPoints.Text != "0")
                        {
                            int i = Int32.Parse(TextBlock_Dexterity.Text);
                            i++;
                            TextBlock_Dexterity.Text = i.ToString();
                            updateMaxPoints_TextBlock(false);
                        }
                    }
                    break;
                case string c when name.Contains("Endurance"):
                    {
                        if (TextBlock_MaxPoints.Text != "0")
                        {
                            int i = Int32.Parse(TextBlock_Endurace.Text);
                            i++;
                            TextBlock_Endurace.Text = i.ToString();
                            updateMaxPoints_TextBlock(false);
                        }
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
                        updateMaxPoints_TextBlock(true);
                    }
                    break;
                case string b when name.Contains("Strength"):
                    {
                        int i = Int32.Parse(TextBlock_Strength.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Strength.Text = i.ToString();
                        updateMaxPoints_TextBlock(true);
                    }
                    break;
                case string c when name.Contains("Dexterity"):
                    {
                        int i = Int32.Parse(TextBlock_Dexterity.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Dexterity.Text = i.ToString();
                        updateMaxPoints_TextBlock(true);
                    }
                    break;
                case string c when name.Contains("Endurance"):
                    {
                        int i = Int32.Parse(TextBlock_Endurace.Text);
                        if (i == 1) { break; }
                        i--;
                        TextBlock_Endurace.Text = i.ToString();
                        updateMaxPoints_TextBlock(true);
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
            model.Strength     = Int32.Parse(TextBlock_Strength.Text);
            model.Intelligence = Int32.Parse(TextBlock_Intelligence.Text);
            model.Endurance = Int32.Parse(TextBlock_Endurace.Text);
            model.Dexterity = Int32.Parse(TextBlock_Dexterity.Text);

            model.AppendClassToDatabase();
            CurrentSession.clearMainFrameMemory();
        }
    }
}
