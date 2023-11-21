using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Shells
{
    public class FragmentationShell : IShell //Осколочный снаряд (+25% урон легким танкам, -70% тяжелым )
    {
        public float Damage { get; } = 15f;
    }
}
