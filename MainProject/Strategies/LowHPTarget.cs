using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Strategies
{
    internal class LowHPTarget : Strategy
    {
        public override Tank AttackSelection(List<Tank> Enemytanks)
        {
            var tank = Enemytanks.OrderBy(p => p.Health.HealthValue).First();
            return tank;
        }
    }
}
