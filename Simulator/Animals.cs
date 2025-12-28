using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {
        private string _description = "";
        private int _size;

        public string Description
        {
            get => _description;
            set => _description = Validator.Shortener(value, 3, 25, '#');
        }

        public int Size
        {
            get => _size;
            set => _size = Validator.Limiter(value, 1, 5000);
        }

        public Animals()
        {
            Description = "Unknown";
            Size = 3;
        }

        public virtual string Info => $"{Description} <{Size}>";

        public virtual char Symbol => 'A';

        public override string ToString()
            => $"{GetType().Name.ToUpper()}: {Info}";
    }
}
