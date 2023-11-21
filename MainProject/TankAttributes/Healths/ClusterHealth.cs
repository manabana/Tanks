using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    public class ClusterHealth : Health //Броня гарантированно выдержит N ударов
    {
        public ClusterHealth()
        {
            HealthValue = 5;
        }
        public override void ApplyModifier(float modificator)
        {
            HealthValue = (float)Math.Round(HealthValue * modificator);
        }

        public override void Damaged(DamageInfo damage)
        {
            HealthValue -= 1;
        }
    }
}
