using System;

namespace GalaxyRocking
{
    public static class ConsolePrinter
    {
        public static bool Verbose { get; set; } = false;

        public static void PrintResult(string text) =>
            Console.WriteLine($"{text}");

        public static void PrintVerbose(string text)
        {
            if(Verbose) Console.WriteLine($"Verbose: {text}");
        }
    }
}
