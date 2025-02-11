using ConvoConsole.Models;
using MySql.Data.MySqlClient;

namespace ConvoConsole.Service
{
    internal class UserServices
    {
        private MySqlConnection _connection;
        public UserServices(DatabaseService dbservice)
        {
            _connection = dbservice.Connect();
        }

        /// <summary>Create a new user</summary>
        /// <param name="user">The user about to be save to the database</param>
        /// <returns>Returns int which represents the rows affected</returns>
        public int CreateUser(User user)
        {
            MySqlCommand command = _connection.CreateCommand();

            int result = 0;

            try
            {
                command.CommandText = "INSERT INTO users (username, password, email, first_name, last_name, phone_number) VALUES (@username, @password, @email, @first_name, @last_name, @phone_number)";
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@first_name", user.FirstName);
                command.Parameters.AddWithValue("@last_name", user.LastName);
                command.Parameters.AddWithValue("@phone_number", user.PhoneNumber);
                result = command.ExecuteNonQuery();
            } catch (Exception ex) {
                // TODO: Nice to have a logger to log the errors
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            return result;
        }
    }
}