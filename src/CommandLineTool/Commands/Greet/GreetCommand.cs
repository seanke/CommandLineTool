using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace CommandLineTool.Commands.Greet
{
    [TopLevelCommand]
    public class GreetCommand : Command
    {
        public GreetCommand()
            : base("greet", "Says a greeting to the specified person.")
        {
            AddOption(new Option<string>("--name")
            {
                Name = "name",
                Description = "The name of the person to greet.",
                IsRequired = true
            });
            
            AddOption(new Option<string>("--greeting")
            {
                Name = "greeting",
                Description = "The word to greet the person.",
                IsRequired = true
            });
            
            Handler = CommandHandler.Create<string, string>(HandleCommand);
        }

        public static async Task<int> HandleCommand(string greeting, string name)
        {
            try
            {
                Console.WriteLine($"{greeting} {name}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }

            return 0;
        }
    }
}