using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    internal abstract class Armor : IDamageable
    {
        public float ArmorValue { get; protected set; }
        public abstract void Damaged(DamageInfo damage);
    }
}
