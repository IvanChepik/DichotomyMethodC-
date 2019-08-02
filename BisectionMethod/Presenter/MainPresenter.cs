using System;
using Commands;
using Commands.Commands;
using Exceptions;
using Ninject;
using Services;
using Views.IViews;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IKernel _kernel;
        private readonly IMainView _view;
        private readonly ExecutorCommands _executorCommand;

        public MainPresenter(IKernel kernel, IMainView view, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _view = view;
            _executorCommand = executorCommands;

            _view.Calculated += () => Calculate(_view.Expression, _view.BeginInterval, _view.EndInterval, _view.ErrorExpression);
        }

        private void Calculate(string expression, string beginInterval, string endInterval, string error)
        {
            try
            {
                _executorCommand.ExpressionCalculated = CalculateEventHandler;
                var command = new CalculateCommand(_executorCommand, expression, double.Parse(beginInterval),
                    double.Parse(endInterval), double.Parse(error));
                command.Execute();
            }
            catch (WrongExpressionException exception)
            {
                _view.ShowError(exception.Message);
            }
            catch (FormatException)
            {
                _view.ShowError("Неверно введены параметры");
            }
        }

        private void CalculateEventHandler(object sender, CalculateEventArgs eventArgs)
        {          
             if (eventArgs.IsCalculated)
             {
                _view.ShowAnswer(eventArgs.Answer.ToString(), eventArgs.AnswersList, eventArgs.BeginIntervalList, eventArgs.EndIntervalList, eventArgs.FunctionList, eventArgs.CountIterations);
             }
             else
             {
                 _view.ShowError(eventArgs.Message);
             }
        }

        public void Run()
        {
            _view.Show();
        }
    }
}