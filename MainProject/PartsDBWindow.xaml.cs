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
using static MainProject.WarehouseWindow;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для PartsDBWindow.xaml
    /// </summary>
    public partial class PartsDBWindow : Window
    {
        public PartsDBWindow()
        {
            InitializeComponent();
            DisplayItems.ItemsSource = new List<Item>
            {
                new Item(1, "Комбинированная броня", ItemsType.Armor, "C вероятностью в 20% весь урон будет заблокирован."),
                new Item(2, "Динамическая броня", ItemsType.Armor, "Берет весь урон кумулятивного снаряда на себя."),
                new Item(3, "Регенерирующая броня", ItemsType.Armor, "Регенерирует после каждого хода."),
                new Item(4, "Стандартная броня", ItemsType.Armor, "Без особых эффектов"),
                new Item(5, "Ствльная броня", ItemsType.Armor, "Поглощает 20% урона."),
                new Item(6, "Кластерное здоровье", ItemsType.Health, "Гарантированно выдержит N ударов."),
                new Item(7, "Регенерирующее здоровье", ItemsType.Health, "Восстанавливает здоровье каждый ход."),
                new Item(8, "Стандартное здоровье", ItemsType.Health, "Без бонусов."),
                new Item(9, "Нарезной ствол", ItemsType.Weapon, "Точность 93%."),
                new Item(10, "Ствол с дульным тормозом", ItemsType.Weapon, "Точность 100%."),
                new Item(11, "Гладкоствольное орудие", ItemsType.Weapon, "Точность 87%."),
                new Item(12, "Урановый снаряд", ItemsType.Shell, "Шанс 10% унитожить танк с первого выстрела."),
                new Item(13, "Обычный снаряд", ItemsType.Shell, "Беспонтонтовый."),
                new Item(14, "Кумулятивный снаряд", ItemsType.Shell, "Наносит урон в обход брони если броня не динамическая."),

            };
        }


        public class Item
        {
            public int Id { get; set; }
            public string Name { get; private set; }
            public ItemsType Type { get; private set; }
            public string Description { get; private set; }
            public Item(int id, string name, ItemsType type, string description)
            {
                Id = id;
                Name = name;
                Type = type;
                Description = description;
            }
        }
    }
}
