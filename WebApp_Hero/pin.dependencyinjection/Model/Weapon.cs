
namespace pin.dependencyinjection.Model
{
    public class Weapon : IWeapon
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public Weapon(int mindamage, int maxdamage)
        {
            if (mindamage < 0)
                throw new ArgumentOutOfRangeException(nameof(mindamage));

            if (maxdamage < 0)
                throw new ArgumentOutOfRangeException(nameof(maxdamage));

            Mindamage = mindamage;
            Maxdamage = maxdamage;
        }

        public int Mindamage { get; set; }
        public int Maxdamage { get; set; }

        public int? Strike()
        {
            return random.Next((int)Mindamage, Maxdamage);
        }
    }
}
