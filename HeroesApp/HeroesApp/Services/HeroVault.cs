using HeroesApp.Interfaces;
using HeroesApp.Models;

namespace HeroesApp.Services;

public class HeroVault : IHeroVault
{
    public HeroVault()
    {
        Heroes = new List<Hero>();

        Heroes.Add(new Hero("1", "Superman", new Armor(30), new Weapon(20, 70), 100));
        Heroes.Add(new Hero("2", "Spiderman", new Armor(30), new Weapon(20, 70), 100));
        Heroes.Add(new Hero("3", "Iroman", new Armor(30), new Weapon(20, 70), 100));
        Heroes.Add(new Hero("4", "Batman", new Armor(30), new Weapon(20, 70), 100));
        Heroes.Add(new Hero("5", "BluWit", new Armor(30), new Weapon(20, 70), 100));

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

