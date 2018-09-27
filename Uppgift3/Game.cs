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


        public Game()
        {
            currentRoom = CurrentRoom;

        }
        public void Play()
        {

            // THE GAME LOOP
            bool playing = true;
            //END TESTING
            do
            {
            } while (playing);
        }


        public string CreatePlayer()
        {
            Console.Clear();
            Console.Write("What is your name Adventurer? ");
            string playerName = Console.ReadLine();
            return playerName;
        }
        public void Formatting(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
        public void Menu()
        {
            bool validInput = true;
            while(validInput)
            {           
                Console.Clear();
                string text = @"
                                ***************************************
                                * Aloha and welcome to your Adventure *
                                ***************************************
                                
                                Please make a choice

                                1. New Game
                                2. Command List
                                3. Are you a little dumb? L2P and RTFM
                                4. Exit";
                Formatting(text);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreatePlayer();
                        break;

                    case "2":
                        RulesAndCommands.Commands();
                        break;

                    case "3":
                        RulesAndCommands.Rules();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Thank you for looking at the menu! Bye Bye!");
                        Console.ReadLine();
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
