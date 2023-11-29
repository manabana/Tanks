using MainProject.Tanks;
using System;
using System.Collections.Generic;

namespace MainProject
{
    public class Gunplay //Обмен любезностями
    {
        public Team AlphaTeam{get; set;}
        public Team BetaTeam{get; set;}
        public Gunplay(Team team1, Team team2)
        {
            AlphaTeam = team1;
            BetaTeam = team2;
        }
        public void AlphaAttackBeta()
        {
            AlphaTeam.Strategy.AttackSelection(BetaTeam.Tanks);
        }
        public void BetaAttackAlpha()
        {
            BetaTeam.Strategy.AttackSelection(AlphaTeam.Tanks);
        }


    }
}