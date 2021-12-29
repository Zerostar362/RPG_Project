using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Models
{
    internal class MonsterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int SpawnLocation1 { get; set; }
        public int SpawnLocation2 { get; set; }
        public int SpawnLocation3 { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Experience { get; set; }
    }
}
