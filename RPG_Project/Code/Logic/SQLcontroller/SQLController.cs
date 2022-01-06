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
        /// <summary>
        /// Creates connection with localDB and executes command
        /// </summary>
        /// <param name="command">Query command for localDB</param>
        /// <returns></returns>
        private SqlDataReader CreateConnection(string command) 
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeros\Source\Repos\Zerostar362\RPG_Project\RPG_Project\GameData\GameData.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// Closes connection to localDB
        /// </summary>
        private void CloseConnection() 
        {
            con.Close();
        }
        /// <summary>
        /// Query and valid SQL string
        /// </summary>
        /// <param name="command">SQL query</param>
        /// <returns></returns>
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
        /// <summary>
        /// SQL query to the world table
        /// </summary>
        /// <returns>List of WorldModel objects, they represent every record in localDB</returns>
        public List<WorldModel> queryWorld() 
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
        /// <summary>
        /// Queries for worldName in localDB
        /// </summary>
        /// <param name="worldName">World name</param>
        /// <returns>record ID</returns>
        public int queryWorld(string worldName)
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
        /// <summary>
        /// SQL query for User table
        /// </summary>
        /// <returns>List of UserModel object, they represent every record in table</returns>
        public List<UserModel> queryUser() 
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
        /// <summary>
        /// SQL query to monster table
        /// </summary>
        /// <returns>List of all monsters</returns>
        public List<MonsterModel> queryMonster() 
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
        /// <summary>
        /// SQL query to location table
        /// </summary>
        /// <returns>List of LocationModel object</returns>
        public List<LocationModel> queryLocation() 
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
        /// <summary>
        /// SQL query to location table
        /// </summary>
        /// <param name="WorldID">ID of the world</param>
        /// <returns>returns List of location correseponding to WorldID param</returns>
        public List<LocationModel> queryLocation(int WorldID)
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

        public List<ItemsModel> queryItems() 
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

        public List<CharacterModel> queryCharacters()
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

        public List<ClassModel> queryClass()
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

        public int queryClass(string ClassName) 
        {
            return 5;
        }

        public void AppendRecordToTable(CharacterModel model) 
        {
            string query = "INSERT INTO Characters (Name, PlayerID, ClassID, Money, Level, EXP, HP, Endurance, Intelligence, " +
                "Strength, Dexterity, Description)" +
                $"VALUES({model.name},{model.PlayerID},{model.ClassID},{model.Money},{model.Level},{model.EXP},{model.HP},{model.Endurance}," +
                $"{model.Intelligence},{model.Strength},{model.Dexterity},{model.Description})";
            SqlDataReader rd = this.CreateConnection(query);
        }

        public void AppendRecordToTable(ItemsModel model)
        {
            string query = "INSERT INTO Characters (Name, ItemType, AvgDMG, dmgRangePercentage,Endurance, Strength, Intelligence, Dexterity, Description, minLvl, " +
                "Armor, Class1, Class2, Class3,SpawnLocation1, SpawnLocation2, SpawnLocation 3)" +
                $"VALUES({model.name},{model.ItemType},{model.AvgDMG},{model.dmgRangePercentage},{model.Endurance},{model.Strength},{model.Intelligence},{model.Dexterity},{model.Description}," +
                $"{model.minLvl},{model.Armor},{model.Class1},{model.Class2},{model.Class3},{model.SpawnLocation1},{model.SpawnLocation2},{model.SpawnLocation3})";
            SqlDataReader rd = this.CreateConnection(query);
        }

        public void AppendRecordToTable(MonsterModel model)
        {
            string query = "INSERT INTO Characters (Name, Class, SpawnLocation1, SpawnLocation2, SpawnLocation3, Endurance,Strength, Intelligence, Dexterity, Experience, " +
                "WorldSpawn)" +
                $"VALUES({model.Name},{model.Class},{model.SpawnLocation1},{model.SpawnLocation2},{model.SpawnLocation3},{model.Endurance},{model.Strength},{model.Intelligence}," +
                $"{model.Dexterity},{model.Experience},{model.WorldSpawn})";
            SqlDataReader rd = this.CreateConnection(query);
        }
    }
}
