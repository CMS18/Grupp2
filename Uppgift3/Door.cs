using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Door : Item
    {
        public bool Locked { get; set; }
        public Door(int id, string name, string description, bool locked) : base(id, name, description, 0)
        {
            Locked = locked;
        }
    }
}
