namespace HeroesApp.Models
{
    public class Armor :IArmor
    {
        public int Durability { get; private set; }

        public Armor(int durability)
        {
            if (durability < 0)
                throw new ArgumentOutOfRangeException(nameof(durability));

            Durability = durability;
        }

        public bool AbsorbDamage(int damage)
        {
            if (damage > Durability)
            {
                Durability = 0;
            }
            else
            {
                Durability = Durability - damage;
            }

            return Durability > 0;
        }

        //Implementa el método AbsorbDamage() definido en la interfaz IArmor.
        //Gestiona la absorción de daño por parte de la armadura,
        //reduciendo su durabilidad en función del daño recibido
        //y devolviendo true si la armadura sigue intacta o false si se destruyó.
    }
}
