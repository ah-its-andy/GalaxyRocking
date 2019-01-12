using GalaxyRocking.Expressions;
using GalaxyRocking.Language.Dialect;
using GalaxyRocking.NatureLanguage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
            if(args.Length > 0)
            {
                InputFromFile(args[0]);
            }

            WaitingForInput();
        }

        public void WaitingForInput()
        {
            Console.WriteLine("Waiting for input:");
            Console.WriteLine();
            var inputStr = Console.ReadLine();
            if (string.IsNullOrEmpty(inputStr)) WaitingForInput();
            HandleInput(inputStr);
            //var compiledDelegate = _dialectCompiler.Compile(inputStr);
            //if(compiledDelegate == null)
            //{
            //    Console.WriteLine("I have no idea what you are talking about");
            //}
            //else
            //{
            //    compiledDelegate.DynamicInvoke(_serviceProvider);
            //}
            //var expr = _expressionCompiler.Interpret(inputStr.ToUpper());
            //var compiledDelegate = expr.Compile();
            //Console.WriteLine($"{inputStr}的编译结果：");
            //Console.WriteLine($"   - 罗马字母表达式： {expr.ToString("S")}");
            //Console.WriteLine($"   - 十进制数学表达式： {expr.ToString("N")}");
            //Console.WriteLine($"   - 最终计算结果： {compiledDelegate.DynamicInvoke()}");
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
                        Console.WriteLine($"Input: {line}");
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
