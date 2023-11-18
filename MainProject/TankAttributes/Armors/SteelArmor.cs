﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class SteelArmor : Armor //Поглощает 20% урона
    {
        public SteelArmor()
        {
            ArmorValue = 100;
        }
        public override void Damaged(DamageInfo damage)
        {
            ArmorValue -= (damage.Shell.Damage * 0.8f) / 2;
        }

    }
}
