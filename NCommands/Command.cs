using System.Collections.Generic;

namespace NCommands
{
    public abstract class Command : ICommand
    {
        public IDictionary<string, dynamic> Parameters { get; set; }

        public virtual bool CanExecute()
        {
            return true;
        }

        public abstract void Execute();
    }
}