using MainProject.TankAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Tanks
{
    public abstract class Tank
    {
        public abstract float Modificator { get; }
        public abstract Armor Armor { get; protected set; }
        public abstract Health Health { get; protected set;}
        public abstract IShell Shell { get; protected set; }
        public Tank(Armor armor, Health health,IShell shell)
        {
            Shell = shell;
            Armor = armor;
            Health = health;
        }
        public DamageInfo GetDamageInfo()
        {
            DamageInfo damage = new DamageInfo();
            damage.Shell = Shell;
            damage.Tank = this;
            return damage;
        } 
    }
}
