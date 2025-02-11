using ConvoConsole;
using ConvoConsole.Models;
using ConvoConsole.Service;

DatabaseService dbService = new();
UserServices userServices = new(dbService);

userServices.CreateUser(new User());

Display.Greetings();

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
            Display.RegisterForm();
            break;
        case "3":
            Console.WriteLine("Exit");
            break;
        default:
            Display.InvalidChoice();
            break;
    }

    choice = Display.UnauthenticatedMenu();
}

Display.GoodBye();
