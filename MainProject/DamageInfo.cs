using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public struct DamageInfo //Класс-хранитель информации о нанесенном уроне
    {
        public Tank Tank { get; set; }
        public IShell Shell { get; set; }
    }
}
