using System.Collections.Generic;

namespace NCommands
{
    public abstract class Command : ICommand
    {
        public abstract string Name { get; }

        public abstract bool CanExecute();

        public IDictionary<string, dynamic> Parameters { get; set; }
    }
}