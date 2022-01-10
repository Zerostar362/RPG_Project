using RPG_Project.Code.Logic.SQLcontroller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Init
{
    /// <summary>
    /// Generator for development purposes
    /// </summary>
    internal class IniGen
    {
        SQLController sql;

        public IniGen() 
        {
            sql = new SQLController();
            generateItems();
            GenerateMonsters();
        }
        private void generateItems()
        {

        }
        private void GenerateMonsters() 
        {

        }
    }
}
