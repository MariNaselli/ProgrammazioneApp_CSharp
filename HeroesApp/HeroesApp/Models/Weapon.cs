namespace HeroesApp.Models
{
    public class Weapon : IWeapon
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        //Declara un generador de números aleatorios para calcular el daño.
        

        public Weapon(int minDamage, int maxDamage)
        {
            if (minDamage < 0)
                throw new ArgumentOutOfRangeException(nameof(minDamage));

            if (maxDamage < 0)
                throw new ArgumentOutOfRangeException(nameof(maxDamage
                    ));

            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public int MinDamage { get; }
        public int MaxDamage { get; }

        public int? Score() //Implementa el método Score definido en la interfaz
        {
            return _random.Next(MinDamage, MaxDamage);
        }
    }
}
