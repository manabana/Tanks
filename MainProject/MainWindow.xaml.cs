using MainProject.Builders;
using MainProject.Tanks;
using System.Windows;
using System.Windows.Media;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Team AlphaTeam = new Team();
        public static Team BetaTeam = new Team();
        private Gunplay gunplay;
        public int IterationsCount { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            IterationsCount = 0;
            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(20);

            int tankscount = 5;

            for (int i = 0; i < tankscount; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                AlphaTeam.Tanks.Add(tank);
            }
            FillTeam(ref AlphaTeam, tankscount);
            FillTeam(ref BetaTeam, tankscount);
            AlphaTeam.TeamColor = Colors.Blue;
            BetaTeam.TeamColor = Colors.Red;
            gunplay = new Gunplay(AlphaTeam, BetaTeam);
        }

        private void Iterate(object sender, RoutedEventArgs e)
        {
            RemoveDeads();
            ShellExchange();
            IterationsCount++;
            IterationLBL.Content = IterationsCount.ToString();
            if (AlphaTeam.Tanks.Count == 0) 
            {
                Win(BetaTeam);
            }
            else if(BetaTeam.Tanks.Count == 0)
            {
                Win(AlphaTeam);
            }
        }

        private void AutoIterate(object sender, RoutedEventArgs e)
        {

        }

        private void StopIterating(object sender, RoutedEventArgs e)
        {

        }
    }
}