using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Strategies
{
    internal class RandomTarget : Strategy
    {
        public override Tank AttackSelection(List<Tank> Enemytanks)
        {
            Random r = new Random();
            return Enemytanks[r.Next(Enemytanks.Count)];
        }

    }
}
