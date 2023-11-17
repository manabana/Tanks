using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    internal class RegeneratingArmor : Armor
    {
        public RegeneratingArmor(float modificator)
        {
            ArmorValue = 100 * ((modificator / 100) + 1);
        }
        public override void Damaged(float damage)
        {
            ArmorValue -= damage;
            if (ArmorValue > 0)
            {
                ArmorValue += 3;
            }
        }

    }
}
