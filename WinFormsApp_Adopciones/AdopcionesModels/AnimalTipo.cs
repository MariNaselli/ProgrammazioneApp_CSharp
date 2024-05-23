using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionesModels
{
    public class AnimalTipo
    {
        int id_tipo = 0;
        string nombre_tipo = string.Empty;

        public AnimalTipo()
        {
        }

        public AnimalTipo(int id_tipo, string nombre_tipo)
        {
            this.id_tipo = id_tipo;
            this.nombre_tipo = nombre_tipo;
        }

        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public string Nombre_tipo { get => nombre_tipo; set => nombre_tipo = value; }
    }
}
