
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConvoConsole.Service
{
    internal class DatabaseService
    {
        private MySqlConnection _connection = null;

        public MySqlConnection Connect() {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

            try {
                if (connectionString.Length == 0) {
                    throw new Exception("Connection string not found");
                }

                _connection = new MySqlConnection(connectionString);

                // test connection
                _connection.Open();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return _connection;
        }
    }
}
