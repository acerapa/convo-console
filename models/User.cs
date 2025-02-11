namespace ConvoConsole.Models
{
    public class User(
        string username = "",
        string password = "",
        string email = "",
        string firstName = "",
        string lastName = "",
        string phoneNumber = "",
        string id = ""
    )
    {
        public string Id { get; set; } = id;
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
        public string Email { get; set; } = email;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string PhoneNumber { get; set; } = phoneNumber;

        // List of contacts
        private List<User> contacts = new List<User>();
    }
}
