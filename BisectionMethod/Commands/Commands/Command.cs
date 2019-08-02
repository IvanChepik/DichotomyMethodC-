namespace Commands.Commands
{
    public abstract class Command
    {
        protected ExecutorCommands Executor;

        protected Command(ExecutorCommands executorCommands)
        {
            Executor = executorCommands;
        }

        public abstract void Execute();
    }
}