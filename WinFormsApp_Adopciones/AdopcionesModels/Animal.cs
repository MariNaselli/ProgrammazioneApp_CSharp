
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionesModels
{
    public class Animal
    {
        int id_animal = 0;
        string nombre = string.Empty;
        DateTime fecha_nacimiento = new DateTime();
        string genero = string.Empty;
        string descripcion = string.Empty;
        DateTime fecha_ingreso = new DateTime();
        AnimalTipo tipo = new AnimalTipo();

        public Animal() { }

        public Animal(int id_animal, string nombre, DateTime fecha_nacimiento, string genero, string descripcion, DateTime fecha_ingreso, AnimalTipo tipo)
        {
            this.Id_animal = id_animal;
            this.Nombre = nombre;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Genero = genero;
            this.Descripcion = descripcion;
            this.Fecha_ingreso = fecha_ingreso;
            this.Tipo = tipo;
        }

        public int Id_animal { get => id_animal; set => id_animal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public AnimalTipo Tipo { get => tipo; set => tipo = value; }
    }
}
