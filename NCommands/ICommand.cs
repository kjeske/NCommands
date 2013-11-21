using System.Collections.Generic;

namespace NCommands
{
    public interface ICommand
    {
        IDictionary<string, dynamic> Parameters { get; set; }

        dynamic Result { get; }

        bool CanExecute();

        void Execute();
    }
}