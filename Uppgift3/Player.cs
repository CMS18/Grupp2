using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Player : Creature
    {
        private string gender; 

        public Player(string description, string name, string _gender) : base(description, name)
        {
            gender = _gender;
        }
       

    }
}
