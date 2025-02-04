namespace ConvoConsole.auth
{
    internal class Credentials(string username, string password)
    {
        public string Username { get; } = username;
        public string Password { get; } = password;
    }
}