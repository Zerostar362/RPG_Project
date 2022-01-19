using RPG_Project.Code.Logic.SQLcontroller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Models
{
    public class CharacterModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int PlayerID { get; set; }
        public int ClassID { get; set; }
        public int Money { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }
        public int HP { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public string Description { get; set; }
        public int Helmet { get; set; }
        public int Torso { get; set; }
        public int Legs { get; set; }
        public int Boots { get; set; }
        public int Weapon { get; set; }

        private SQLController sql;
        /// <summary>
        /// PreLoads all items, so they dont have to be queried all the time
        /// </summary>

        public static List<CharacterModel> getCharactersList() 
        {
            SQLController sql = new SQLController();
            return sql.queryCharacters();
        }
        private void LoadUpItems() 
        {
            sql.queryItems();
        }
        /// <summary>
        /// gets Endurance attribute from all items
        /// </summary>
        /// <returns>sum of Endurance from items</returns>
        /*private int getItemEndurance() 
        {
            if(this.Helmet != 0) 
            {
            }
            if(this.Torso != 0) 
            {
            }
            if(this.Legs != 0) 
            {
            }
            if(this.Boots != 0) 
            {
            }
            if(Weapon != 0) 
            {
            }
        }*/
        /// <summary>
        /// Does the dmg Calculation
        /// </summary>
        /// <returns>DMG</returns>
        /*private int getWeaponDMG() 
        {
        }*/
        private void CalculateData_Warrior() 
        {
            //int EnduranceFromItems = getItemEndurance();
            //this.HP = Endurance * 4 * EnduranceFromItems;
        }

        private void CalculateData_Mage() 
        {

        }

        private void CalculateData_Archer() 
        {

        }
        private void DecideCalculation() 
        {
            switch (this.ClassID) 
            {
                case 1: CalculateData_Mage(); 
                    break;
                case 2: CalculateData_Warrior();
                    break;
                case 3: CalculateData_Archer();
                    break;
            }
        }
        public void AppendClassToDatabase() 
        {
            sql = new SQLController();
            sql.AppendRecordToTable(this);
        }
    }
}
