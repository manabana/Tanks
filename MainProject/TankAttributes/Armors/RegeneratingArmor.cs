using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class RegeneratingArmor : Armor
    {
        public RegeneratingArmor(float modificator)
        {
            ArmorValue = 100 * ((modificator / 100) + 1);
        }
        public override void Damaged(DamageInfo damage)
        {
            ArmorValue -= damage.Shell.Damage;
            if (ArmorValue > 0)
            {
                ArmorValue += 3;
            }
        }

    }
}
