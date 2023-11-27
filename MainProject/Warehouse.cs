using MainProject.TankAttributes;
using MainProject.TankAttributes.Shells;
using MainProject.TankAttributes.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainProject
{
    public class Warehouse //Класс Склада
    {
        private static Warehouse Instance;
        private Warehouse() { }
        public List<Armor> armors = new List<Armor>();
        public List<IWeapon> weapons = new List<IWeapon>();
        public List<Health> healths = new List<Health>();
        public List<IShell> shells = new List<IShell>();
        public static Warehouse GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Warehouse();
            }
            return Instance;
        }
        #region Получение части танком (Выдать экземпляр и удалить из списка)
        public IWeapon GetWeapon()
        {
            Random r = new Random();
            var Instance = weapons[r.Next(weapons.Count)];
            weapons.Remove(Instance);
            return Instance;
        }
        public IShell GetShell()
        {
            Random r = new Random();
            var Instance = shells[r.Next(weapons.Count)];
            shells.Remove(Instance);
            return Instance;
        }
        public Armor GetArmor()
        {
            Random r = new Random();
            var Instance = armors[r.Next(armors.Count)];
            armors.Remove(Instance);
            return Instance;
        }
        public Health GetHealth()
        {
            Random r = new Random();
            var Instance = healths[r.Next(healths.Count)];
            healths.Remove(Instance);
            return Instance;
        }
        #endregion
        public void Fill(int TanksCount)
        {
            armors = GetRandArmors(TanksCount);
            healths = GetRandHealths(TanksCount);
            shells = GetRandShells(TanksCount);
            weapons  = GetRandWeapons(TanksCount);
        }
        private List<Armor> GetRandArmors(int count)
        {
            var random = new Random();
            List<Armor> arms = new List<Armor>();

            // Получаем все типы, которые являются наследниками BaseClass
            var derivedTypes = typeof(Armor).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Armor))).ToList();
            for (int i = 0; i < count; i++)
            {
                var randomIndex = random.Next(derivedTypes.Count);

                // Создаём экземпляр случайного наследника
                Armor randomInstance = (Armor)Activator.CreateInstance(derivedTypes[randomIndex]);
                arms.Add(randomInstance);
            }
            return arms;
            // Выбираем случайный индекс из наших наследников
        }
        private List<IWeapon> GetRandWeapons(int count)
        {
            var random = new Random();
            List<IWeapon> weapons = new List<IWeapon>();

            for (int i = 0; i < count; i++)
            {
                int j = random.Next(3);
                switch (j)
                {
                    case 0:
                        weapons.Add(new MuzzleBrakeBarrel());
                        break;
                    case 1:
                        weapons.Add(new RiffledBarrel());
                        break;
                    case 2:
                        weapons.Add(new SmoothBore());
                        break;
                    default:
                        weapons.Add(new RiffledBarrel());
                    break;
                }
            }
            return weapons;
        }
        private List<Health> GetRandHealths(int count)
        {
            var random = new Random();
            List<Health> heals = new List<Health>();

            // Получаем все типы, которые являются наследниками BaseClass
            var derivedTypes = typeof(Health).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Health))).ToList();
            for (int i = 0; i < count; i++)
            {
                var randomIndex = random.Next(derivedTypes.Count);

                // Создаём экземпляр случайного наследника
                Health randomInstance = (Health)Activator.CreateInstance(derivedTypes[randomIndex]);
                heals.Add(randomInstance);
            }
            return heals;
            // Выбираем случайный индекс из наших наследников
        }
        private List<IShell> GetRandShells(int count)
        {
            var random = new Random();
            List<IShell> Shells = new List<IShell>();

            for (int i = 0; i < count; i++)
            {
                int j = random.Next(3);
                switch (j)
                {
                    case 0:
                        Shells.Add(new CumulativeShell());
                        break;
                    case 1:
                        Shells.Add(new FragmentationShell());
                        break;
                    case 2:
                        Shells.Add(new StandartShell());
                        break;
                    default:
                        Shells.Add(new StandartShell());
                        break;
                }
            }
            return Shells;
            // Выбираем случайный индекс из наших наследников
        }
    }
}
