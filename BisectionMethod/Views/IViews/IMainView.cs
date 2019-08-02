using System;
using System.Collections.Generic;

namespace Views.IViews
{
    public interface IMainView : IView
    {
        event Action Calculated;

        string Expression { get; }

        string BeginInterval { get;  }

        string EndInterval { get; }

        string ErrorExpression { get; }

        void ShowAnswer(string message, List<double> answerList, List<double> beginList, List<double> endList, List<double> functionList, int count);

        void ShowError(string message);
    }
}