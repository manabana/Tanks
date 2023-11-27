using System;

namespace MainProject
{
    public struct Team
    {
        public List<Tank> Tanks{get;set;}
        public Color TeamColor{get;set}
        public Strategy strategy{get;set;}
    }
}
