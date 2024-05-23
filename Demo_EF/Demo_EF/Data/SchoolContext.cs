using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Data;
public class SchoolContext : DbContext //DbContext es la clase base de Entity Framework Core
//que representa una sesión con la base de datos y permite realizar consultas y guardar datos.
{

    public SchoolContext(DbContextOptions<SchoolContext> dbContextOptions): base(dbContextOptions)
    {

    }

    //Este es el constructor de la clase SchoolContext.
    //Acepta un parámetro de tipo DbContextOptions<SchoolContext>
    //y lo pasa al constructor de la clase base DbContext.
    //DbContextOptions contiene la configuración de la base de datos
    //(por ejemplo, la cadena de conexión y otras opciones).

    
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(connectionString: "Server=localhost\\SQLEXPRESS02;Database=master;Trusted_Connection=True;"); //TrustServerCertificate=True
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //Este metodo se utiliza para personalizar el modelo de datos mediante el API Fluent.
    //Define las relaciones y restricciones entre las entidades
    {
        modelBuilder.Entity<Student>() //Configura la entidad Student.
            .HasOne<Grade>(s => s.Grade) //Indica que Student tiene una relación uno-a-uno con Grade. La propiedad Grade en Student es la clave de navegación que define esta relación.
            .WithMany(g => g.Students) //Indica que Grade tiene una relación uno-a-muchos con Student. La colección Students en Grade es la clave de navegación inversa.
            .HasForeignKey(s => s.GradeId); //Especifica que la propiedad GradeId en Student es la clave foránea que establece la relación con Grade.
            //.OnDelete(DeleteBehavior.Cascade);
            // Si se descomenta esta linea, configuraría el comportamiento de eliminación en cascada.
            // Esto significa que si se elimina un registro de Grade, todos los registros asociados en Student también se eliminarían.
    }

}
