using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    public abstract class Health : IDamageable
    {
        protected float hv;
        public float HealthValue 
        { 
            get { return hv; }
            protected set
            {
                float HV = value;
                if (HV < 0f)
                {
                    HV = 0f;
                }
                hv = HV;

            } 
        }
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
