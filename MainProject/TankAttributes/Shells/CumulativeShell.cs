using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Shells
{
    internal class CumulativeShell : IShell //Кумулятивный снаряд
    {
        public float Damage { get; } = 7f;
    }
}
