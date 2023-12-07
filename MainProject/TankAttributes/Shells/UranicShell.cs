using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.TankAttributes.Shells
{
    public class UranicShell : IShell // 10% шанс уничтожить танк, при неудаче урона не будет
    {
        public float Damage { get; } = 1000f;
    }
}
