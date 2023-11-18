﻿using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    public class MediumTankBuilder : TankBuilder
    {
        public MediumTankBuilder()
        {
            tank = new MediumTank();
        }
    }
}
