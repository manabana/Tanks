using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Builders
{
    internal class BuilderTools
    {
        public static TankBuilder GetRandomTankBuilder()
        {
            int i = RandomTools.rand.Next(3);
            if (i == 0)
            {
                return new HeavyTankBuilder();
            }
            else if (i == 1)
            {
                return new LightTankBuilder();
            }
            else if (i == 2) 
            {
                return new MediumTankBuilder();
            }
            else { return new MediumTankBuilder(); }
        }
    }
}
