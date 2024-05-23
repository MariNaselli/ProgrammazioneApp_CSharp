namespace HeroesApp.Models;

public interface IWeapon //define un metodo para atacar
{
    int? Score(); //metodo para atacar, devuelve el daño
}
//aca defino lo que un ataque debe poder hacer sin especificar como lo hace