namespace Hanser.AB.Util
{
    public static class Logger
    {
        public static string Runner { get; set; }
        
        private const string UnityRunner = "UnityRunner";
    
        public static void Log(string suffix, object message, bool startWithNewLine = true, ConsoleColor suffixColor = ConsoleColor.White, ConsoleColor messageColor = ConsoleColor.White)
        {
            WritePrefix(suffix, startWithNewLine, suffixColor);
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
        }

        private static void WritePrefix(string suffix, bool startWithNewLine, ConsoleColor suffixColor)
        {
            Console.ForegroundColor = Runner == UnityRunner ? ConsoleColor.Green : ConsoleColor.DarkBlue;
            var message = $"{(startWithNewLine ? Environment.NewLine : string.Empty)}[{Runner}]";
            Console.Write(message);
            Console.ForegroundColor = suffixColor;
            message = suffix != string.Empty ? $"[{suffix}]" : string.Empty;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" : ");
        }
    }
}