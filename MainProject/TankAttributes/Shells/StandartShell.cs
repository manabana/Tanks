using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Shells
{
    internal class StandartShell : IShell //Обыный снаряд
    {
        public float Damage { get; } = 18f;
    }
}
