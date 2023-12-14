using MainProject.Builders;
using MainProject.Strategies;
using MainProject.TankAttributes.Armors;
using MainProject.TankAttributes.Healths;
using MainProject.Tanks;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Team AlphaTeam;
        public Team BetaTeam;
        private Gunplay gunplay;
        public int IterationsCount { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        public void FirstActions(int tankCount, int warehouseItemCount)
        {
            IterationsCount = 0;
            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(warehouseItemCount);

            FillTeam(ref AlphaTeam, tankCount);
            FillTeam(ref BetaTeam, tankCount);
            AlphaTeam.TeamColor = Colors.Blue;
            BetaTeam.TeamColor = Colors.Red;
            AlphaTeam.Name = "Alpha";
            BetaTeam.Name = "Beta";
            gunplay = new Gunplay(AlphaTeam, BetaTeam);
            DisplayStrategies();
            UpdateLVs();

        }
        private void Iterate(object sender, RoutedEventArgs e)
        {
            RemoveDeads();
            Regen();
            if(AlphaTeam.Tanks.Count > 0 && BetaTeam.Tanks.Count > 0)
            {
                ShellExchange();
                IterationsCount++;
                IterationLBL.Content = IterationsCount.ToString();
                WinCheck();
            }
            UpdateLVs();

        }
        
        
    }
}