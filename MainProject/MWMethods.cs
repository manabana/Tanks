using MainProject.Builders;
using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject
{
    public partial class MainWindow : Window
    {
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
        }
        private void Win(Team team)
        {

        }
        private void FillTeam(ref Team team, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var tank = BuilderTools.GetRandomTankBuilder().AutoGenerateTank();
                team.Tanks.Add(tank);
            }
        }

    }
}
