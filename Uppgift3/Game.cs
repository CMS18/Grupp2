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
        string[] allDirections = {"NORTH", "SOUTH", "WEST", "EAST"};
        string[] exitMessages = {
            "Go ahead and leave, see if I care",
            "Get outta here and go back to your boring programs!",
            "Coward!",
            "Just leave. When you come back I will be waiting with a Hyperflux Railgun 2700",
            "If I were your teacher, I'd deathmatch ya in a minute", //This special, modally marked form of be is used only for an unreal hypothetical. It is a relic of the Old English past subjunctive, and it was once used for far more than we use it today. Nice one :P
            "There can only be one king, and apparently it's not you!",
            "Rest in pieces!"
        };

        public Game()
        {
            currentRoom = TutorialStart;
        }
        public void Play()
        {
            // THE GAME LOOP
            bool playing = true;
            bool tutorial = true;
            string input;
            Item item = null;
            RoomDetails();
            do
            {
                if (currentRoom.TutorialFinish)
                {
                    Console.WriteLine("\nWell played... almost! This was just the tutorial stupid.");
                    Console.Write("Do you want to continue with the REAL game? ");
                    input = Console.ReadLine().ToUpper();

                    switch (input)
                    {
                        case "Y":
                        case "YES": currentRoom.TutorialFinish = false; break;
                        default: ExitGame(); break;
                    }
                    System.Console.WriteLine("\nWelcome, to the real world " +player.Name);   //TODO: player.getName or something //DONE: Line 193 in method createPlayer()
                }
                Console.WriteLine();
                input = Console.ReadLine().ToUpper();
                List<string> inputs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (input != " ")
                    if (inputs[0] == "EXIT")
                    {
                        ExitGame();
                    }
                    if (inputs[0] == "MOVE" || inputs[0] == "GO")
                    {
                        if (allDirections.Contains(inputs[1]))
                        {
                            MoveTo(inputs[1]);
                            RoomDetails();
                        }
                        else
                            Console.WriteLine("That's not a valid command! Use DIRECTIONS: NORTH, EAST, SOUTH, WEST.");
                    }
                    // NORTH, SOUTH etc...
                    else if (allDirections.Contains(input))        
                    {
                        if (inputs.Count == 1)
                        {
                            MoveTo(input);
                            RoomDetails();
                        }
                        else
                            Console.WriteLine("That's not a valid command! Use DIRECTIONS: NORTH, EAST, SOUTH, WEST.");
                    }
                    else if (inputs[0] == "LOOK" || inputs[0] == "EXAMINE")
                    {
                        if (inputs.Count == 1)
                        {
                            RoomDetails();
                        }
                        else
                        {
                            inputs.RemoveAt(0);
                            string fullName = string.Join(" ", inputs);
                            LookAt(fullName);
                        }
                    }
                    else if (inputs[0] == "GET" || inputs[0] == "PICKUP")
                    {
                        if(inputs.Count > 1)
                        {
                            inputs.RemoveAt(0);
                            string fullItemName = string.Join(" ", inputs) ;
                            
                            if (currentRoom.GetItems() != null) {
                                item = currentRoom.Pickup(fullItemName);
                                if (item != null)
                                {
                                    currentRoom.RemoveItem(item);
                                    player.AddItem(item);
                                    Console.Write("You picked up a ");
                                    PrintItem(item);
                                    Console.WriteLine(". ");
                                }
                            }
                        }
                    }
                    else if (inputs[0] == "DROP")
                    {
                        if(inputs.Count > 1)
                        {
                            inputs.RemoveAt(0);
                            string wholeItemName = string.Join(" ", inputs);

                            if (player.GetItems() != null)
                            {
                                item = player.Drop(wholeItemName);
                                if (item != null)
                                {
                                    player.RemoveItem(item);
                                    currentRoom.AddItem(item);
                                    Console.Write("You dropped a ");
                                    PrintItem(item);
                                    Console.WriteLine(". ");
                                }
                            }
                        }
                    }
                    else if(inputs[0] == "USE")
                    {
                        // TODO: Use item with door or other item
                    }
                    else if (inputs[0] == "COMMANDS")
                    {
                    RulesAndCommands.Commands();
                    }
                    else if (inputs[0] == "RULES")
                    {
                    RulesAndCommands.Rules();
                    }
            } while (playing);
        }
        private void PrintItem(Item item)
        {
            Console.Write(item.Name.ToUpper(), item.Legendary ? Color.Goldenrod : Color.LimeGreen);
        }
        private void PrintCreature(Creature npc)
        {
            Console.Write(npc.Name.ToUpper(), npc.Elite ? Color.Yellow : Color.Crimson);
        }
        //TODO: Add same thing for creatures
        private void RoomDetails()
        {
            Console.WriteLine(currentRoom.Title + "\n" + currentRoom.Description);
            foreach(var item in currentRoom.GetItems())
            {
                Console.Write("You see a ");
                PrintItem(item);
                Console.Write(". ");
            }
            foreach (var npc in currentRoom.GetCreatures())
            {
                Console.Write("There is a ");
                PrintCreature(npc);
                Console.Write(" here. ");
            }
            if (currentRoom.GetItems().Count > 0 && currentRoom.GetCreatures().Count > 0 )
                Console.WriteLine();
        }
        //TODO: print invalid command?
        private void LookAt(string input)
        {
            if (allDirections.Contains(input))
            {
                if (currentRoom.Look(input) != null)
                    Console.WriteLine("You look to the " + input + ". " + currentRoom.Look(input).Description);
                else
                    Console.WriteLine("You see nothing of interest there! ");
            }
            else
            {
                Item item = currentRoom.GetItems().Find(i => i.Name.ToUpper() == input);
                Creature creature = currentRoom.GetCreatures().Find(c => c.Name.ToUpper() == input);

                if (item != null) {
                    Console.Write("You examine ");
                    PrintItem(item);
                    Console.Write(". " + item.Description);
                }
                else if (creature != null)
                {
                    Console.Write("You look at the ");
                    PrintCreature(creature);
                    Console.Write(". " + creature.Description);
                }
                else
                {
                    Console.Write("There's nothing to look at stupid!");
                }
            }
            Console.WriteLine();
        }

        private void MoveTo(string direction)
        {
            Room peekRoom = currentRoom.Look(direction);   //Change room to the looking direction
            if (peekRoom == null)
                Console.WriteLine("You can't go there dummy! ");
            else
                currentRoom = peekRoom;
        }
        //TODO: Add stuff to player
        public void CreatePlayer()
        {
            Console.Clear();
            Console.Write("What is your name Adventurer? ");
            string adventurerName = Console.ReadLine();
            Console.WriteLine($"Give a short description of yourself, {adventurerName}");
            string adventurerDescription = Console.ReadLine();
            player = new Player(adventurerName, adventurerDescription, "");
            Play();         
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
                        break;
                }
            }   
        }
        public void ExitGame()
        {
            Random r = new Random();
            int roll = r.Next(0, exitMessages.Length);
            Console.Write("\n"+exitMessages[roll], Color.Red);
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}
