using AdopcionesModels;
using System.Data.SQLite;

namespace AdopcionesDAL
{
    public class SqlAnimalesTipos
    {
        string connectionString = string.Empty;
        public SqlAnimalesTipos(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<AnimalTipo> GetAnimalesTiposList()
        {
            List<AnimalTipo> animalesTipos = new List<AnimalTipo>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AT.id_tipo, AT.nombre_tipo FROM animales_tipos AT";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnimalTipo tipo = new AnimalTipo();
                            tipo.Id_tipo = Convert.ToInt32(reader["id_tipo"]);
                            tipo.Nombre_tipo = Convert.ToString(reader["nombre_tipo"]);                           
                            animalesTipos.Add(tipo);
                        }
                    }
                }
            }

            return animalesTipos;
        }
    }
}
