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
            if(NameBox.Text != "" && ComboBox.Text != "Choose your class") 
            {
                int x;
                CharacterModel characterModel = new CharacterModel();
                //should be done in multithread to speed things up Task.Run(()=> {});
                characterModel.name = NameBox.Text.Trim();
                Task.Run(() => { characterModel.ClassID = { }; }); 
                CurrentSession.mainFrame.Navigate(new AttributeSetUp(characterModel));
            }
            else 
            {
                AlerText.Text = "Wrong selection of username or class";
            }
        }
    }
}
