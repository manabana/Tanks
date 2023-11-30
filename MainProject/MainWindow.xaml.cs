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
            AlphaTeam.TeamColor = Colors.Blue;
            #endregion
            #region Team 2
            for (int i = 0; i < tankscount; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                BetaTeam.Tanks.Add(tank);
            }
            BetaTeam.TeamColor = Colors.Red;
            #endregion
            gunplay = new Gunplay(AlphaTeam, BetaTeam);


        }
        public void DisplayAlpha()
        {

        }
        public void DisplayBeta()
        {

        }

        private void Iterate(object sender, RoutedEventArgs e)
        {
            foreach (Tank tank in AlphaTeam.Tanks)
            {
                if (tank.Health.HealthValue <= 0)
                {
                    AlphaTeam.Tanks.Remove(tank);
                }
            }
            foreach (Tank tank in BetaTeam.Tanks)
            {
                if (tank.Health.HealthValue <= 0)
                {
                    AlphaTeam.Tanks.Remove(tank);
                }
            }

            foreach(Tank tank in AlphaTeam.Tanks)
            {
                gunplay.AlphaAttackBeta(tank);
            }
            foreach(Tank tank1 in BetaTeam.Tanks)
            {
                gunplay.BetaAttackAlpha(tank1);
            }


        }
    }
}
