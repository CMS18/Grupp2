using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Weapon : Item
    {     
        private int Attack { get; set; }
        public string Legendary { get; set; }

        public Weapon (int id, string name, string description, int attack) : base (id, name, description)
        {
            Attack = attack;
        }

        
    }

}
