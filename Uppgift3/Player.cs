using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Player : Creature
    {
        public string Gender { get; set; }

        public Player(string name, string description, string gender) : base(name, description)
        {
            Gender = gender;
        }
    }
}
