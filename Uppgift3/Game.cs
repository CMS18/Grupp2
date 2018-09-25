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

            //THIS IS JUST SOME TESTING
            Console.WriteLine(currentRoom.Title);
            //USE THIS TO MOVE FORWARD
            currentRoom = currentRoom.North;
            Console.WriteLine(currentRoom.Title);
            //END TESTING
            do
            {
            } while (playing);
        }
    }
}
