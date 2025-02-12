using ConvoConsole.Auth;
using ConvoConsole.Models;

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
                "| 4. Get All Users (Debug)                     |\n" +
                "| 5. Delete User (Debug)                       |\n" +
                "| 6. Update User (Debug)                       |\n" +
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
        /// Display user form
        /// We can use this form to create or update user
        /// </summary>
        /// <returns>Void</returns>
        public static User UserForm(User? user = null)
        {
            User returnedUser = new();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (user != null)
            {
                Console.WriteLine(
                    "+------------------------+\n" +
                    "|       Update User       |\n" +
                    "+------------------------+"
                );

                returnedUser = user;
            }
            else
            {
                Console.WriteLine(
                    "+-------------------------+\n" +
                    "|       Register          |\n" +
                    "+-------------------------+"
                );

            }

            string input = "";

            Console.ResetColor();
            Console.Write(string.Format("Enter your first name{0}: ", user != null ? $" ({user.FirstName})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.FirstName = input.Length > 0 ? input : (user != null ? user.FirstName : "");

            Console.Write(string.Format("Enter your last name{0}: ", user != null ? $" ({user.LastName})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.LastName = input.Length > 0 ? input : (user != null ? user.LastName : "");

            Console.Write(string.Format("Enter your username{0}: ", user != null ? $" ({user.Username})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.Username = input.Length > 0 ? input : (user != null ? user.Username : "");

            Console.Write(string.Format("Enter your password{0}: ", user != null ? $" ({user.Password})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.Password = input.Length > 0 ? input : (user != null ? user.Password : "");

            Console.Write(string.Format("Enter your email{0}: ", user != null ? $" ({user.Email})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.Email = input.Length > 0 ? input : (user != null ? user.Email : "");

            Console.Write(string.Format("Enter your phone number{0}: ", user != null ? $" ({user.PhoneNumber})" : ""));
            input = Console.ReadLine() ?? "";
            returnedUser.PhoneNumber = input.Length > 0 ? input : (user != null ? user.PhoneNumber : "");

            return returnedUser;
        }

        /// <summary>Show given message into a success format</summary>
        /// <param name="message">The message to be shown</param>
        /// <returns>Void</returns>
        public static void ShowSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>Show given message into an error format</summary>
        /// <param name="message">The message to be shown</param>
        /// <returns>Void</returns>
        public static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }


        // Testing Users
        public static void ShowUserDetails(User user)
        {
            Console.WriteLine(
                $"User ID:        {user.Id}\n" +
                $"Username:       {user.Username}\n" +
                $"First Name:     {user.FirstName}\n" +
                $"Last Name:      {user.LastName}\n" +
                $"Email:          {user.Email}\n" +
                $"Phone Number:   {user.PhoneNumber}\n"
            );
        }
    }
}
