using System.Collections.Generic;

namespace NCommands
{
    public interface ICommand
    {
        string Name { get; }

        bool CanExecute();

        IDictionary<string, dynamic> Parameters { get; set; }
    }
}