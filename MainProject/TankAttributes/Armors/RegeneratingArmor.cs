using MainProject.TankAttributes.Shells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class RegeneratingArmor : Armor
    {
        public RegeneratingArmor()
        {
            ArmorValue = 100;
            
        }
        public override void Damaged(DamageInfo damage)
        {
            ArmorValue -= damage.Damage / 2;
            if (ArmorValue > 0)
            {
                ArmorValue += 3;
            }
            if(ArmorValue > 0)
            {
                damage.Damage /= 2;
                Health.Damaged(damage);

            }
            else
            {
                Health.Damaged(damage);
            }
        }

    }
}
