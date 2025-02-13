using ConvoConsole;
using ConvoConsole.Models;
using ConvoConsole.Service;

DatabaseService dbService = new();
UserServices userServices = new(dbService);
AuthenticationService authenticationService = new(dbService);

Display.Greetings();

List<User> users = new();

User? authenticatedUser = null;

// When there is no user logged in, display the menu
string choice = Display.UnauthenticatedMenu();

while (!choice.Equals("3"))
{
    switch (choice)
    {
        case "1":
            // Login
            authenticatedUser = authenticationService.Login(Display.LoginForm());
            break;
        case "2":
            userServices.CreateUser(Display.UserForm());
            break;
        case "3":
            Console.WriteLine("Exit");
            break;
        case "4":
            // Get all users
            users = userServices.GetUsers();
            break;
        case "5":
            Console.Write("Enter user id: ");
            string id = Console.ReadLine() ?? "";
            userServices.DeleteUser(id);
            break;
        case "6":
            Console.Write("Enter user id: ");
            string userId = Console.ReadLine() ?? "";
            if (userId != null)
            {
                User? user = users.Find(user => user.Id == userId);
                if (user != null)
                {
                    userServices.UpdateUser(Display.UserForm(user));
                }
                else
                {
                    Display.ShowErrorMessage("User not found!");
                }
            }
            break;
        case "7":
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";
            User? u = userServices.GetUserByUsername(username);
            if (u != null)
            {
                Display.ShowUserDetails(u);
            }
            else
            {
                Display.ShowErrorMessage("User not found!");
            }

            break;
        case "8":
            if (authenticatedUser != null) { Display.ShowSuccessMessage("You are currently login!"); Display.ShowUserDetails(authenticatedUser); }
            else Display.ShowErrorMessage("You are not logged in!");
            break;
        default:
            Display.InvalidChoice();
            break;
    }

    choice = Display.UnauthenticatedMenu();
}

Display.GoodBye();
