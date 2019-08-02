namespace Commands.Commands
{
    public class CalculateCommand : Command
    {
        private readonly string _expression;

        private readonly double _beginInterval;

        private readonly double _endInterval;

        private readonly double _error;

        public CalculateCommand(ExecutorCommands executorCommands, string expression, double beginInterval, double endInterval, double error) : base(executorCommands)
        {
            _expression = expression;
            _beginInterval = beginInterval;
            _endInterval = endInterval;
            _error = error;
        }

        public override void Execute()
        {
            Executor.Calculate(_expression, _beginInterval, _endInterval, _error);
        }
    }
}