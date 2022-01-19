using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;

namespace RPG_Project.Code.Logic.Session
{
    public static class CurrentSession
    {
        public static int WorldId { get; set; }
        public static int LocationID { get; set; }
        public static int CharacterID { get; set; }
        public static int PlayerID { get; set; }
        public static int CharLvl { get; set; }

        public static Frame mainFrame;

        private static SQLController sql = new SQLController();

        public static void Initiate(Frame frame) 
        {
            mainFrame = frame;
            //only for dev purpose
            PlayerID = 1;
            mainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        public static void clearMainFrameMemory() 
        {
            if (!mainFrame.CanGoBack && !mainFrame.CanGoForward)
            {
                return;
            }

            var entry = mainFrame.RemoveBackEntry();
            while (entry != null)
            {
                entry = mainFrame.RemoveBackEntry();
            }
        }

        public static void setWorldId(string worldName) 
        {
            WorldId = sql.queryWorld(worldName);
        }

        public static void updateCurrentCharacter() 
        {

        }
    }
}
