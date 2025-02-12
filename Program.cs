using ConvoConsole;
using ConvoConsole.Models;
using ConvoConsole.Service;

DatabaseService dbService = new();
UserServices userServices = new(dbService);

Display.Greetings();

List<User> users = new();

// When there is no user logged in, display the menu
string choice = Display.UnauthenticatedMenu();

while (!choice.Equals("3"))
{
    switch (choice)
    {
        case "1":
            // Login
            Authtentication.Login(Display.LoginForm());
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
            if (userId != null) {
                User? user = users.Find(user => user.Id == userId);
                if (user != null) {
                    userServices.UpdateUser(Display.UserForm(user));
                } else {
                    Display.ShowErrorMessage("User not found!");
                }
            }
            break;
        case "7":
            Console.Write("Enter user id: ");
            string userIdToDelete = Console.ReadLine() ?? "";
            Console.WriteLine(userIdToDelete.Length);
            Console.WriteLine(userIdToDelete ?? "Value is null");
            Console.WriteLine(userIdToDelete == "Value is null");

            break;
        default:
            Display.InvalidChoice();
            break;
    }

    choice = Display.UnauthenticatedMenu();
}

Display.GoodBye();
