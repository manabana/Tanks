using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    public class StandartHealth : Health
    {
        public StandartHealth(float modificator) 
        {
            HealthValue = 100 * ((modificator/100)+1);      
        }
        public override void Damaged(float damage)
        {
            HealthValue -= damage;
        }
    }
}
