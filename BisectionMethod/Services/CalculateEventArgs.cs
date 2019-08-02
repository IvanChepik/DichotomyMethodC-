using System;
using System.Collections.Generic;

namespace Services
{
    public class CalculateEventArgs : EventArgs
    {
        public double Answer { get; }

        public string Message { get; }

        public bool IsCalculated { get; }

        public List<double> AnswersList { get; set; }

        public List<double> BeginIntervalList { get; set; }

        public List<double> EndIntervalList { get; set; }
        
        public List<double> FunctionList { get; set; }

        public int CountIterations { get; set; }

        public CalculateEventArgs(double answer, string message, bool isCalculated, int count, params List<double>[] lists)
        {
            Answer = answer;
            Message = message;
            IsCalculated = isCalculated;
            CountIterations = count;
            AnswersList = lists[0];
            BeginIntervalList = lists[1];
            EndIntervalList = lists[2];
            FunctionList = lists[3];
        }

        public CalculateEventArgs(string message, bool isCalculated)
        {
            IsCalculated = isCalculated;
            Message = message;
        }
    }
}