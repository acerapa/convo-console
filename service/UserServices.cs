using ConvoConsole.Models;
using MySql.Data.MySqlClient;

namespace ConvoConsole.Service
{
    internal class UserServices
    {
        private readonly MySqlConnection _connection;
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
                Display.ShowSuccessMessage("User created successfully!\nYou can now login using the credentials you provide");
            }
            catch (Exception ex)
            {
                // TODO: Nice to have a logger to log the errors
                Display.ShowErrorMessage(ex.Message);
            }

            return result;
        }

        public List<User> GetUsers()
        {
            List<User> users = [];
            try
            {
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM users";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new()
                    {
                        Id = reader.GetInt32(0).ToString(),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        FirstName = reader.GetString(4),
                        LastName = reader.GetString(5),
                        PhoneNumber = reader.GetString(6)
                    };

                    users.Add(user);

                    // Display user details
                    Display.ShowUserDetails(user);
                }

                reader.Close();

                Display.ShowSuccessMessage($"Retrieve {users.Count} users!");
            }
            catch (Exception ex)
            {
                Display.ShowErrorMessage(ex.Message);
            }

            return users;
        }

        public User? GetUserByUsername(string username)
        {
            User? user = null;
            try
            {
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE username = @username LIMIT 1";
                command.Parameters.AddWithValue("@username", username);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new()
                    {
                        Id = reader.GetInt32(0).ToString(),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        FirstName = reader.GetString(4),
                        LastName = reader.GetString(5),
                        PhoneNumber = reader.GetString(6)
                    };
                }

                reader.Close();
                if (user != null) {
                    Display.ShowSuccessMessage($"Retrieve user with username {username}!");
                } else {
                    throw new Exception($"User with username {username} not found!");
                }
            }
            catch (Exception ex)
            {
                Display.ShowErrorMessage(ex.Message);
            }

            return user;
        }

        public void UpdateUser(User user)
        {
            try
            {
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE users SET username = @username, password = @password, email = @email, first_name = @first_name, last_name = @last_name, phone_number = @phone_number WHERE id = @id";
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@first_name", user.FirstName);
                command.Parameters.AddWithValue("@last_name", user.LastName);
                command.Parameters.AddWithValue("@phone_number", user.PhoneNumber);
                command.Parameters.AddWithValue("@id", user.Id);
                command.ExecuteNonQuery();

                Display.ShowSuccessMessage("User updated successfully!");
            }
            catch (Exception ex)
            {
                Display.ShowErrorMessage(ex.Message);
            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM users WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                Display.ShowSuccessMessage("User deleted successfully!");
            }
            catch (Exception ex)
            {
                Display.ShowErrorMessage(ex.Message);
            }
        }
    }
}
