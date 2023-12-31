﻿using MainProject.TankAttributes;

namespace MainProject.Tanks
{
    public abstract class Tank
    {
        public int Id {  get; set; }
        public abstract float Modificator { get; }
        public Armor Armor { get; protected set; }
        public Health Health { get; protected set; }
        public IWeapon Weapon { get; protected set; }
        public IShell Shell { get; protected set; }
        public Tank SelectedTarget { get; protected set; }
        public void AddShell(IShell newshell)
        {
            if (Shell == null)
            {
                Shell = newshell;
            }
        }
        public void AddWeapon(IWeapon weapon)
        {
            if (Weapon == null)
            {
                Weapon = weapon;
            }
        }
        public void AddArmor(Armor newarmor)
        {
            if (Armor == null)
            {
                Armor = newarmor;
            }
        }
        public void AddHealth(Health newhealth)
        {
            if (Health == null)
            {
                Health = newhealth;
            }
        }

        public DamageInfo GetDamageInfo()
        {
            DamageInfo damage = new DamageInfo(this, Shell);
            return damage;
        }
        public void Damaging(DamageInfo damageinfo)
        {
            Armor.Damaged(damageinfo);
        }
        public void ModifyAll()
        {
            Armor.ApplyModifier(Modificator);
            Health.ApplyModifier(Modificator);
        }
        public void SelectTarget(Tank target)
        {
            SelectedTarget = target;
        }
    }
}
