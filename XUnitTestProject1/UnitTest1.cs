using GalaxyRocking.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        public static List<object[]> lines
            = new List<object[]>
            {
                new object[]
                {
                    new List<string>
                    {
                        "glob is I",
                        "prok is V",
                        "pish is X",
                        "tegj is L",
                        "glob glob Silver is 34 Credits",
                        "glob prok Gold is 57800 Credits",
                        "pish pish Iron is 3910 Credits",
                        "how much is pish tegj glob glob ?",
                        "how many Credits is glob prok Silver ?",
                        "how many Credits is glob prok Gold ?",
                        "how many Credits is glob prok Iron ?",
                        "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"
                    }
                }
            };

        [Theory()]
        [MemberData(nameof(lines))]
        public void Test1(List<string> data)
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServies(services);
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var hosting = new Hosting(scope.ServiceProvider);
                
                foreach(var cmd in data)
                {
                    hosting.HandleInput(cmd);
                }
            }
        }
    }
}
