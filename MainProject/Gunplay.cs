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
        public void AlphaAttackBeta(Tank attacker)
        {
            if(RandomTools.rand.NextDouble() > attacker.Weapon.MissChance)
            {
                var tank = AlphaTeam.Strategy.AttackSelection(BetaTeam.Tanks);
                tank.Damaging(attacker.GetDamageInfo());
            }
        }
        public void BetaAttackAlpha(Tank attacker)
        {
            if(RandomTools.rand.NextDouble() > attacker.Weapon.MissChance)
            {
                var tank = BetaTeam.Strategy.AttackSelection(AlphaTeam.Tanks);
                tank.Damaging(attacker.GetDamageInfo());
            }
            
        }


    }
}