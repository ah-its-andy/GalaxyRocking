using GalaxyRocking.Expressions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GalaxyRocking.ConsoleApp
{
    public class Hosting
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IExpressionCompiler _expressionCompiler;

        public Hosting(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _expressionCompiler = _serviceProvider.GetRequiredService<IExpressionCompiler>();
        }

        public void Run(string[] args)
        {
            WaitingForInput();
        }

        public void WaitingForInput()
        {
            Console.WriteLine("Waiting for input:");
            Console.WriteLine();
            var inputStr = Console.ReadLine();
            if (string.IsNullOrEmpty(inputStr)) WaitingForInput();

            var expr = _expressionCompiler.Compile(inputStr.ToUpper());
            var compiledDelegate = expr.Compile();
            Console.WriteLine($"{inputStr}的编译结果：");
            Console.WriteLine($"   - 罗马字母表达式： {expr.ToString("S")}");
            Console.WriteLine($"   - 十进制数学表达式： {expr.ToString("N")}");
            Console.WriteLine($"   - 最终计算结果： {compiledDelegate.DynamicInvoke()}");
            WaitingForInput();
        }
    }
}
