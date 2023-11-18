namespace MainProject.TankAttributes
{
    public abstract class Armor : IDamageable
    {
        public float ArmorValue { get; protected set; }
        public Armor() { }
        public void ApplyModifier(float modificator)
        {
            ArmorValue *= modificator;
        }

        public abstract void Damaged(DamageInfo damage);
    }
}
