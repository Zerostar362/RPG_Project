using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Models
{
    internal class CharacterModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int PlayerID { get; set; }
        public int ClassID { get; set; }
        public int Money { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }
        public int HP { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public string Description { get; set; }
        public int Helmet { get; set; }
        public int Torso { get; set; }
        public int Legs { get; set; }
        public int Boots { get; set; }
        public int Weapon { get; set; }
    }
}
