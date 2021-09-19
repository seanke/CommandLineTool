using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CommandLineTool.Commands.Echo.Children
{
    public class EchoTwiceCommand : Command
    {
        public EchoTwiceCommand()
            : base("twice", "Echo the message.")
        {
            AddOption(new Option<string>("--message")
            {
                Name = "message",
                Description = "The message to echo.",
                IsRequired = true
            });

            Handler = CommandHandler.Create<string>(HandleCommand);
        }

        public static int HandleCommand(string message)
        {
            try
            {
                Console.WriteLine(message);
                Console.WriteLine(message);
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