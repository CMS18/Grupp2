﻿using System;
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
        int r = 225;
        int g = 255;
        int b = 250;

        string[] allDirections = {"NORTH", "SOUTH", "WEST", "EAST"};
        string[] exitMessages = {
            "Go ahead and leave, see if I care",
            "Get outta here and go back to your boring programs!",
            "Coward!",
            "Just leave. When you come back I will be waiting with a Hyperflux Railgun 2700",
            "If I were your teacher, I'd deathmatch ya in a minute", //This special, modally marked form of be is used only for an unreal hypothetical. It is a relic of the Old English past subjunctive, and it was once used for far more than we use it today. Nice one :P
            "There can be only one king, and apparently it's not you!",
            "Rest in pieces!"
        };

        public Game()
        {
            currentRoom = TutorialStart;
        }
        public void Play()
        {
            bool playing = true;
            string input;
            Item item = null;

            Console.WriteLine();
            RoomDetails();
            // THE GAME LOOP
            do
            {
                if (currentRoom.TutorialFinish)
                {
                    Console.WriteLine("\nWell played... almost! This was just the tutorial stupid.");
                    Console.Write($"Do you want to continue with the REAL game {player.Name}? ");
                    input = Console.ReadLine().ToUpper();

                    switch (input)
                    {
                        case "Y":
                        case "YES": currentRoom.TutorialFinish = false; break;
                        default: ExitGame(); break;
                    }
                    System.Console.WriteLine("\nWelcome, to the real world " +player.Name +". ");
                }
                Console.WriteLine();
                Console.Write("> ", Color.DeepPink);
                input = Console.ReadLine().ToUpper();
                Console.Clear();
                Console.WriteLine();
                List<string> inputs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Write something, dude!");
                }
                else 
                switch (inputs[0])
                {
                    case "EXIT":
                        {
                            ExitGame();
                                break;
                        }
                    case "MOVE":
                    case "GO":
                    {
                        if (inputs.Count <= 1)
                        Console.WriteLine($"That's not a valid command {player.Name}! Use DIRECTIONS: NORTH, EAST, SOUTH, WEST.");
                        else if (allDirections.Contains(inputs[1]))
                        {
                            MoveTo(inputs[1]);
                            RoomDetails();                                   
                        }                        
                        break;
                    }
                    // NORTH, SOUTH etc...
                    case "NORTH":
                    case "EAST":
                    case "SOUTH":
                    case "WEST":
                    {
                        if (inputs.Count == 1)
                        {
                            MoveTo(input);
                            RoomDetails();                                
                        }
                        else
                            Console.WriteLine($"That's not a valid command {player.Name}! Use DIRECTIONS: NORTH, EAST, SOUTH, WEST.");
                        break;
                    }
                    case "LOOK":
                    case "EXAMINE":
                            
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
                        break;
                    }
                    case "GET":
                    case "PICKUP":
                    {
                        if (inputs.Count > 1)
                        {
                            inputs.RemoveAt(0);
                            string fullItemName = string.Join(" ", inputs);
                                
                            if (currentRoom.GetItems() != null)
                            {
                                item = currentRoom.Pickup(fullItemName);
                                if (item != null)
                                {
                                    currentRoom.RemoveItem(item);
                                    player.AddItem(item);
                                    Console.Write("You picked up a ");
                                    PrintItem(item);
                                    Console.WriteLine(". ");                                        
                                }
                                else
                                {
                                    Console.WriteLine("No. You can't pick that up, whatever that is... ");
                                }
                            }
                        }
                        else
                        Console.WriteLine("Get / Pick up what?");                                
                        break;
                    }
                    case "DROP":
                            {
                                item = DropItems(item, inputs);
                                break;
                            }
                        case "USE":
                    {
                        if (inputs.Count > 1)
                        {
                            UseItem(inputs);                               
                        }
                        else
                        Console.WriteLine("Use what?");
                        break;
                    }
                    case "COMMANDS":
                    {
                        RulesAndCommands.Commands();
                            break;
                    }
                    case "RULES":
                    {
                        RulesAndCommands.Rules();
                            break;
                    }
                    case "INVENTORY":
                    {
                        Console.WriteLine("You look through your pockets. ");
                        Console.WriteLine("INVENTORY");
                        Console.WriteLine("-----------------------------------");
                        if (player.GetItems().Count == 0)
                        {
                            Console.WriteLine("Empty");
                        }
                        else
                        {
                            foreach (Item i in player.GetItems())
                            {
                                PrintItem(i);
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("-----------------------------------");
                        break;
                    }
                    default:
                            Console.WriteLine("Commands mudafada. Do you type it!? Type RULES or COMMANDS for help, you noob. ");
                            break;
                        
                }
                
                
            } while (playing);
        }

        private Item DropItems(Item item, List<string> inputs)
        {
            if (inputs.Count > 1)
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
            else
                Console.WriteLine("Drop what?");
            return item;
        }

        private void UseItem(List<string> inputs)
        {
            int indexOfOn = inputs.FindIndex(w => w == "ON");
            string wholeItemName = "";
            if (indexOfOn >= 0)
                wholeItemName = string.Join(" ", inputs.ToArray(), 1, indexOfOn-1);
            else
                wholeItemName = string.Join(" ", inputs.ToArray(), 1, inputs.Count-1);
            Item item = player.GetItems().Find(i => i.Name.ToUpper() == wholeItemName.ToUpper());

            if (item != null)
            {
                if (indexOfOn >= 0 && inputs.Count > indexOfOn)
                {
                    string wholeTargetName = string.Join(" ", inputs.ToArray(), indexOfOn+1, inputs.Count - indexOfOn -1);
                    // Check for a target item in the room
                    Item target = currentRoom.GetItems().Find(i => i.Name.ToUpper() == wholeTargetName.ToUpper());
                    // Check for a target item in the inventory
                    if (target == null)
                        target = player.GetItems().Find(i => i.Name.ToUpper() == wholeTargetName.ToUpper());
                    // Check for a target door in the room
                    if (target == null)
                    {
                        if (currentRoom.GetDoors().Count != 0)
                            target = currentRoom.GetDoors().Where(d => d.Value.Name.ToUpper() == wholeTargetName.ToUpper()).Select(d => d.Value).FirstOrDefault();
                    }
                    if (target == null)
                    {
                        Console.WriteLine("Huh? Use it on what now!? ");
                    }
                    else
                    {
                        if (item.Use(target))
                        {
                            Console.WriteLine(target.Description);
                        }
                        else
                        {
                            Console.WriteLine("No! That wouldn't work. ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command! USE 'ITEM' ON 'TARGET_ITEM'");
                }
            }
            else
            {
                Console.WriteLine("Are you blind? You don't have an item like that. ");
            }
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
            Console.Write(currentRoom.Title + "\n" + currentRoom.Description);
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
            Console.WriteLine();
        }
        //TODO: print invalid command?
        private void LookAt(string input)
        {
            if (allDirections.Contains(input))
            {
                if (currentRoom.Look(input) != null)
                    Console.Write("You look to the " + input + ". " + currentRoom.Look(input).Description);
                else
                    Console.Write("You look to the " + input + ". You see nothing of interest there! ");
            }
            else
            {
                Item item = currentRoom.GetItems().Find(i => i.Name.ToUpper() == input.ToUpper());
                if(item == null)
                    item = player.GetItems().Find(i => i.Name.ToUpper() == input.ToUpper());
                if (item == null)
                    item = player.GetItems().Find(i => i.Name.ToUpper() == input.ToUpper());
                // Check for a door in the room
                if (item == null)
                {
                    if (currentRoom.GetDoors().Count != 0)
                        item = currentRoom.GetDoors().Where(d => d.Value.Name.ToUpper() == input.ToUpper()).Select(d => d.Value).FirstOrDefault();
                }
                Creature creature = currentRoom.GetCreatures().Find(c => c.Name.ToUpper() == input.ToUpper());

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
            {
                //TODO: GET DOOR and see if it's open
                Door door = currentRoom.GetDoor(direction);
                if(door != null)
                {
                    Console.Write("There is a ");
                    PrintItem(door);
                    if (door.Locked == true)
                    {
                        Console.WriteLine(". It seems to be locked. ");
                    }
                    else
                    {
                        Console.WriteLine(" You open it and enter. ");
                        currentRoom = peekRoom;
                    }
                    Console.WriteLine();
                }
                else
                {
                    currentRoom = peekRoom;
                }
            }
        }
        //TODO: Add stuff to player
        public void CreatePlayer()
        {
            Console.Clear();
            Console.Write("What is your name Adventurer? ");
            string adventurerName = Console.ReadLine();
            if (string.IsNullOrEmpty(adventurerName))
                adventurerName = "noob";
            Console.Write($"Give a short description of yourself, {adventurerName}: ");
            string adventurerDescription = Console.ReadLine();
            if (string.IsNullOrEmpty(adventurerDescription))
                adventurerDescription = "Too lazy to write a story.";
            player = new Player(adventurerName, adventurerDescription, "");
            Console.Clear();
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
                Console.Write("> ", Color.DeepPink);
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
                        Console.WriteLine("I knew you didn't have it in you. Peasant.");
                        ExitGame();
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
