using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Models
{
    internal class ItemsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ItemType { get; set; }
        public int AvgDMG { get; set; }
        public int dmgRangePercentage { get; set; }
        public int Endurance { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public string Description { get; set; }
        public int minLvl { get; set; }
        public int Armor { get; set; }
        public int Class1 { get; set; }
        public int Class2 { get; set; }
        public int Class3 { get; set; }
        public int SpawnLocation1 { get; set; }
        public int SpawnLocation2 { get; set; }
        public int SpawnLocation3 { get; set; }
    }
}
