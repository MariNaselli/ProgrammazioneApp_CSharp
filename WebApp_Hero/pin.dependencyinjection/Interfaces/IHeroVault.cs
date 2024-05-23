using pin.dependencyinjection.Model;

namespace pin.dependencyinjection.Interfaces
{
    public interface IHeroVault
    {

        IEnumerable<Hero> GetHeroes();

        Hero GetHero(string id);

    }
}
