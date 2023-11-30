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
        public List<Tank> Tanks{get;set;}
        public Color TeamColor{ get; set; }
        public Strategy Strategy{get;set;}
        public Team()
        {
            Tanks = new List<Tank>();
            int i = new Random().Next(3);
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
    }
}
