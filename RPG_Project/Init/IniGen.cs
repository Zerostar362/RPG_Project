using RPG_Project.Code.Extensions;
using RPG_Project.Code.Logic.SQLcontroller;
using RPG_Project.Code.Models;
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
        private ItemsModel item;
        private const double mageItemKoef = 1.3;
        private const double mageWeaponKoef = 2.8;

        private const double warriorItemKoef = 2.1;
        private const double warriorWeaponKoef = 1.4;

        private const double ArcherItemKoef = 1.6;
        private const double ArcherWeaponKoef = 1.9;

        private double itemKoef;
        private double coef;
        private double coef2;
        private double coef3;

        public IniGen()
        {
            sql = new SQLController();
            generateItems();
            GenerateMonsters();
        }

        private int setMainAttr() 
        {
            switch (item.Class1) 
            {
                case 1: return 1; //mage
                case 2: return 2; //war
                case 3: return 3; //arch
                default: return 0;//default
            }
        }

        private int getAttribute(int Attribute) 
        {
            const int Dexterity = 1;
            const int Strength = 2;
            const int Intelligence = 3;
            const int Endurace = 4;

            switch (Attribute) 
            {
                case 1:
                    return item.Dexterity; 
                case 2:
                    return item.Strength; 
                case 3:
                    return item.Intelligence;
                case 4:
                    return item.Endurance;
                default: return 0;
            }
        }

        private int getAttributeByClass() 
        {
            switch (item.Class1) 
            {
                case 1:
                    return item.Intelligence;
                case 2:
                    return item.Strength;
                case 3:
                    return item.Dexterity;
                default: return 0;
            }
        }

        private void setAttributeByClass(int Attribute) 
        {
            switch (item.Class1)
            {
                case 1:
                    item.Intelligence = Attribute;
                    break;
                case 2:
                     item.Strength = Attribute;
                    break;
                case 3:
                     item.Dexterity = Attribute;
                    break;
            }
        }

        private void SetAttribute(int Attribute) 
        {
            const int Dexterity = 1;
            const int Strength = 2;
            const int Intelligence = 3;
            const int Endurace = 4;

            switch (Attribute)
            {
                case 1:
                    item.Dexterity = Attribute;
                    break;
                case 2:
                     item.Strength = Attribute;
                    break;
                case 3:
                     item.Intelligence = Attribute;
                    break;
                case 4:
                     item.Endurance = Attribute;
                    break;
            }
        }

        private void setStats()
        {
            Random rng = new Random();
            double itemLvlDb = Convert.ToDouble(item.minLvl);
            int maxNum = 0;
            int minNum = 0;
            List<int> usedNums = new List<int>();

            item.Armor = Convert.ToInt32(Math.Round(itemLvlDb * itemKoef * (coef * ((1 / coef2) + (1 / coef3)))));

            for (int i = 0; i < 3; i++) {
                if (i == 0) { maxNum = setMainAttr(); minNum = setMainAttr(); }
                else { minNum = 0; maxNum = 5; }
                switch (rng.Next(minNum, maxNum))
                {
                    case 1:
                        { item.Dexterity = Convert.ToInt32(Math.Round(Convert.ToDouble(item.minLvl * (rng.Next(2, item.minLvl * 2))))); usedNums.Add(1); }
                        break;
                    case 2: 
                        { item.Strength = Convert.ToInt32(Math.Round(Convert.ToDouble(item.minLvl * (rng.Next(2, item.minLvl * 2))))); usedNums.Add(2); }
                        break;
                    case 3:
                        { item.Intelligence = Convert.ToInt32(Math.Round(Convert.ToDouble(item.minLvl * (rng.Next(2, item.minLvl * 2))))); usedNums.Add(3); }
                            break;
                    case 4:
                        { item.Endurance = Convert.ToInt32(Math.Round(Convert.ToDouble(item.minLvl * (rng.Next(2, item.minLvl * 2))))); usedNums.Add(4); }
                        break;
                    default: break;
                }
            } 
            if(usedNums.Count == 1) 
            {
                foreach(var element in usedNums) 
                {
                    SetAttribute(getAttribute(element) * 4);
                }
            }
            else 
            {
                if(usedNums.Count == 2) 
                {
                    foreach (var element in usedNums) 
                    {
                        SetAttribute(getAttribute(element) * 4);
                    }
                }
            }
        }
        private void setKoefs(double itemKoeficient) 
        {
            itemKoef = itemKoeficient;
            coef2 = 1;
            coef3 = 1;
            switch (item.Class1)
            {
                case 1: coef = mageItemKoef;
                    break;
                case 2: coef = warriorItemKoef;
                    break;
                case 3: coef = ArcherItemKoef;
                    break;
            }
            if (item.Class2 != 0 || item.Class3 != 0) 
            {
                switch (item.Class2)
                {
                    case 1:
                        coef2 = mageItemKoef;
                        break;
                    case 2:
                        coef2 = warriorItemKoef;
                        break;
                    case 3:
                        coef2 = ArcherItemKoef;
                        break;
                    default: coef2 = 1;
                        break;
                }

                switch (item.Class3)
                {
                    case 1:
                        coef3 = mageItemKoef;
                        break;
                    case 2:
                        coef3 = warriorItemKoef;
                        break;
                    case 3:
                        coef3 = ArcherItemKoef;
                        break;
                    default: coef3 = 1;
                        break;
                }
            }

            this.setStats();
        }
        private void setWeaponStats() 
        {
            //class 1 = mage
            //class 2 = warrior
            //class 3 = archer
            //weapong cannot have a defence attribute, except endurace. So they can have only dmg attribute and endurace
            Random random = new Random();
            item.Armor = 0;
            
            int Attr = getAttributeByClass();
            double koef;

            switch (item.Class1) 
            {
                case 1: koef = mageWeaponKoef;
                    break;
                case 2: koef = warriorWeaponKoef;
                    break;
                case 3: koef = ArcherWeaponKoef;
                    break;
                default: koef = 1;
                    break;
            }

            Attr = ((item.minLvl.ToDouble()) * koef * (2.ToDouble())).ToInt();
            setAttributeByClass(Attr);

            item.AvgDMG = Convert.ToInt32(item.minLvl.ToDouble() * koef + (Attr.ToDouble() / 2));
            item.dmgRangePercentage = random.Next(0,35);


        }
        private void generateItems()
        {
            //ItemType 1 = Helmet
            //ItemType 2 = Torso
            //ItemType 3 = Legs
            //ItemType 4 = Boots
            //ItemType 5 = Weapon
            Random random = new Random();
            ItemsModel items = new ItemsModel();
            items.minLvl = random.Next(1,10);
            items.ItemType = random.Next(1,5);
            items.Class1 = random.Next(1,3);
            items.Class2 = random.Next(1, 7);
            item.Class3 = random.Next(1, 17); 
            if(items.Class2 > 3) { items.Class2 = 0; }
            if(items.Class3 > 3) { items.Class3 = 0; }
            item = items;
            switch (items.ItemType) 
            {
                case 1: setKoefs(1.4);
                    break;
                case 2: setKoefs(2.2);
                    break;
                case 3: setKoefs(1.7);
                    break;
                case 4: setKoefs(1.1);
                    break;
                case 5: setWeaponStats();
                    break;
            }
                
        }
        private void GenerateMonsters() 
        {
            MonsterModel monster = new MonsterModel();
        }
    }
}
