namespace HeroesApp.Models;

public class Hero
{

    public Hero(string id, string name, IArmor armor, IWeapon weapon, int score)
    {
        Id = id;
        Name = name;
        Armor = armor;
        Weapon = weapon;
        Score = score;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public IArmor Armor { get; set; }
    public IWeapon Weapon { get; set; }
    public int Score { get; set; }

  
    public int? UseWeapon()
    {
        if (Score == 0)
            throw new DeadHeroException($"Hero {Id} is dead");

        var damage = Weapon.Score();

        return damage;
    }

    public int Defend(int damage)
    {
        if (Score == 0)
            throw new DeadHeroException($"Hero {Id} is dead");

        if (!Armor.AbsorbDamage(damage))
        {
            if (damage > Score)
            {
                Score = 0;
                throw new DeadHeroException($"Hero {Id} is dead");
            }

            Score = Score - damage;
        }

        return Score;
    }


}

