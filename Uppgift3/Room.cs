using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Room
    {
        //Properties that are needed
        public string Title { get; set; }
        public string Description {
            get {
                _description = defaulDescription;
                foreach (Item item in items)
                {
                    _description += "There is a " + item.Name + " in here. ";
                }
                foreach (Creature creature in creatures)
                {
                    _description += "There is a " + creature.Name + " here. ";
                }
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private string defaulDescription;
        private string _description;

        private List<Item> items;
        private List<Challenge> challenges;
        private List<Creature> creatures;

        //Possible exits 
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public Room(string title, string description)
        {
            Title = title;
            defaulDescription = description;
            items = new List<Item>();
            challenges = new List<Challenge>();
            creatures = new List<Creature>();
        }

        // ADDERS AND GETTERS
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public List<Item> GetItems()
        {
            return items;
        }
        public void AddChallenge(Challenge challenge)
        {
            challenges.Add(challenge);
        }
        public List<Challenge> GetChallenges()
        {
            return challenges;
        }
        public void AddCreature(Creature creature)
        {
            creatures.Add(creature);
        }
        public List<Creature> GetCreatures()
        {
            return creatures;
        }
    }
}
