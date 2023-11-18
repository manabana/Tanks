using MainProject.TankAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainProject
{
    public class Warehouse
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
            var derivedTypes = typeof(Armor).Assembly.GetTypes()
                                .Where(t => t.IsSubclassOf(typeof(Armor)))
                                .ToList();
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
            List<IWeapon> weaps = new List<IWeapon>();

            // Получаем все типы, которые являются наследниками BaseClass
            var derivedTypes = typeof(IWeapon).Assembly.GetTypes()
                                .Where(t => t.IsSubclassOf(typeof(IWeapon)))
                                .ToList();
            for (int i = 0; i < count; i++)
            {
                var randomIndex = random.Next(derivedTypes.Count);

                // Создаём экземпляр случайного наследника
                IWeapon randomInstance = (IWeapon)Activator.CreateInstance(derivedTypes[randomIndex]);
                weaps.Add(randomInstance);
            }
            return weaps;
            // Выбираем случайный индекс из наших наследников
        }
        private List<Health> GetRandHealths(int count)
        {
            var random = new Random();
            List<Health> heals = new List<Health>();

            // Получаем все типы, которые являются наследниками BaseClass
            var derivedTypes = typeof(Health).Assembly.GetTypes()
                                .Where(t => t.IsSubclassOf(typeof(Health)))
                                .ToList();
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
            List<IShell> IShell = new List<IShell>();

            // Получаем все типы, которые являются наследниками BaseClass
            var derivedTypes = typeof(IShell).Assembly.GetTypes()
                                .Where(t => t.IsSubclassOf(typeof(IShell)))
                                .ToList();
            for (int i = 0; i < count; i++)
            {
                var randomIndex = random.Next(derivedTypes.Count);

                // Создаём экземпляр случайного наследника
                IShell randomInstance = (IShell)Activator.CreateInstance(derivedTypes[randomIndex]);
                IShell.Add(randomInstance);
            }
            return IShell;
            // Выбираем случайный индекс из наших наследников
        }
    }
}
