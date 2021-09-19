using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CommandLineTool.Commands;

namespace CommandLineTool.Startup
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var serviceProvider = DependencyInjection.BuildServiceProvider();
            var parser = BuildParser(serviceProvider);

            return await parser.InvokeAsync(args).ConfigureAwait(false);
        }

        private static Parser BuildParser(IServiceProvider serviceProvider)
        {
            var commandLineBuilder = new CommandLineBuilder();
            
            Assembly.GetExecutingAssembly()
                .GetTypes().ToList()
                .Where(x => x.IsDefined(typeof(TopLevelCommand), false)).ToList()
                .ForEach(x => commandLineBuilder.AddCommand((Command)serviceProvider.GetService(x)));

            return commandLineBuilder.UseDefaults().Build();
        }
    }
}
