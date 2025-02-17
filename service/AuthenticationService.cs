using ConvoConsole.Auth;
using ConvoConsole.Models;
using MySql.Data.MySqlClient;

namespace ConvoConsole.Service {
    internal class AuthenticationService {
        private readonly MySqlConnection _connection;
        private readonly UserServices userService;

        public AuthenticationService(DatabaseService dbservice)
        {
            _connection = dbservice.Connect();
            userService = new UserServices(dbservice);
        }

        public User? Login(Credentials credentials)
        {
            User? user = null;
            User? authUser = userService.GetUserByUsername(credentials.Username);
            if (authUser != null) {
                if (authUser.Password == credentials.Password) {
                    user = authUser;
                    Display.ShowSuccessMessage($"Welcome {user.FirstName} {user.LastName}!");
                } else {
                    Display.ShowErrorMessage("Invalid credentials!");
                }
            } else {
                Display.ShowErrorMessage("Invalid credentials!");
            }

            return user;
        }
    }
}