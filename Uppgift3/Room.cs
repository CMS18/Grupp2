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
        public string Description { get; set; }

        private List<Item> items;
        private List<Challenge> challenges;
        private List<Creature> creatures;
        public bool Finish { get; set; }
        public bool TutorialFinish { get; set; }


        //Possible exits 
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        private Dictionary<char, Door> doors;

        public Room(string title, string description)
        {
            Title = title;
            items = new List<Item>();
            Description = description;
            challenges = new List<Challenge>();
            creatures = new List<Creature>();
            doors = new Dictionary<char, Door>();
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
        public void RemoveItem(Item item)
        {
            items.Remove(item);
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
        public void AddDoor(Door door, char direction)
        {
            doors.Add(direction, door);
        }
        public Door GetDoor(char direction)
        { 
            Door door;
            doors.TryGetValue(direction, out door);
            return door;
        }
        public Dictionary<char, Door> GetDoors()
        {
            return doors;
        }
    }
}
