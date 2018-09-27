using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Uppgift3
{
    public class Game : World
    {

        Room currentRoom;
        Player player;
        World world;

        //    foreach (Item item in items)
        //{
        //    _description += "There is a " + item.Name + " in here. ";
        //}

        //foreach (Creature creature in creatures)
        // {
        //_description += "There is a " + creature.Description + " in here. " + "It's " + creature.Name + "!";
        // }
   

        public Game()
        {
            currentRoom = CurrentRoom;
        }
        public void Play()
        {
            // THE GAME LOOP
            bool playing = true;
            
            Console.WriteLine(currentRoom.Title);
            Console.WriteLine(currentRoom.Description);

            //END TESTING
            do
            {
            } while (playing);
        }

        public void menu()
        {

            Console.WriteLine("Aloha and welcome to your Adventure");
            Console.WriteLine("Please make a choice");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Command List");
            Console.WriteLine("3. How to Play?");
            Console.WriteLine("4. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    new Game();
                    break;

                case "2":
                    new Commands();
                    break;

                case "3":
                    new Rules();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
