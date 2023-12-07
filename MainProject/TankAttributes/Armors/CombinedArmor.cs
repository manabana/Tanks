using MainProject.TankAttributes.Shells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Armors
{
    public class CombinedArmor : Armor // с вероятностью в 20% весь урон будет заблокирован
    {
        public CombinedArmor()
        {
            ArmorValue = 100;
        }
        public override void Damaged(DamageInfo damage)
        {
            if(damage.Shell is UranicShell)
            {
                if (RandomTools.rand.NextDouble() >= 0.2f)
                {
                    if (RandomTools.rand.NextDouble() <= 0.1f)
                    {
                        Health.Damaged(damage);
                    }
                }
                
            }
            else
            {
                if (ArmorValue > 0)
                {
                    int index = RandomTools.rand.Next(4);
                    if (index != 0)
                    {
                        if (damage.Shell is CumulativeShell)
                        {
                            Health.Damaged(damage);
                        }
                        else
                        {
                            ArmorValue -= damage.Shell.Damage / 2;
                            damage.Damage /= 2;
                            Health.Damaged(damage);
                        }
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
