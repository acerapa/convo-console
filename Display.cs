using ConvoConsole.Auth;

namespace ConvoConsole
{
    internal class Display
    {
        /// <summary>
        /// Display the greetings
        /// </summary>
        public static void Greetings()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "+------------------------------------------------+\n" +
                "|  Hello, Welcome to Convo Console!              |\n" +
                "|  Thank you for chooosing Convo Console!        |\n" +
                "+------------------------------------------------+\n"
            );
            Console.ResetColor();
        }

        /// <summary>
        /// Display the goodbye message
        /// </summary>
        public static void GoodBye()
        {
            Console.WriteLine("Thank you for using Convo Console!");
        }

        /// <summary>
        /// Display the invalid choice message
        /// </summary>
        public static void InvalidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please try again.");
            Console.ResetColor();
        }

        /// <summary>
        /// Display the menu for authenticated user
        /// </summary>
        public static string UnauthenticatedMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "+----------------------------------------------+\n" +
                "| ******************************************** |\n" +
                "| * Please select action from the following: * |\n" +
                "| ******************************************** |\n" +
                "| 1. Login                                     |\n" +
                "| 2. Register                                  |\n" +
                "| 3. Exit                                      |\n" +
                "+----------------------------------------------+"
            );
            Console.ResetColor();
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


        /// <summary>
        /// Display user registration form
        /// </summary>
        /// <returns>Void</returns>
        public static object RegisterForm()
        {
            Console.WriteLine("Register");
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine() ?? "";
            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? "";
            Console.Write("Enter your email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine() ?? "";

            return new
            {
                username,
                password,
                email,
                firstName,
                lastName,
                phoneNumber
            };
        }
    }
}