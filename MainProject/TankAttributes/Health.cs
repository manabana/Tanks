using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    public abstract class Health : IDamageable
    {
        public float HealthValue { get; protected set; }
        public virtual void Damaged(DamageInfo damage)
        {
            HealthValue -= damage.Damage;
        }
        public virtual void ApplyModifier(float modificator)
        {
            HealthValue *= modificator;
        }

    }
}
