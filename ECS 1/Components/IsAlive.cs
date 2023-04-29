using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_1
{
    struct IsAlive//component
    {
        bool isAlive;

        public IsAlive(bool IsAlive) 
        {
            isAlive = IsAlive;
        }

    }
}
