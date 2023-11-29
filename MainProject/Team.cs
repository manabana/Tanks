using MainProject.TankAttributes;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MainProject
{
    public struct Team
    {
        public List<Tank> Tanks{get;set;}
        public Color TeamColor{ get; set; }
        public Strategy Strategy{get;set;}
    }
}
