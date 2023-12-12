using MainProject.TankAttributes.Armors;
using MainProject.TankAttributes.Healths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        public List<Item> Items { get; set; }
        Warehouse Warehouse { get; set; }
        public WarehouseWindow(Warehouse warehouse)
        {
            InitializeComponent();
            Items = new List<Item>();
            Warehouse = warehouse;
        }
        void FillList()
        {
            foreach (var item in Warehouse.armors)
            {
                string name;
                string desc;
                if (item is CombinedArmor)
                {
                    name = "Комбинированная броня";
                    desc = "C вероятностью в 20% весь урон будет заблокирован.";
                }
                else if (item is DynamicArmor)
                {
                    name = "Динамическая броня";
                    desc = "Берет весь урон кумулятивного снаряда на себя.";
                }
                else if (item is RegeneratingArmor)
                {
                    name = "Регенерирующая броня";
                    desc = "Регенерирует после каждого урона.";
                }
                else if (item is StandartArmor)
                {
                    name = "Стандартная броня";
                    desc = "Беспонтовая.";
                }
                else if(item is SteelArmor)
                {
                    name = "Стальная броня";
                    desc = "Поглощает 20% урона.";

                }
                else
                {
                    name = "-";
                    desc = "-";
                }
                Items.Add(new Item(name, desc, ItemsType.Armor));

            }
            foreach (var item in Warehouse.healths)
            {
                string name;
                string desc;
                if (item is ClusterHealth)
                {

                }
            }
        }
        public class Item
        {
            private string Name {  get; set; }
            private ItemsType Type { get; set; }
            private string Description { get; set; }
            public Item(string name, string desc, ItemsType type)
            {
                Name = name;
                Description = desc;
                Type = type;
            }
        }

        public enum ItemsType
        {
            Armor,
            Health,
            Weapon,
            Shell
        }
    }
}
