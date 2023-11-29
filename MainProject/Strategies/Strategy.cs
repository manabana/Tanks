using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes
{
    public abstract class Strategy
    {
        public abstract Tank AttackSelection(List<Tank> Enemytanks);
        
    }
}