using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    public class ClusterHealth : Health //Броня гарантированно выдержит N ударов
    {
        public ClusterHealth(float modificator)
        {
            HealthValue = 5 * ((modificator/100)+1);
        }
        public override void Damaged(float damage)
        {
            HealthValue -= 1;
        }
    }
}
