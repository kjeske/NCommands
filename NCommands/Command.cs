using System.Collections.Generic;

namespace NCommands
{
    public abstract class Command : ICommand
    {
        public IDictionary<string, dynamic> Parameters { get; set; }

        public dynamic Result { get; protected set; }

        public abstract void Execute();

        public virtual bool CanExecute()
        {
            return true;
        }
    }
}