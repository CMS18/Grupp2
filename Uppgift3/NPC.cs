using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Npc : Creature
    {
        public bool Hostile { get; set; }

        public Npc(int id, string name, string description, bool hostile) : base(id, name, description)
        {
            Hostile = hostile;
        }
    }
}
