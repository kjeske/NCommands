using System;
using System.Collections.Generic;

namespace NCommands
{
    public class CommandsManager : ICommandsManager
    {
        private readonly IDictionary<string, Type> _commands;

        private static CommandsManager defaultInstance;

        private Func<Type, object> _resolver;

        public static CommandsManager Default
        {
            get { return defaultInstance ?? (defaultInstance = new CommandsManager()); }
        }

        public CommandsManager()
        {
            _commands = new Dictionary<string, Type>();
        }

        public void Register(Type commandType)
        {
            _commands.Add(commandType.Name, commandType);
        }

        public void Register(IEnumerable<Type> commandTypes)
        {
            foreach (var commandType in commandTypes)
            {
                Register(commandType);
            }
        }

        public void SetDependencyResolver(Func<Type, object> resolver)
        {            
            _resolver = resolver;
        }

        public ICommand GetCommand(string name)
        {
            if (!_commands.ContainsKey(name))
            {
                throw new InvalidOperationException("No command with given name");
            }

            var type = _commands[name];

            if (_resolver != null)
            {
                return _resolver(type) as ICommand;
            }

            return Activator.CreateInstance(type) as ICommand;
        }
    }
}