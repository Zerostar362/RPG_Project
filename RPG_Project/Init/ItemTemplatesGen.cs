using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Project.Code.Models;
using RPG_Project.Code.Logic.SQLcontroller;

namespace RPG_Project.Init
{
    internal class ItemTemplatesGen
    {
        string[] adjectives = { "Crazy", "Blind", "Electric", "Fireproof", "Massive", "Shining", "Stolen", "Magical", "Evil",
            "Saint", "Transforming", "Forged", "Muscularity", "Heavy", "Weightless","Agile", "Fast", "Flexible", "Relentless" };
        string[] nouns = { "Magic", "Arcane", "Mana","Strong", "Muscular", "Frightening", "Doom", "Bow", "Plate", "Crossbow" };
        
        public void generateTemplate() 
        {
            List<ItemTemplateModel> templates = new List<ItemTemplateModel>();
            Random rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                string adj = adjectives[rng.Next(0, adjectives.Length - 1)];
                string noun = nouns[rng.Next(0, nouns.Length - 1)];
                ItemTemplateModel model = new ItemTemplateModel();
                model.Name = $"{adj} {noun}";
                model.ItemType = 1;
                templates.Add(model);
            }

            for (int i = 0; i < 10; i++)
            {
                string adj = adjectives[rng.Next(0, adjectives.Length - 1)];
                string noun = nouns[rng.Next(0, nouns.Length - 1)];
                ItemTemplateModel model = new ItemTemplateModel();
                model.Name = $"{adj} {noun}";
                model.ItemType = 2;
                templates.Add(model);
            }

            for (int i = 0; i < 10; i++)
            {
                string adj = adjectives[rng.Next(0, adjectives.Length - 1)];
                string noun = nouns[rng.Next(0, nouns.Length - 1)];
                ItemTemplateModel model = new ItemTemplateModel();
                model.Name = $"{adj} {noun}";
                model.ItemType = 3;
                templates.Add(model);
            }

            for (int i = 0; i < 10; i++)
            {
                string adj = adjectives[rng.Next(0, adjectives.Length - 1)];
                string noun = nouns[rng.Next(0, nouns.Length - 1)];
                ItemTemplateModel model = new ItemTemplateModel();
                model.Name = $"{adj} {noun}";
                model.ItemType = 4;
                templates.Add(model);
            }

            for (int i = 0; i < 10; i++)
            {
                string adj = adjectives[rng.Next(0, adjectives.Length - 1)];
                string noun = nouns[rng.Next(0, nouns.Length - 1)];
                ItemTemplateModel model = new ItemTemplateModel();
                model.Name = $"{adj} {noun}";
                model.ItemType = 5;
                templates.Add(model);
            }

            SQLController.AppendRecordToTable(templates);

        }
    }
}
