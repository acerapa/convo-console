using ConvoConsole;

Display.Greetings();

// When there is no user logged in, display the menu
string choice = Display.UnauthenticatedMenu();

while (!choice.Equals("3"))
{
    switch (choice)
    {
        case "1":
            // Login
            Auth.Login(Display.LoginForm());
            break;
        case "2":
            Console.WriteLine("Register");
            break;
        case "3":
            Console.WriteLine("Exit");
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    choice = Display.UnauthenticatedMenu();
}

Display.GoodBye();
