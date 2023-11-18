using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class SteelArmor : Armor
    {
        public SteelArmor(float modificator)
        {
            ArmorValue = 100 * ((modificator / 100) + 1);
        }
        public override void Damaged(DamageInfo damage)
        {
            ArmorValue -= damage.Shell.Damage * 0.8f;
        }

    }
}
