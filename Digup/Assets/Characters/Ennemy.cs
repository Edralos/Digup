﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Characters
{
    public class Ennemy : Character
    {
        public string Stage;
        public Ennemy(string name, int maxHP, int prot, int dodge, int atkMods, int acc, int speed, string stage) : base(name, maxHP, prot, dodge, atkMods, acc, speed)
        {
            Stage = stage;
        }
    }
}
