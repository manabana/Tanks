using MainProject.Builders;
using MainProject.Strategies;
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
            if(AlphaTeam.Tanks.Count > 0 && BetaTeam.Tanks.Count > 0)
            {
                ShellExchange();
                IterationsCount++;
                IterationLBL.Content = IterationsCount.ToString();
                if (AlphaTeam.Tanks.Count == 0)
                {
                    Win(BetaTeam);
                }
                else if (BetaTeam.Tanks.Count == 0)
                {
                    Win(AlphaTeam);
                }
            }
            UpdateLVs();

        }
        private void UpdateLVs()
        {
            LV.ItemsSource = null;
            LV2.ItemsSource = null;
            LV.ItemsSource = AlphaTeam.GetSimplyfied();
            LV2.ItemsSource = BetaTeam.GetSimplyfied();
        }

    }
}