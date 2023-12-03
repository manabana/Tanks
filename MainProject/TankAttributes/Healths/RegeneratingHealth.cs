using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    public class RegeneratingHealth : Health //Реген. после каждого урона
    {
        public RegeneratingHealth() 
        {
            HealthValue = 100;
        }
        public override void Damaged(DamageInfo damage)
        {
            float dmg = damage.Damage;
            HealthValue -= dmg;
            if (HealthValue > 0)
            {
                HealthValue += 3;
            }
        }
    }
}
