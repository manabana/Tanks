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
            tank.AddArmor(warehouse.GetArmor());
            tank.Armor.Health = health;
        }
        public void BuildWeapon()
        {
            tank.AddWeapon(warehouse.GetWeapon());
        }
        public void BuildShell()
        {
            tank.AddShell(warehouse.GetShell());
        }
        public void BuildHealth()
        {
            tank.AddHealth(warehouse.GetHealth());
            health = tank.Health;
        }
        public Tank AutoGenerateTank()
        {
            BuildHealth();
            BuildWeapon();
            BuildArmor();
            BuildShell();
            tank.ModifyAll();
            return tank;
        }
        public Tank GetResult() => tank;
    }
}
