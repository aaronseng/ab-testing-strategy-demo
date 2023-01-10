using Hanser.AB.Unity;

namespace Hanser.AB
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var unityRunner = new UnityRunner();

            unityRunner.Initialize();
        }
    }
}