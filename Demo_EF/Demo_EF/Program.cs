using Demo_EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configurar el serializador para evitar ciclos de referencia
builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<SchoolContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("SchoolContextConnection")));
//AddDbContext<SchoolContext>:
//Este método de extensión se usa para registrar el contexto de la base de datos SchoolContext
//en el contenedor de dependencias.
//Esto permite que SchoolContext se inyecte en los controladores
//y otros servicios a través de la inyección de dependencias.
//---
//options => options.UseSqlServer(...):
//Aquí se configura DbContextOptions para SchoolContext.
//Se utiliza una expresión lambda para configurar las opciones específicas del contexto de la base de datos.


//builder.Configuration accede a la configuración de la aplicación (normalmente, los valores del archivo appsettings.json, variables de entorno, etc.).
//GetConnectionString("SchoolContextConnection") obtiene la cadena de conexión que se ha definido en appsettings.json bajo el nombre SchoolContextConnection.
//Esta cadena de conexión contiene la información necesaria para conectarse a la base de datos SQL Server.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
