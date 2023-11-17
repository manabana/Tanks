using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    internal abstract class Health : IDamageable
    {
        public float HealthValue { get; protected set; }
        public abstract void Damaged(float damage);
    }
}
