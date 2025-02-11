namespace ConvoConsole.Models
{
    internal class Message(string content, User sender, string recipient, DateTime timestamp)
    {
        public string Content { get; set; } = content;
        public User Sender { get; set; } = sender;
        public string Recipient { get; set; } = recipient;
        public DateTime Timestamp { get; set; } = timestamp;
    }
}