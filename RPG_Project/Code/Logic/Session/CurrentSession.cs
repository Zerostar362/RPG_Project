using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;

namespace RPG_Project.Code.Logic.Session
{
    public static class CurrentSession
    {
        public static int WorldId { get; set; }
        public static int LocationID { get; set; }

        private static SQLController sql;

        public static void Initiate() 
        {
            sql = new SQLController();
        }

        public static void setWorldId(string worldName) 
        {
            WorldId = sql.queryAllWorld(worldName);
        }
    }
}
