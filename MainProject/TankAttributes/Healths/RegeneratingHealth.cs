using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    public class RegeneratingHealth : Health
    {
        public RegeneratingHealth(int modificator) 
        {
            HealthValue = 100 * ((modificator / 100) + 1);
        }
        public override void Damaged(DamageInfo damage)
        {
            float dmg = damage.Shell.Damage;
            HealthValue -= dmg;
            if (HealthValue > 0)
            {
                HealthValue += 3;
            }
        }
    }
}
