using System.CommandLine;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineTool.Startup
{
    internal static class DependencyInjection
    {
        internal static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddCliCommands();
            return services.BuildServiceProvider();
        }

        private static void AddCliCommands(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(x => typeof(Command).IsAssignableFrom(x))
                .ToList()
                .ForEach(x=>services.AddSingleton(x, x));
        }
    }
}