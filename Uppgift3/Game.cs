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
   

        public string CreatePlayer()
        {
            Console.Clear();
            Console.WriteLine("What is your name Adventurer?");
            string playerName = Console.ReadLine();
            return playerName;
        }

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

        public void Menu()
        {
            bool validInput = true;
            while(validInput)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t***************************************");
                Console.WriteLine("\t\t\t* Aloha and welcome to your Adventure *");
                Console.WriteLine("\t\t\t***************************************");
                Console.WriteLine("\t\t\t\tPlease make a choice");
                Console.WriteLine("\n\t\t\t\t1. New Game");
                Console.WriteLine("\n\t\t\t\t2. Command List");
                Console.WriteLine("\n\t\t\t\t3. How to Play?");
                Console.WriteLine("\n\t\t\t\t4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        new Game().CreatePlayer();
                        break;

                    case "2":
                        new RulesAndCommands().Commands();
                        break;

                    case "3":
                        new RulesAndCommands().Rules();
                        break;

                    case "4":
                        Console.Clear();                    
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input! Please chose a valid number!");
                        Console.ReadLine();
                        //validInput = false;
                        break;
                }
            }   
        }
    }
}
