using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    public class HeavyTankBuilder : TankBuilder
    {
        public HeavyTankBuilder()
        {
            tank = new HeavyTank();
        }
    }
}
