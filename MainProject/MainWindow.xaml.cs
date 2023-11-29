using MainProject.Builders;
using MainProject.Tanks;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Team AlphaTeam = new Team();
        public static Team BetaTeam = new Team();
            
        public MainWindow()
        {
            InitializeComponent();

            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(20);

            int tankscount = 5;

            #region Team 1
            for (int i = 0; i < tankscount; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                AlphaTeam.Tanks.Add(tank);
            }
            #endregion
            #region Team 2
            for (int i = 0; i < tankscount; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                BetaTeam.Tanks.Add(tank);
            }

            #endregion


            TankBuilder builder = BuilderTools.GetRandomTankBuilder();
            builder.BuildHealth();
            builder.BuildArmor();
            builder.BuildWeapon();
            builder.BuildShell();
            TankBuilder builder1 = BuilderTools.GetRandomTankBuilder();
            builder1.BuildHealth();
            builder1.BuildArmor();
            builder1.BuildWeapon();
            builder1.BuildShell();
            TankBuilder builder2 = BuilderTools.GetRandomTankBuilder();
            builder2.BuildHealth();
            builder2.BuildArmor();
            builder2.BuildWeapon();
            builder2.BuildShell();
        }
    }
}
