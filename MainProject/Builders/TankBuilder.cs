using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    public abstract class TankBuilder
    {
        private abstract Tank;
        public void BuildArmor()
        {
            
        }
        public abstract void BuildWeapon();
        public abstract void BuildShell();
        public abstract Tank GetResult();
    }
}
