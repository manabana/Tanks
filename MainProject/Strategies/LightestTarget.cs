using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Strategies
{
    internal class LightestTarget : Strategy
    {
        public override Tank AttackSelection(List<Tank> Enemytanks)
        {
            List<Tank> tanks = Enemytanks.Where(p=>p is LightTank).ToList();
            if(tanks.Count() == 0)
            {
                tanks.AddRange(Enemytanks.Where(p => p is MediumTank).ToList());
            }
            else
            {
                return tanks[RandomTools.rand.Next(tanks.Count)];
            }
            if(tanks.Count() == 0)
            {
                tanks.AddRange(Enemytanks.Where(p=>p is HeavyTank).ToList());
            }
            else
            {
                return tanks[RandomTools.rand.Next(tanks.Count)];
            }
            if(tanks.Count == 0)
            {
                return null;
            }
            else
            {
                return tanks[RandomTools.rand.Next(tanks.Count)];
            }
        }
    }
}
