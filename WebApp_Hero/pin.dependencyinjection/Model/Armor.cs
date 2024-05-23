
namespace pin.dependencyinjection.Model
{
    public class Armor : IArmor
    {
        public Armor(int duration)
        {
            if (duration < 0)
                throw new ArgumentOutOfRangeException(nameof(duration));

            Duration = duration;
        }

        public int Duration { get; set; }

        public bool AbsorbDamage(int damage)
        {
            if (damage > Duration)
            {
                Duration = 0;
            }
            else
            {
                Duration = Duration - damage;
            }

            return Duration > 0;
        }
    }
}
