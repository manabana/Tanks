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
            
        }
    }
}
