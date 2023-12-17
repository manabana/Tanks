using MainProject.Builders;
using MainProject.Strategies;
using MainProject.TankAttributes.Armors;
using MainProject.TankAttributes.Healths;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            #region Танки выбирают цель
            foreach (Tank tank in AlphaTeam.Tanks)
            {
                gunplay.AlphaSelectBeta(tank);
            }
            foreach (Tank tank in BetaTeam.Tanks)
            {
                gunplay.BetaSelectAlpha(tank);
            }
            #endregion
            #region Танки стреляют
            foreach (Tank tank in AlphaTeam.Tanks)
            {
                gunplay.AlphaAttackBeta(tank);
            }
            foreach (Tank tank1 in BetaTeam.Tanks)
            {
                gunplay.BetaAttackAlpha(tank1);
            }
            #endregion
        }
        private void RemoveDeads()
        {
            AlphaTeam.Tanks.RemoveAll(p => p.Health.HealthValue <= 0f);
            BetaTeam.Tanks.RemoveAll(p => p.Health.HealthValue <= 0f);
            if (AlphaTeam.Tanks.Count <= 0)
            {
                Win(BetaTeam);
            }
            else if(BetaTeam.Tanks.Count <= 0)
            {
                Win(AlphaTeam);
            }
        }
        void WinCheck()
        {
            if (AlphaTeam.Tanks.Count == 0)
            {
                Win(BetaTeam);
            }
            else if (BetaTeam.Tanks.Count == 0)
            {
                Win(AlphaTeam);
            }
        }
        private void UpdateLVs()
        {
            LV.ItemsSource = null;
            LV2.ItemsSource = null;
            LV.ItemsSource = AlphaTeam.GetSimplyfied();
            LV2.ItemsSource = BetaTeam.GetSimplyfied();
        }

        private void WarehouseAssortiment(object sender, RoutedEventArgs e)
        {
            new WarehouseWindow(Warehouse.GetInstance()).Show();
        }
        private void PartsList(object sender, RoutedEventArgs e)
        {
            new PartsDBWindow().Show();
        }
        void Regen()
        {
            foreach (var item in AlphaTeam.Tanks)
            {
                if (item.Armor is RegeneratingArmor)
                {
                    if (item.Armor.ArmorValue > 0f && item.Armor.ArmorValue < 100)
                    {
                        item.Armor.Regenerate(3f);
                    }
                }
                if (item.Health is RegeneratingHealth)
                {
                    if (item.Health.HealthValue > 0 && item.Health.HealthValue < 100)
                    {
                        item.Armor.Regenerate(3f);
                    }
                }
            }
            foreach (var item in BetaTeam.Tanks)
            {
                if (item.Armor is RegeneratingArmor)
                {
                    if (item.Armor.ArmorValue > 0f && item.Armor.ArmorValue < 100)
                    {
                        item.Armor.Regenerate(3f);
                    }
                }
                if (item.Health is RegeneratingHealth)
                {
                    if (item.Health.HealthValue > 0 && item.Health.HealthValue < 100)
                    {
                        item.Armor.Regenerate(3f);
                    }
                }

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
                tank.Id = i;
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
        private void StartSimulation(object sender, RoutedEventArgs e)
        {
            int tanksCount = 0;
            bool checkParse = int.TryParse(TanksCountTB.Text, out tanksCount);
            int WHCount = 0;
            bool checkParse2 = int.TryParse(WHItemsCountTB.Text, out WHCount);
            if (checkParse == false)
            {
                MessageBox.Show("Не удалось определить введенное кол-во танков!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkParse == false)
            {
                MessageBox.Show("Не удалось определить введенное кол-во предметов склада!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tanksCount > WHCount)
            {
                MessageBox.Show("Кол-во танков не может превышать кол-во предметов на складе!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tanksCount > 20 || WHCount > 50)
            {
                MessageBox.Show("Вы превысили допустимые лимиты (макс. танков - 20, макс предметов на складе - 50)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (WHCount / tanksCount < 2)
            {
                MessageBox.Show("На складе на всех деталей не хватит! (Их должно быть более чем в 2 раза больше танков)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                FirstActions(tanksCount, WHCount);
                FirstForm.Visibility = Visibility.Collapsed;
                UI.Visibility = Visibility.Visible;
                FirstForm.Children.Clear();
            }


        }
        void TB_DIGIT(object sender, TextCompositionEventArgs e)

        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

    }
}
