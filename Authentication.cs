using ConvoConsole.Auth;
using ConvoConsole.Models;

namespace ConvoConsole
{
    internal class Authtentication
    {
        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="credentials">User credentials used in authentication</param>
        /// <returns>The user object</returns>
        public static User Login(Credentials credentials)
        {
            Console.WriteLine($"Logining in using username: {credentials.Username} and password: {credentials.Password}");

            return new User();
        }
    }
}
