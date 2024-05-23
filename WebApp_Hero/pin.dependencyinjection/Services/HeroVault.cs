using pin.dependencyinjection.Interfaces;
using pin.dependencyinjection.Model;

namespace pin.dependencyinjection.Services
{
    public class HeroVault : IHeroVault
    {
        public HeroVault()
        {
            Heroes = new List<Hero>();

            Heroes.Add(new Hero("hero_1", 100, new Weapon(20, 70), new Armor(30)));
            Heroes.Add(new Hero("hero_2", 100, new Weapon(20, 70), new Armor(30)));
            Heroes.Add(new Hero("hero_3", 100, new Weapon(20, 70), new Armor(30)));
            Heroes.Add(new Hero("hero_4", 100, new Weapon(20, 70), new Armor(30)));
            Heroes.Add(new Hero("hero_5", 100, new Weapon(20, 70), new Armor(30)));

        }

        public List<Hero> Heroes { get; }

        public Hero GetHero(string id)
        {
            return Heroes.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return Heroes;
        }
    }
}
