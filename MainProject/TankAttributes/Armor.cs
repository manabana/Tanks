namespace MainProject.TankAttributes
{
    public abstract class Armor : IDamageable
    {
        public float ArmorValue { get; protected set; }
        public Health Health { get; set; }
        public Armor() { }
        public virtual void ApplyModifier(float modificator)
        {
            ArmorValue *= modificator;
        }

        public abstract void Damaged(DamageInfo damage);
    }
}
