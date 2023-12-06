using MainProject.Builders;
using MainProject.Strategies;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject
{
    public partial class MainWindow : Window
    {
        private bool AutoIterSwitch = false;
        public void DisplayAlpha()
        {

        }
        public void DisplayBeta()
        {

        }
        private void ShellExchange()
        {
            foreach (Tank tank in AlphaTeam.Tanks)
            {
                gunplay.AlphaAttackBeta(tank);
            }
            foreach (Tank tank1 in BetaTeam.Tanks)
            {
                gunplay.BetaAttackAlpha(tank1);
            }
        }
        private void RemoveDeads()
        {
            AlphaTeam.Tanks.RemoveAll(p => p.Health.HealthValue <= 0);
            BetaTeam.Tanks.RemoveAll(p => p.Health.HealthValue <= 0);
            if (AlphaTeam.Tanks.Count <= 0)
            {
                Win(BetaTeam);
            }
            else if(BetaTeam.Tanks.Count <= 0)
            {
                Win(AlphaTeam);
            }
        }
        private void DisplayStrategies()
        {
            if (AlphaTeam.Strategy is RandomTarget)
            {
                AlphaStrategy.Text = "Random Target";
            }
            else if (AlphaTeam.Strategy is LowHPTarget)
            {
                AlphaStrategy.Text = "Low HP Target";
            }
            else if (AlphaTeam.Strategy is LightestTarget)
            {
                AlphaStrategy.Text = "Lightest Target";
            }

            if (BetaTeam.Strategy is RandomTarget)
            {
                BetaStrategy.Text = "Random Target";
            }
            else if (BetaTeam.Strategy is LowHPTarget)
            {
                BetaStrategy.Text = "Low HP Target";
            }
            else if (BetaTeam.Strategy is LightestTarget)
            {
                BetaStrategy.Text = "Lightest Target";
            }
        }
        private void Win(Team team)
        {
            WinnerLBL.Content = team.Name + " Win";
            UI.Visibility = Visibility.Collapsed;
            WinUI.Visibility = Visibility.Visible;
            AutoIterSwitch = false;
        }
        private void FillTeam(ref Team team, int count)
        {
            if(team == null)
            {
                team = new Team();
            }
            for (int i = 0; i < count; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                team.Tanks.Add(tank);
            }
        }
        private async void AutoIterate(object sender, RoutedEventArgs e)
        {
            AutoIterSwitch = true;
            AutoBTN.Visibility = Visibility.Collapsed;
            StopAutoBTN.Visibility = Visibility.Visible;
            await Task.Run(() => AIter());
        }
        private void AIter()
        {
            while (AutoIterSwitch) 
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(() => Iterate(null,null));
            }
        }
        private void StopIterating(object sender, RoutedEventArgs e)
        {
            AutoIterSwitch = false;
            AutoBTN.Visibility = Visibility.Visible;
        }

        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RestartProgram(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow(); // создаем новый экземпляр главного окна
            newWindow.Show(); // показываем новое окно
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow.Close();
        }
    }
}
