using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Armor : Item
    {
        private int Defense { get; set; }

        public Armor(int id, string name, string description, int defense, int weight) : base(id, name, description, weight)
        {
            Defense = defense;
        }
    }
}
