using Simulator.Maps;

namespace Simulator
{
    public class Birds : Animals
    {
        public bool CanFly { get; set; } = true;

        public override string Info
            => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";

        public override char Symbol => CanFly ? 'B' : 'b';

        public override void Go(Direction direction)
        {
            if (CurrentMap == null || Position == null)
                return;

            var from = Position.Value;

            Point to = from;

            if (CanFly)
            {
                to = CurrentMap.Next(to, direction);
                to = CurrentMap.Next(to, direction);
            }
            else
            {
                to = CurrentMap.NextDiagonal(to, direction);
            }

            CurrentMap.Move(this, from, to);
            Position = to;
        }
    }
}
