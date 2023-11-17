using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Shells
{
    internal class FragmentationShell : IShell //Осколочный снаряд
    {
        public float Damage { get; } = 15f;
    }
}
