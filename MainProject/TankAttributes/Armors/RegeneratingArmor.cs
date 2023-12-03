using MainProject.TankAttributes.Shells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class RegeneratingArmor : Armor // Регенерирует
    {
        public RegeneratingArmor()
        {
            ArmorValue = 100;
            
        }
        public override void Damaged(DamageInfo damage)
        {
            ArmorValue -= damage.Damage / 2;
            
            if(ArmorValue > 0)
            {
                if(damage.Shell is CumulativeShell)
                {
                    Health.Damaged(damage);
                }
                else
                {
                    damage.Damage /= 2;
                    Health.Damaged(damage);
                }
            }
            else
            {
                Health.Damaged(damage);
            }
            if (ArmorValue > 0)
            {
                ArmorValue += 3;
            }
        }

    }
}
