using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();

            string commandInput = input[0];
            string[] value = input.Skip(1).ToArray();

            ICommand command = default;

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandInput + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            Type commandInterface = type.GetInterface("ICommand");

            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            command = Activator.CreateInstance(type) as ICommand;
         

            string result = command.Execute(value);

            return result;
        }
    }
}
