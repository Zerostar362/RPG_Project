using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Logic.Install
{
    internal class Initializer
    {
        string mainDirectoryPath = @"C:\Users\" + Environment.UserName + @"\Documents\RPG";
        /// <summary>
        /// Pours init data and create directories
        /// </summary>
        private void Initialize() 
        {
            bool directories = CheckDirectories(true);
            CheckAndCreateFiles();

            if(directories == true) 
            {
                StartDataStream();
            }
        }

        public void InitOnStart() 
        {
            if(CheckDirectories() == false) 
            {
                Initialize();
            }

            LoadGameData();
        }

        /// <summary>
        /// Loads main game objects
        /// </summary>
        private void LoadGameData() 
        {
        }

        private void StartDataStream() 
        {
        }

        private void CheckAndCreateFiles() 
        {
            
        }

        private bool CheckDirectories(bool create = false) 
        {
            if(Directory.Exists(mainDirectoryPath + @"\Custom") & Directory.Exists(mainDirectoryPath + @"\INIT")){ return true; }

            if(!Directory.Exists(mainDirectoryPath + @"\Custom"))
            {
                if(create == true) 
                {
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Classes");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Characters");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Items");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Locations");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Monsters");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Player");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\Quests");
                    Directory.CreateDirectory(mainDirectoryPath + @"\Custom\World");
                }
            }

            if(!Directory.Exists(mainDirectoryPath + @"\INIT")) 
            {
                if(create == true) 
                {
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Classes");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Characters");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Items");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Locations");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Monsters");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Player");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\Quests");
                    Directory.CreateDirectory(mainDirectoryPath + @"\INIT\World");
                    return true;
                }
            }
            return false;
        }
    }
}
