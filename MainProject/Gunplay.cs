using MainProject.Tanks;
using System;
using System.Collections.Generic;
using System.Windows;

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
        public void AlphaAttackBeta(Tank attacker)
        {
            if(RandomTools.rand.NextDouble() >= attacker.Weapon.MissChance)
            {
                if(attacker.SelectedTarget != null)
                {
                    attacker.SelectedTarget.Damaging(attacker.GetDamageInfo());
                }
            }
        }
        public void BetaAttackAlpha(Tank attacker)
        {
            if (RandomTools.rand.NextDouble() >= attacker.Weapon.MissChance)
            {
                if (attacker.SelectedTarget != null)
                {
                    attacker.SelectedTarget.Damaging(attacker.GetDamageInfo());
                }
            }

        }
        public void AlphaSelectBeta(Tank attacker)
        {
            attacker.SelectTarget(AlphaTeam.Strategy.AttackSelection(BetaTeam.Tanks));
        }
        
        public void BetaSelectAlpha(Tank attacker)
        {
            attacker.SelectTarget(BetaTeam.Strategy.AttackSelection(AlphaTeam.Tanks));
        }


    }
}