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

namespace RPG_Project.GameData.FightArena
{
    /// <summary>
    /// Interaction logic for FightArena.xaml
    /// </summary>
    public partial class FightArena : Page
    {
        public FightArena()
        {
            InitializeComponent();
            Task.Run(() => set_PlayerStat_TextBox());
            Task.Run(() => set_MonsterStat_TextBox());
            Task.Run(() => generate_PlayerSpells_Button());
        }

        private void set_PlayerStat_TextBox() 
        {
            //Player_Stat_TextBlock.Text = 
        }

        private void set_MonsterStat_TextBox() 
        {

        }

        private void generate_PlayerSpells_Button() 
        {

        }
    }
}
