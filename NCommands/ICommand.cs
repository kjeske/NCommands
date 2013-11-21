using System.Collections.Generic;

namespace NCommands
{
    public interface ICommand
    {
        IDictionary<string, dynamic> Parameters { get; set; }

        bool CanExecute();

        void Execute();
    }
}