using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    public abstract class TankBuilder
    {
        protected Tank tank;
        protected Health health;
        protected Warehouse warehouse = Warehouse.GetInstance();
        public void BuildArmor()
        {
            List<Armor> armors = warehouse.armors;
            Random random = new Random();
            tank.AddArmor(armors[random.Next(armors.Count)]);
            tank.Armor.Health = health;
        }
        public void BuildWeapon()
        {
            List<IWeapon> weapons = warehouse.weapons;
            Random random = new Random();
            tank.AddWeapon(weapons[random.Next(weapons.Count)]);
        }
        public void BuildShell()
        {
            List<IShell> shells = warehouse.shells;
            Random random = new Random();
            tank.AddShell(shells[random.Next(shells.Count)]);
        }
        public void BuildHealth()
        {
            List<Health> healths = warehouse.healths;
            Random random = new Random();
            tank.AddHealth(healths[random.Next(healths.Count)]);
            health = tank.Health;
        }
        public Tank AutoGenerateTank()
        {
            BuildHealth();
            BuildWeapon();
            BuildArmor();
            BuildShell();
            return tank;
        }
        public Tank GetResult() => tank;
    }
}
