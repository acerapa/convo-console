using ConvoConsole.Auth;
using ConvoConsole.Components;
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
                "| 7. Get user by username (Debug)              |\n" +
                "| 8. Show authenticated user (Debug)           |\n" +
                "+----------------------------------------------+"
            );
            Console.ResetColor();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine() ?? "";
            return choice;
        }

        public static string AuthenticatedMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "+----------------------------------------------+\n" +
                "| ******************************************** |\n" +
                "| * Please select action from the following: * |\n" +
                "| ******************************************** |\n" +
                "| 1. Logout                                    |\n" +
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                    "+------------------------+\n" +
                    "|         Login          |\n" +
                    "+------------------------+"
                );
            Console.ResetColor();

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
        public static User? UserForm(User? user = null)
        {
            User? returnedUser = new();
            Console.ForegroundColor = ConsoleColor.Blue;
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

            try
            {
                Console.ResetColor();
                string input = InputComponent.CancellableReadLine(string.Format("Enter your first name{0}: ", user != null ? $" ({user.FirstName})" : "")) ?? "";
                returnedUser.FirstName = input.Length > 0 ? input : (user != null ? user.FirstName : "");

                input = InputComponent.CancellableReadLine(string.Format("Enter your last name{0}: ", user != null ? $" ({user.LastName})" : ""));
                returnedUser.LastName = input.Length > 0 ? input : (user != null ? user.LastName : "");

                input = InputComponent.CancellableReadLine(string.Format("Enter your username{0}: ", user != null ? $" ({user.Username})" : ""));
                returnedUser.Username = input.Length > 0 ? input : (user != null ? user.Username : "");

                input = InputComponent.CancellableReadLine(string.Format("Enter your password{0}: ", user != null ? $" ({user.Password})" : ""));
                returnedUser.Password = input.Length > 0 ? input : (user != null ? user.Password : "");

                input = InputComponent.CancellableReadLine(string.Format("Enter your email{0}: ", user != null ? $" ({user.Email})" : ""));
                returnedUser.Email = input.Length > 0 ? input : (user != null ? user.Email : "");

                input = InputComponent.CancellableReadLine(string.Format("Enter your phone number{0}: ", user != null ? $" ({user.PhoneNumber})" : ""));
                returnedUser.PhoneNumber = input.Length > 0 ? input : (user != null ? user.PhoneNumber : "");
            }
            catch
            {
                ShowInfoMessage("\nUser form cancelled\n");
                returnedUser = null;
            }

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

        public static void ShowInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
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
