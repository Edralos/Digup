﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Characters
{
    public class Ally : Character
    {
        public Ally(string name, int maxHP, int prot, int dodge, int atkMods, int acc, int speed) : base(name, maxHP, prot, dodge, atkMods, acc, speed)
        {
        }
    }
}
