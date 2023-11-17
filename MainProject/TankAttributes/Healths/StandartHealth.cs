using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Healths
{
    internal class StandartHealth : Health
    {
        public StandartHealth(int modificator) 
        {
            HealthValue = 100 * ((modificator/100)+1);      
        }
        public override void Damaged(int damage)
        {
            HealthValue -= damage;
        }
    }
}
