namespace AdopcionesApi.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            string? connectionString = _configuration.GetConnectionString("SQLLiteConnection");

            if (connectionString == null)
            {
                throw new InvalidOperationException("La cadena de conexión 'SQLLiteConnection' no está configurada en appsettings.json.");
            }

            return connectionString;
        }
    }
}
