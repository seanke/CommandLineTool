using System.CommandLine;
using CommandLineTool.Commands.Echo.Children;

namespace CommandLineTool.Commands.Echo
{
    [TopLevelCommand]
    public class EchoCommand : Command
    {
        public EchoCommand(EchoOnceCommand once, EchoTwiceCommand twice)
            : base("echo", "Echo the message.")
        {
            Add(once);
            Add(twice);
        }
    }
}