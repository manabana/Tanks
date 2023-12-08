using MainProject.Strategies;
using MainProject.TankAttributes;
using MainProject.TankAttributes.Weapons;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Windows;
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
                STs.Add(new SimplyfiedTank (tank) { Armor = (float)Math.Round(tank.Armor.ArmorValue, 2), Health = (float)Math.Round(tank.Health.HealthValue, 2), Brush = new SolidColorBrush(TeamColor) });
            }
            return STs;
        }
    }
    public class SimplyfiedTank
    {
        public float Health {  get; set; }
        public float Armor { get; set; }

        public Visibility LightP {  get; set; }
        public Visibility MediumP { get; set; }
        public Visibility HeavyP { get; set; }

        public Visibility SmoothB { get; set; }
        public Visibility RifleB { get; set; }
        public Visibility BrakeB { get; set; }

        public Tank Tank { get; set; }
        public Brush Brush { get; set;}
        
        public SimplyfiedTank(Tank tank)
        {
            Tank = tank;
            if(Tank is LightTank)
            {
                MediumP = Visibility.Collapsed;
                LightP = Visibility.Visible;
                HeavyP = Visibility.Collapsed;
            }
            else if(Tank is MediumTank)
            {
                MediumP = Visibility.Visible;
                LightP = Visibility.Collapsed;
                HeavyP = Visibility.Collapsed;
            }
            else if (Tank is HeavyTank) 
            {
                MediumP = Visibility.Collapsed;
                LightP = Visibility.Collapsed;
                HeavyP = Visibility.Visible;
            }

            if (Tank.Weapon is MuzzleBrakeBarrel)
            {
                SmoothB = Visibility.Collapsed;
                RifleB = Visibility.Collapsed;
                BrakeB = Visibility.Visible;
            }
            else if (Tank.Weapon is RiffledBarrel)
            {
                SmoothB = Visibility.Collapsed;
                RifleB = Visibility.Visible;
                BrakeB = Visibility.Collapsed;
            }
            else if (Tank.Weapon is SmoothBore)
            {
                SmoothB = Visibility.Visible;
                RifleB = Visibility.Collapsed;
                BrakeB = Visibility.Collapsed;
            }

        }
    }
}
