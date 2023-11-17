using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    internal class SteelArmor : Armor
    {
        public SteelArmor(float modificator)
        {
            ArmorValue = 100 * ((modificator / 100) + 1);
        }
        public override void Damaged(float damage)
        {
            ArmorValue -= damage * 0.8f;
        }

    }
}
