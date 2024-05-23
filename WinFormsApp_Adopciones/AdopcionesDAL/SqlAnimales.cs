using System.Data.SQLite;
using System.Data;
using AdopcionesModels;

namespace AdopcionesDAL
{
    public class SqlAnimales
    {
        private readonly string connectionString;

        public SqlAnimales(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<List<Animal>> GetAnimalesListAsync(string nombre)
        {
            List<Animal> animales = new List<Animal>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = @"SELECT 
                                    AL.id_animal, AL.nombre, AL.fecha_nacimiento, 
                                    AL.genero, AL.descripcion, AL.fecha_ingreso, AL.id_tipo,
                                    AT.nombre_tipo 
                                FROM Animales AL 
                                INNER JOIN animales_tipos AT ON AT.id_tipo = AL.id_tipo
                                WHERE AL.nombre LIKE @nombre AND AL.eliminado = 0";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                Animal animal = new Animal
                                {
                                    Id_animal = Convert.ToInt32(reader["id_animal"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                                    Genero = reader["genero"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                    Fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                    Tipo = new AnimalTipo
                                    {
                                        Id_tipo = Convert.ToInt32(reader["id_tipo"]),
                                        Nombre_tipo = reader["nombre_tipo"].ToString()
                                    }
                                };
                                animales.Add(animal);
                            }
                        }
                        else
                        {
                            throw new Exception("El lector de datos es nulo.");
                        }
                    }
                }
            }

            return animales;
        }

        //public class SqlAnimales
        //{
        //    string connectionString = string.Empty;
        //    public SqlAnimales(string connectionString)
        //    {
        //        this.connectionString = connectionString;
        //    }

        //public List<Animal> GetAnimalesList(string nombre)
        //{
        //    List<Animal> animales = new List<Animal>();

        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = @"SELECT 
        //                            AL.id_animal, AL.nombre, AL.fecha_nacimiento, 
        //                            AL.genero, AL.descripcion, AL.fecha_ingreso, AL.id_tipo,
        //                            AT.nombre_tipo 
        //                        FROM Animales AL INNER JOIN animales_tipos AT ON AT.id_tipo = AL.id_tipo
        //                        WHERE AL.nombre LIKE '%" + nombre + "%'" +
        //                        " AND AL.eliminado = 0";
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Animal animal = new Animal();
        //                    animal.Id_animal = Convert.ToInt32(reader["id_animal"]);
        //                    animal.Nombre = reader["nombre"].ToString();
        //                    animal.Fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);
        //                    animal.Genero = reader["genero"].ToString();
        //                    animal.Descripcion = reader["descripcion"].ToString();
        //                    animal.Fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);
        //                    // Aquí necesitas instanciar y configurar un objeto AnimalTipo, supongamos que tienes un constructor que acepta el tipo de animal
        //                    animal.Tipo = new AnimalTipo();
        //                    animal.Tipo.Id_tipo = Convert.ToInt32(reader["id_tipo"]);
        //                    animal.Tipo.Nombre_tipo = reader["nombre_tipo"].ToString();
        //                    animales.Add(animal);
        //                }
        //            }
        //        }
        //    }

        //    return animales;
        //}

        //public async Task<List<Animal>> GetAnimalesListAsync(string nombre)
        //{
        //    List<Animal> animales = new List<Animal>();

        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        await connection.OpenAsync();

        //        string query = @"SELECT 
        //                    AL.id_animal, AL.nombre, AL.fecha_nacimiento, 
        //                    AL.genero, AL.descripcion, AL.fecha_ingreso, AL.id_tipo,
        //                    AT.nombre_tipo 
        //                FROM Animales AL INNER JOIN animales_tipos AT ON AT.id_tipo = AL.id_tipo
        //                WHERE AL.nombre LIKE '%" + nombre + "%'" +
        //                        " AND AL.eliminado = 0";

        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            using (SQLiteDataReader reader = await command.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    Animal animal = new Animal();
        //                    animal.Id_animal = Convert.ToInt32(reader["id_animal"]);
        //                    animal.Nombre = reader["nombre"].ToString();
        //                    animal.Fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);
        //                    animal.Genero = reader["genero"].ToString();
        //                    animal.Descripcion = reader["descripcion"].ToString();
        //                    animal.Fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);
        //                    // Aquí necesitas instanciar y configurar un objeto AnimalTipo, supongamos que tienes un constructor que acepta el tipo de animal
        //                    animal.Tipo = new AnimalTipo();
        //                    animal.Tipo.Id_tipo = Convert.ToInt32(reader["id_tipo"]);
        //                    animal.Tipo.Nombre_tipo = reader["nombre_tipo"].ToString();
        //                    animales.Add(animal);
        //                }
        //            }
        //        }
        //    }

        //    return animales;
        //}


        public void InsertAnimal(Animal animal)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO animales 
                                 (nombre, fecha_nacimiento, genero, descripcion, fecha_ingreso, id_tipo)
                                 VALUES 
                                 (@nombre, @fecha_nacimiento, @genero, @descripcion, @fecha_ingreso, @id_tipo)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", animal.Nombre);
                    command.Parameters.AddWithValue("@fecha_nacimiento", animal.Fecha_nacimiento);
                    command.Parameters.AddWithValue("@genero", animal.Genero);
                    command.Parameters.AddWithValue("@descripcion", animal.Descripcion);
                    command.Parameters.AddWithValue("@fecha_ingreso", animal.Fecha_ingreso);
                    command.Parameters.AddWithValue("@id_tipo", animal.Tipo.Id_tipo);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAnimal(Animal animal)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE animales 
                                 SET nombre = @nombre,
                                     fecha_nacimiento = @fecha_nacimiento,
                                     genero = @genero,
                                     descripcion = @descripcion,
                                     fecha_ingreso = @fecha_ingreso,
                                     id_tipo = @id_tipo
                                 WHERE id_animal = @id_animal";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", animal.Nombre);
                    command.Parameters.AddWithValue("@fecha_nacimiento", animal.Fecha_nacimiento);
                    command.Parameters.AddWithValue("@genero", animal.Genero);
                    command.Parameters.AddWithValue("@descripcion", animal.Descripcion);
                    command.Parameters.AddWithValue("@fecha_ingreso", animal.Fecha_ingreso);
                    command.Parameters.AddWithValue("@id_tipo", animal.Tipo.Id_tipo);
                    command.Parameters.AddWithValue("@id_animal", animal.Id_animal);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAnimal(int id_animal)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE animales 
                                 SET eliminado = 1
                                 WHERE id_animal = @id_animal";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_animal", id_animal);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Animal> GetAnimalesTiposList(string textoBuscar)
        {
            throw new NotImplementedException();
        }
    }
}


