using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Game : World
    {
        Room currentRoom;
        Player player;
        World world;

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
                        new Game().Play();
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
