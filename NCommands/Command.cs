using System.Collections.Generic;

namespace NCommands
{
    public abstract class Command : ICommand
    {
        public virtual bool CanExecute()
        {
            return true;
        }

        public abstract void Execute();

        public IDictionary<string, dynamic> Parameters { get; set; }
    }
}