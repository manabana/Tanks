using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    internal abstract class TankBuilder
    {
        public abstract void BuildArmor();
        public abstract void BuildWeapon();
        public abstract void BuildShell();
        public abstract void GetResult();
    }
}
