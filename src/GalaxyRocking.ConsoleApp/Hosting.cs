using GalaxyRocking.NatureLanguage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace GalaxyRocking.ConsoleApp
{
    public class Hosting
    {
        private readonly IServiceProvider _serviceProvider;

        public Hosting(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));           
        }

        public void Run(string[] args)
        {
            if(args.Length == 0)
            {
                WaitingForInput();
            }

            if (args.Contains("-v")) ConsolePrinter.Verbose = true;
            if(args.Any(x=> x != "-v"))
            {
                var filename = args.First(x => x != "-v");
                InputFromFile(filename);
            }
            
        }

        public void WaitingForInput()
        {
            Console.WriteLine("Waiting for input:");
            Console.WriteLine();
            var inputStr = Console.ReadLine();
            if (string.IsNullOrEmpty(inputStr)) WaitingForInput();
            HandleInput(inputStr);
            WaitingForInput();
        }

        public void InputFromFile(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using(var reader = new StreamReader(stream))
                {
                    var line = reader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine($"{line}");
                        HandleInput(line);
                        line = reader.ReadLine();
                    }
                }
            }
            WaitingForInput();

        }

        public void HandleInput(string input)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var natureLanguageAnalyzer = scope.ServiceProvider.GetRequiredService<INatureLanguageAnalyzer>();
                var thinkers = scope.ServiceProvider.GetServices<IThinker>();

                var sentence = natureLanguageAnalyzer.Analyze(input);
                var thinker = thinkers.FirstOrDefault(x => x.CanThink(sentence));
                if (thinker == null)
                {
                    Console.WriteLine("I have no idea what you are talking about");
                    return;
                }

                thinker.Think(sentence).DynamicInvoke(_serviceProvider);
            }
            
        }
    }
}
