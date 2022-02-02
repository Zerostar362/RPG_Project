using RPG_Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Logic.Session
{
    internal static class CurrentCharacter
    {
        public static int ID { get; set; }
        public static string Name { get; set; }
        public static int Level { get; set; }
        public static int money { get; set; }

        internal static void updateCurrentCharacter(int ID) 
        {
            SQLcontroller.SQLController sql = new SQLcontroller.SQLController();
            CharacterModel model = sql.queryCharacters(ID);
            CurrentCharacter.ID = model.id;
            CurrentCharacter.Name = model.name;
            CurrentCharacter.Level = model.Level;
            CurrentCharacter.money = model.Money;
        }

    }
}
