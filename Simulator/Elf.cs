namespace Simulator
{
    public class Elf : Creature
    {
        private int _agility;
        private int _singCount = 0;

        public int Agility
        {
            get => _agility;
            private set => _agility = Validator.Limiter(value, 0, 10);
        }

        public Elf() : base()
        {
            Agility = 1;
        }

        public Elf(string name = "Unknown", int level = 1, int agility = 1)
            : base(name, level)
        {
            Agility = agility;
        }

        public void Sing()
        {
            _singCount++;

            if (_singCount % 3 == 0)
                Agility = Agility + 1;
        }

        public override string Greeting()
            => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

        public override int Power => 8 * Level + 2 * Agility;

        public override string Info => $"{Name} [{Level}][{Agility}]";

        public override char Symbol => 'E';

        public override string ToString()
            => base.ToString();
    }
}