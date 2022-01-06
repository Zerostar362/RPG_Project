using RPG_Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Logic.SQLcontroller
{
    internal class SQLController
    {
        SqlConnection con;
        string quote = "'";
        public SQLController() 
        {
        }

        private SqlDataReader CreateConnection(string command) 
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeros\Source\Repos\Zerostar362\RPG_Project\RPG_Project\GameData\GameData.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        private void CloseConnection() 
        {
            con.Close();
        }

        public string querySQLdataTostring(string command) 
        {
            string queryResult = "";
            SqlDataReader rd = CreateConnection(command);
            while (rd.Read() == true)
            {
                queryResult = rd.GetString(1) + queryResult;
            }
            rd.Close();

            this.CloseConnection();
            return queryResult;
        }

        public List<WorldModel> queryAllWorld() 
        {
            List<WorldModel> list = new List<WorldModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM WORLD");

            var type = typeof(WorldModel);

            while (rd.Read() == true)
            {
                WorldModel obj = (WorldModel)Activator.CreateInstance(type);
                obj.ID = Convert.ToInt32(rd["id"]);
                obj.name = Convert.ToString(rd["name"]);
                obj.CoordianteY = Convert.ToInt32(rd["CoordinateY"]);
                obj.CoordianteX = Convert.ToInt32(rd["CoordinateX"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public int queryAllWorld(string worldName)
        {
            int id = 0;
            SqlDataReader rd = this.CreateConnection("SELECT Id FROM WORLD where Name = " + quote + worldName.Trim() + quote);


            while (rd.Read() == true)
            {
                id = Convert.ToInt32(rd["id"]);
            }
            rd.Close();

            this.CloseConnection();
            return id;
        }

        public List<UserModel> queryAllUser() 
        {
            List<UserModel> list = new List<UserModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM USER");

            var type = typeof(UserModel);

            while (rd.Read() == true)
            {
                UserModel obj = (UserModel)Activator.CreateInstance(type);
                obj.Id = Convert.ToInt32(rd["id"]);
                obj.Username = Convert.ToString(rd["Username"]);
                obj.Password = Convert.ToString(rd["Password"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<MonsterModel> queryAllMonster() 
        {
            List<MonsterModel> list = new List<MonsterModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM MONSTERS");

            var type = typeof(MonsterModel);

            while (rd.Read() == true)
            {
                MonsterModel obj = (MonsterModel)Activator.CreateInstance(type);
                obj.Id = Convert.ToInt32(rd["id"]);
                obj.Name = Convert.ToString(rd["Name"]);
                obj.Class = Convert.ToInt32(rd["Class"]);
                obj.SpawnLocation1 = Convert.ToInt32(rd["SpawnLocation1"]);
                obj.SpawnLocation2 = Convert.ToInt32(rd["SpawnLocation2"]);
                obj.SpawnLocation3 = Convert.ToInt32(rd["SpawnLocation3"]);
                obj.Strength = Convert.ToInt32(rd["Strength"]);
                obj.Intelligence = Convert.ToInt32(rd["intelligence"]);
                obj.Dexterity = Convert.ToInt32(rd["Dexterity"]);
                obj.Experience = Convert.ToInt32(rd["Experience"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<LocationModel> queryAllLocation() 
        {
            List<LocationModel> list = new List<LocationModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM LOCATION");

            var type = typeof(LocationModel);

            while (rd.Read() == true)
            {
                LocationModel obj = (LocationModel)Activator.CreateInstance(type);
                obj.Id = Convert.ToInt32(rd["id"]);
                obj.Name = Convert.ToString(rd["Name"]);
                obj.WorldID = Convert.ToInt32(rd["WorldID"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<LocationModel> queryAllLocation(int WorldID)
        {
            List<LocationModel> list = new List<LocationModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM LOCATION where WORLDID = " + WorldID);

            var type = typeof(LocationModel);

            while (rd.Read() == true)
            {
                LocationModel obj = (LocationModel)Activator.CreateInstance(type);
                obj.Id = Convert.ToInt32(rd["id"]);
                obj.Name = Convert.ToString(rd["Name"]);
                obj.WorldID = Convert.ToInt32(rd["WorldID"]);
                obj.CoordinateX = Convert.ToInt32(rd["CoordinateX"]);
                obj.CoordinateY = Convert.ToInt32(rd["CoordinateY"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<ItemsModel> queryAllItems() 
        {
            List<ItemsModel> list = new List<ItemsModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM ITEMS");

            var type = typeof(ItemsModel);

            while (rd.Read() == true)
            {
                ItemsModel obj = (ItemsModel)Activator.CreateInstance(type);
                obj.id = Convert.ToInt32(rd["id"]);
                obj.name = Convert.ToString(rd["Name"]);
                obj.ItemType = Convert.ToInt32(rd["ItemType"]);
                obj.AvgDMG = Convert.ToInt32(rd["AvgDMG"]);
                obj.dmgRangePercentage = Convert.ToInt32(rd["dmgRangePercentage"]);
                obj.Strength = Convert.ToInt32(rd["Strength"]);
                obj.Intelligence =  Convert.ToInt32(rd["Intelligence"]);
                obj.Dexterity = Convert.ToInt32(rd["Dexterity"]);
                obj.Description = Convert.ToString(rd["Description"]);
                obj.minLvl = Convert.ToInt32(rd["minLvl"]);
                obj.Armor = Convert.ToInt32(rd["Armor"]);
                obj.Class1 = Convert.ToInt32(rd["Class1"]);
                obj.Class2 = Convert.ToInt32(rd["Class2"]);
                obj.Class3 = Convert.ToInt32(rd["Class3"]);
                obj.SpawnLocation1 = Convert.ToInt32(rd["SpawnLocation1"]);
                obj.SpawnLocation2 = Convert.ToInt32(rd["SpawnLocation2"]);
                obj.SpawnLocation3 = Convert.ToInt32(rd["SpawnLocation3"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<CharacterModel> queryAllCharacters()
        {
            List<CharacterModel> list = new List<CharacterModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM CHARACTERS");

            var type = typeof(CharacterModel);

            while (rd.Read() == true)
            {
                CharacterModel obj = (CharacterModel)Activator.CreateInstance(type);
                obj.id = Convert.ToInt32(rd["id"]);
                obj.name = Convert.ToString(rd["Name"]);
                obj.PlayerID = Convert.ToInt32(rd["PlayerID"]);
                obj.ClassID = Convert.ToInt32(rd["ClassID"]);
                obj.Money = Convert.ToInt32(rd["Money"]);
                obj.Level = Convert.ToInt32(rd["Level"]);
                obj.EXP = Convert.ToInt32(rd["EXP"]);
                obj.HP = Convert.ToInt32(rd["HP"]);
                obj.Intelligence = Convert.ToInt32(rd["Intelligence"]);
                obj.Strength = Convert.ToInt32(rd["Strength"]);
                obj.Dexterity = Convert.ToInt32(rd["Dexterity"]);
                obj.Description = Convert.ToString(rd["Description"]);
                obj.Helmet = Convert.ToInt32(rd["Helmet"]);
                obj.Torso = Convert.ToInt32(rd["Torso"]);
                obj.Legs = Convert.ToInt32(rd["Legs"]);
                obj.Boots = Convert.ToInt32(rd["boots"]);
                obj.Weapon = Convert.ToInt32(rd["Weapon"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public List<ClassModel> queryAllClasses()
        {
            List<ClassModel> list = new List<ClassModel>();
            SqlDataReader rd = this.CreateConnection("SELECT * FROM CLASS");

            var type = typeof(ClassModel);

            while (rd.Read() == true)
            {
                ClassModel obj = (ClassModel)Activator.CreateInstance(type);
                obj.id = Convert.ToInt32(rd["id"]);
                obj.ClassName = Convert.ToString(rd["Name"]);
                obj.Description = Convert.ToString(rd["WorldID"]);
                list.Add(obj);
            }
            rd.Close();

            this.CloseConnection();
            return list;
        }

        public void AppendRecordToTable<TypeValue>(string TableName, object model) 
        {

        }
    }
}
