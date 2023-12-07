using MainProject.Strategies;
using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MainProject
{
    public class Team
    {
        public string Name { get; set; }
        public List<Tank> Tanks{get;set;}
        public Color TeamColor{ get; set; }
        public Strategy Strategy{get;set;}
        public Team()
        {
            Tanks = new List<Tank>();
            int i = RandomTools.rand.Next(3);
            switch(i)
            {
                case 0:
                    Strategy = new RandomTarget();
                    break; 
                case 1:
                    Strategy = new LowHPTarget();
                    break;
                case 2:
                    Strategy = new LightestTarget();
                    break;
                default: Strategy = new RandomTarget(); break;

            }
        }
        public List<SimplyfiedTank> GetSimplyfied()
        {
            var STs = new List<SimplyfiedTank>();
            foreach(Tank tank in Tanks)
            {
                STs.Add(new SimplyfiedTank { Armor = (float)Math.Round(tank.Armor.ArmorValue, 2), Health = (float)Math.Round(tank.Health.HealthValue, 2) });
            }
            return STs;
        }
    }
    public class SimplyfiedTank
    {
        public float Health {  get; set; }
        public float Armor { get; set; }
    }
}
