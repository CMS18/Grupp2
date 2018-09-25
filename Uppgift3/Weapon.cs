using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Weapon : Item
    {     
        public int Attack { get; set; }

        public Weapon (int id, string name, string description, int attack, int weight) : base (id, name, description, weight)
        {
            Attack = attack;
        }
    }
}
