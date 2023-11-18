using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    public class LightTankBuilder : TankBuilder
    {
        public LightTankBuilder()
        {
            tank = new LightTank();
        }
    }
}
