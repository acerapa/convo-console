using ConvoConsole.auth;
using ConvoConsole.Models;

namespace ConvoConsole
{
    internal class Auth
    {
        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The user object</returns>
        public static User Login(Credentials credentials)
        {
            Console.WriteLine($"Logining in using username: {credentials.Username} and password: {credentials.Password}");

            return new User();
        }
    }
}