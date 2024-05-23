namespace HeroesApp.Models;

public interface IArmor //Define un método para absorber daño.
{
    bool AbsorbDamage(int damage);
}
//Aca defino lo que una armadura debe poder hacer sin especificar como lo  hacer