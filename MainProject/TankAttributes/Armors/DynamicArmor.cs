using MainProject.TankAttributes.Shells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class DynamicArmor : Armor //берет весь урон кумулятивного снаряда на себя
    {
        public DynamicArmor()
        {
            ArmorValue = 100;
        }
        public override void Damaged(DamageInfo damage)
        {
            if (damage.Shell is CumulativeShell)
            {
                ArmorValue -= damage.Shell.Damage;
            }
        }

    }
}
