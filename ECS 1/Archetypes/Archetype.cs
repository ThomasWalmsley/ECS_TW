using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_1
{
    struct Archetype
    {
        string name;
        List<Type> archetype;
        public Archetype(string Name,List<Type> Archetype) 
        {
            name = Name;
            archetype = Archetype;
        }
    }
}
