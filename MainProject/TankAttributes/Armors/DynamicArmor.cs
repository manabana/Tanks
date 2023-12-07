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
            if(damage.Shell is UranicShell) 
            {
                if (RandomTools.rand.NextDouble() <= 0.1f)
                {
                    Health.Damaged(damage);
                }
            }
            else
            {
                if (ArmorValue > 0)
                {
                    if (damage.Shell is CumulativeShell)
                    {
                        ArmorValue -= damage.Shell.Damage;
                    }
                    else
                    {
                        ArmorValue -= damage.Shell.Damage / 2;
                        damage.Damage /= 2;
                        Health.Damaged(damage);
                    }
                }
                else
                {
                    Health.Damaged(damage);
                }

            }

        }

    }
}
