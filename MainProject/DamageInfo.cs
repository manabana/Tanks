using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class DamageInfo //Класс-хранитель информации о нанесенном уроне
    {
        public Tank Tank { get; set; }
        public IShell Shell { get; set; }
        public float Damage {get; set;}
        public DamageInfo(Tank tank, IShell shell)
        {
            this.Tank = tank;
            this.Shell = shell;
            Damage = shell.Damage;
        }
    }
}
