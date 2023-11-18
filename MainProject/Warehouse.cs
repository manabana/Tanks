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

    }
}
