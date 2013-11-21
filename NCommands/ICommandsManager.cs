namespace NCommands
{
    public interface ICommandsManager
    {
        ICommand GetCommand(string name);
    }
}