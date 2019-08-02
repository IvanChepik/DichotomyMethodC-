using System;
using Ninject;
using Services;
using Services.IServices;

namespace Commands
{
    public class ExecutorCommands
    {
        public EventHandler<CalculateEventArgs> ExpressionCalculated;

        private IKernel _kernel;

        public ExecutorCommands()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
        }

        public void Calculate(string expression, double beginInterval, double endInterval, double error)
        {
            var service = _kernel.Get<IBisectionCalculator>();
            service.Expression = expression;
            service.BeginInterval = beginInterval;
            service.EndInterval = endInterval;
            service.ErrorExpression = error;
            OnCalculated(service.Calculate());
        }

        private void OnCalculated(CalculateEventArgs eventArgs)
        {
            ExpressionCalculated?.Invoke(this, eventArgs);
        }
    }
}