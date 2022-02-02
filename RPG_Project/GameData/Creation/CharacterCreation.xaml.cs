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

namespace RPG_Project.GameData.Creation
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page
    {
        public CharacterCreation()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if(TextBlock_UsernameUsed.Text == "Username is already in use") 
            {
                return;
            }
            if(NameBox.Text != "" && ComboBox.Text != "Choose your class") 
            {
                CharacterModel characterModel = new CharacterModel();
                //should be done in multithread to speed things up Task.Run(()=> {});
                    characterModel.name = NameBox.Text.Trim();
                    characterModel.ClassID = SQLController.queryClass(ComboBox.Text);
                    //default new character values-------------------------------
                    characterModel.Money = 10;
                    characterModel.Level = 1;
                    characterModel.EXP = 0;
                    characterModel.HP = 100;
                    //-----------------------------------------------------------
                    //only for test purposes ------------------------------------
                    characterModel.PlayerID = 1;
                characterModel.Description = "empty";
                    //--------------------------------------------------------------
                CurrentSession.mainFrame.Navigate(new AttributeSetUp(characterModel));
            }
            else 
            {
                AlerText.Text = "Wrong selection of username or class";
            }
        }

        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(SQLController.isInCharacters(NameBox.Text) == true) 
            {
                TextBlock_UsernameUsed.Text = "Username is already in use";
            }
            else 
            {
                TextBlock_UsernameUsed.Text = string.Empty;
            }
        }
    }
}
