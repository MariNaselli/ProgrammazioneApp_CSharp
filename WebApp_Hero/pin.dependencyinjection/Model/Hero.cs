
namespace pin.dependencyinjection.Model
{
    public class Hero
    {
        public Hero(string id, int hp, IWeapon weapon, IArmor armor)
        {
            Id = id;
            Hp = hp;
            Weapon = weapon;
            Armor = armor;
        }
        public string Id { get; set; }
        public int Hp { get; set; }
        public IWeapon Weapon { get; set; }
        public IArmor Armor { get; set; }

        public int? UseWeapon()
        {
            if (Hp == 0)
                throw new DeadHeroException($"Hero {Id} is dead");

            var damage = Weapon.Strike();

            return damage;
        }

        public int Defend(int damage)
        {
            if (Hp == 0)
                throw new DeadHeroException($"Hero {Id} is dead");

            if (!Armor.AbsorbDamage(damage))
            {
                if (damage > Hp)
                {
                    Hp = 0;
                    throw new DeadHeroException($"Hero {Id} is dead");
                }

                Hp = Hp - damage;
            }

            return Hp;
        }
    }
}
