namespace Hanser.AB.Unity
{
    public class UnityRunner
    {
        public void Initialize()
        {
            Console.WriteLine("# SIMULATING AB-TESTING DATA #");
            
            Console.WriteLine($"{Environment.NewLine}UnityRunner >> Logging in...");
            var user = MockWebClient.Login();

            Console.WriteLine($"{Environment.NewLine}UnityRunner >> Getting monster config...");
            var monster = MockWebClient.GetGoblin();
        }
    }
}