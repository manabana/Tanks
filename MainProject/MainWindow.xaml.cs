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
        public static Team AlphaTeam;
        public static Team BetaTeam;
        private Gunplay gunplay;
        public int IterationsCount { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            IterationsCount = 0;
            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(20);

            int tankscount = 5;

            
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
            LV.ItemsSource = null;
            LV2.ItemsSource = null;
            LV.ItemsSource = AlphaTeam.GetSimplyfied();
            LV2.ItemsSource = BetaTeam.GetSimplyfied();

        }

        private void AutoIterate(object sender, RoutedEventArgs e)
        {

        }

        private void StopIterating(object sender, RoutedEventArgs e)
        {

        }
    }
}