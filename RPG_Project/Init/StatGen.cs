using RPG_Project.Code.Extensions;
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Project.Init;

namespace RPG_Project.Init
{
    /// <summary>
    /// Generator for development purposes
    /// </summary>
    internal class StatGen 
    {
        SQLController sql;
        public StatGen() 
        {
            sql = new SQLController();
        }

        protected virtual void generateItemStats() 
        {

        }
    }
}
