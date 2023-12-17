using MainProject.Strategies;
using MainProject.TankAttributes;
using MainProject.TankAttributes.Weapons;
using MainProject.TankAttributes.Shells;
using MainProject.TankAttributes.Healths;
using MainProject.TankAttributes.Armors;
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
                STs.Add(new SimplyfiedTank (tank) {Armor = (float)Math.Round(tank.Armor.ArmorValue, 2), Health = (float)Math.Round(tank.Health.HealthValue, 2), Brush = new SolidColorBrush(TeamColor) });
            }
            return STs;
        }
    }
    public class SimplyfiedTank
    {
        public int Id { get; set; }
        public float Health {  get; set; }
        public float Armor { get; set; }
        public string ArmorDesc { get; set; }
        public string HealthDesc { get; set; }
        public string ShellName {get; set;}
        public string ShellDesc { get; set; }
        public Visibility LightP { get; set; }
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
            Id = tank.Id;
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
            if(Tank.Shell is CumulativeShell)
            {
                ShellName = "КC";
                ShellDesc = "Наносит урон в обход брони если броня не динамическая.";
            }
            else if (Tank.Shell is StandartShell)
            {
                ShellName = "ОC";
                ShellDesc = "Беспонтонтовый";
            }
            else if (Tank.Shell is UranicShell)
            {
                ShellName = "УC";
                ShellDesc = "Шанс 10% унитожить танк с первого выстрела";
            }

            if (Tank.Armor is CombinedArmor)
            {
                //ShellName = "КБ";
                ArmorDesc = "C вероятностью в 20% весь урон будет заблокирован.";
            }
            else if (Tank.Armor is DynamicArmor)
            {
                //ShellName = "ДБ";
                ArmorDesc = "Берет весь урон кумулятивного снаряда на себя.";
            }
            else if (Tank.Armor is RegeneratingArmor)
            {
                //ShellName = "РБ";
                ArmorDesc = "Регенерирует после каждого хода.";
            }
            else if (Tank.Armor is StandartArmor)
            {
                //ShellName = "СтдБ";
                ArmorDesc = "Беспонтовая.";
            }
            else if(Tank.Armor is SteelArmor)
            {
                //ShellName = "СтлБ";
                ArmorDesc = "Поглощает 20% урона.";

            }

            if (Tank.Health is ClusterHealth)
            {
                //Health = "Кластерное здоровье";
                HealthDesc = "Гарантированно выдержит N ударов.";
            }
            else if(Tank.Health is RegeneratingHealth)
            {
                //name = "Регенерирующее здоровья";
                HealthDesc = "Восстанавливает здоровье каждый ход.";
            }
            else if(Tank.Health is StandartHealth)
            {
                //name = "Стандартное здоровье.";
                HealthDesc = "Беспонтовое.";
            }
        }
    }
}
