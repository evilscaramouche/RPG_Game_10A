namespace RPG_Game
{
    public abstract class Character
    {
        private string _name;
        private int _health;
        private int _maxHealth;
        private int _strength;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public int Health
        {
            get => _health;
            protected set => _health = Math.Max(0, Math.Min(value, _maxHealth));
        }

        public int MaxHealth
        {
            get => _maxHealth;
            protected set => _maxHealth = value;
        }

        public int Strength
        {
            get => _strength;
            protected set => _strength = value;
        }

        public bool IsAlive => Health > 0;

        protected Character(string name, int health, int strength)
        {
            _name = name;
            _maxHealth = health;
            _health = health;
            _strength = strength;
        }

        public abstract void Attack(Character target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}/{MaxHealth}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} heals {amount} health. Current health: {Health}/{MaxHealth}");
        }
    }

}
