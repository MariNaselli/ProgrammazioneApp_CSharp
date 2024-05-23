using HeroesApp.Models;

namespace HeroesApp.Interfaces;

public interface IHeroVault
{
    IEnumerable<Hero> GetHeroes();

    Hero GetHero(string id);
}
