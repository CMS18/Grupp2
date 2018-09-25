using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Player : Creature
    {
        private string Gender; 

        public Player(string description, string name, string gender, int id) : base(description, name, id)
        {
            Gender = gender;
        }
       

    }
}
