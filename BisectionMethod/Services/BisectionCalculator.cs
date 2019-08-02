using System;
using System.Collections.Generic;
using Exceptions;
using Ninject;
using Services.IServices;

namespace Services
{
    public class BisectionCalculator : IBisectionCalculator
    {
        private IKernel _kernel;

        public BisectionCalculator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public string Expression { get; set; }

        public double BeginInterval { get; set; }

        public double EndInterval { get; set; }

        public double ErrorExpression { get; set; }

        public CalculateEventArgs Calculate()
        {
            try
            {
                var answerList = new List<double>();
                var functionList = new List<double>();
                var beginList = new List<double>();
                var endList = new List<double>();
                double x = 0;
                int k;
                
                var parser = new MathParser();

                var funcA = EditExpression(Expression, BeginInterval.ToString());
                var funcB = EditExpression(Expression, EndInterval.ToString());

                if (parser.Parse(funcA) * parser.Parse(funcB) < 0)
                {
                    k = 0;
                    while (true)
                    {
                        x = (BeginInterval + EndInterval) / 2;
                        k++;
                        var funcX = EditExpression(Expression, x.ToString());

                        answerList.Add(x);
                        beginList.Add(BeginInterval);
                        endList.Add(EndInterval);
                        functionList.Add(Math.Abs(parser.Parse(funcX)));

                        if (Math.Abs(parser.Parse(funcX)) < ErrorExpression)
                        {
                            break;
                        }

                        if (parser.Parse(funcA) * parser.Parse(funcX) < 0)
                        {
                            EndInterval = x;
                        }
                        else
                        {
                            BeginInterval = x;
                        }

                    }

                    return new CalculateEventArgs(x, "Условие сходимости выполнено", true,k, answerList, beginList, endList, functionList);
                }
                else
                {
                    return new CalculateEventArgs("Условие сходимости не выполнено", false);
                }
            }
            catch (DivideByZeroException)
            {
                throw new WrongExpressionException("Деление на ноль!");
            }
            catch 
            {
                throw new WrongExpressionException("Неверно введено выражение!");
            }
        }

        private string EditExpression(string exp, string x)
        {
            return exp.Replace("x", x);
        }
    }
}