using ConvoConsole.auth;

namespace ConvoConsole
{
    internal class Display
    {
        /// <summary>
        /// Display the greetings
        /// </summary>
        public static void Greetings()
        {
            Console.WriteLine("Hello, Welcome to Convo Console!");
            Console.WriteLine("Please select action from the following:");
        }

        /// <summary>
        /// Display the goodbye message
        /// </summary>
        public static void GoodBye() {
            Console.WriteLine("Thank you for using Convo Console!");
        }

        /// <summary>
        /// Display the menu for authenticated user
        /// </summary>
        public static string UnauthenticatedMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine() ?? "";
            return choice;
        }

        /// <summary>
        /// Display the form for login
        /// </summary>
        /// <returns>The credentials object</returns>
        public static Credentials LoginForm()
        {
            Console.WriteLine("Login");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? "";

            return new Credentials(username, password);
        }
    }
}