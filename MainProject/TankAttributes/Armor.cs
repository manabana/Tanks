namespace MainProject.TankAttributes
{
    public abstract class Armor : IDamageable
    {
        protected float AV;
        public float ArmorValue
        {
            get
            {
                return AV;
            }
            set
            {
                float av = value;
                if(av < 0f)
                {
                    av = 0f;
                }
                AV = av;
            }
        }
        public Health Health { get; set; }
        public Armor() { }
        public virtual void ApplyModifier(float modificator)
        {
            ArmorValue *= modificator;
        }
        public void Regenerate(float value)
        {
            ArmorValue += value;
        }
        public abstract void Damaged(DamageInfo damage);
    }
}
