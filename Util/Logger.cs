namespace Hanser.AB.Util
{
    public static class Logger
    {
        private const string UnityRunner = "UnityRunner";
    
        public static void Log(string runner, string suffix, object message, bool startWithNewLine = true, ConsoleColor suffixColor = ConsoleColor.White, ConsoleColor messageColor = ConsoleColor.White)
        {
            WritePrefix(runner, suffix, startWithNewLine, suffixColor);
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
        }

        private static void WritePrefix(string runner, string suffix, bool startWithNewLine, ConsoleColor suffixColor)
        {
            Console.ForegroundColor = runner == UnityRunner ? ConsoleColor.Green : ConsoleColor.DarkBlue;
            var message = $"{(startWithNewLine ? Environment.NewLine : string.Empty)}[{runner}]";
            Console.Write(message);
            Console.ForegroundColor = suffixColor;
            message = suffix != string.Empty ? $"[{suffix}]" : string.Empty;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" : ");
        }
    }
}