using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    internal class ClusterHealth : Health //Броня гарантированно выдержит N ударов
    {
        public ClusterHealth(int modificator)
        {
            HealthValue = 5 * ((modificator/100)+1);
        }
        public override void Damaged(int damage)
        {
            HealthValue -= 1;
        }
    }
}
