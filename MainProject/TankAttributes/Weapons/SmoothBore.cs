﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Weapons
{
    internal class SmoothBore : IWeapon
    {
        public float MissChance { get; } = 0.13f;
    }
}
