using MainProject.TankAttributes.Armors;
using MainProject.TankAttributes.Healths;
using MainProject.TankAttributes.Shells;
using MainProject.TankAttributes.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

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
            FillList();
            DisplayItems.ItemsSource = Items;
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
                    name = "Кластерное здоровье";
                    desc = "Гарантированно выдержит N ударов.";
                }
                else if(item is RegeneratingHealth)
                {
                    name = "Регенерирующее здоровья";
                    desc = "Восстанавливает здоровье каждый ход.";
                }
                else if(item is StandartHealth)
                {
                    name = "Стандартное здоровье.";
                    desc = "Беспонтовое.";
                }
                else
                {
                    name="-";
                    desc="-";
                }
                Items.Add(new Item(name, desc, ItemsType.Health));
            }
            foreach (var item in Warehouse.weapons)
            {
                string name;
                string desc;
                if(item is RiffledBarrel)
                {
                    name = "Нарезной ствол";
                    desc = "Точность 93%";
                }
                else if (item is MuzzleBrakeBarrel)
                {
                    name = "Ствол с дульным тормозом";
                    desc = "Точность 100%";
                }
                else if (item is SmoothBore)
                {
                    name = "Гладкоствольное орудие";
                    desc = "Точность 87%";
                }
                else { name="-"; desc="-"; }
                Items.Add(new Item(name, desc, ItemsType.Weapon));
            }
            foreach(var item in Warehouse.shells)
            {
                string name;
                string desc;
                if (item is CumulativeShell)
                {
                    name = "Кумулятивный снаряд";
                    desc = "Наносит урон в обход брони если броня не динамическая.";
                }
                else if (item is StandartShell)
                {
                    name = "Обычный снаряд";
                    desc = "Беспонтонтовый";
                }
                else if (item is UranicShell)
                {
                    name = "Урановый снаряд";
                    desc = "Шанс 10% унитожить танк с первого выстрела";
                }
                else { name = "-"; desc = "-"; }
                Items.Add(new Item(name, desc, ItemsType.Shell));
            }
        }
        public class Item
        {
            public string Name {  get; private set; }
            public ItemsType Type { get; private set; }
            public string Description { get; private set; }
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
