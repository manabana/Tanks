﻿using MainProject.TankAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    internal class Warehouse
    {
        private static Warehouse Instance;
        private Warehouse() { }
        private List<Armor> armors = new List<Armor>();
        private List<IWeapon> weapons = new List<IWeapon>();
        private List<IShell> shells = new List<IShell>();
        public static Warehouse GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Warehouse();
            }
            return Instance;
        }
        public void Fill(int TanksCount)
        {

        }
        private Armor GetRandArmors(int count)
        {
            
        }
    }
}
