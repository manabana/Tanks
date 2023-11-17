using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    internal interface IDamageable
    {
        void Damaged(float damage);
    }
}
