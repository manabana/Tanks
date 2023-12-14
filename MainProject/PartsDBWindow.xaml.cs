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
                new Item(3, "Регенерирующая броня", ItemsType.Armor, "Регенерирует после каждого хода.")
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
