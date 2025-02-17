namespace ConvoConsole.Components {
    internal class InputComponent {
        public static string CancellableReadLine(string prompt) {
            Console.Write(prompt);
            string input = string.Empty;
            
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) {
                    break;
                } else if (key.Key == ConsoleKey.Escape) {
                    throw new Exception("Input cancelled.");
                } else {
                    input += key.KeyChar;
                    Console.WriteLine(key.KeyChar);
                }
            }

            return input;
        }
    }
}