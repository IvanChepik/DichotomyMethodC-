using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Services
{
    public class MathParser
    {
        #region Fields

        #region Markers (each marker should have length equals to 1)

        private const string NumberMaker = "#";
        private const string OperatorMarker = "$";
        private const string FunctionMarker = "@";

        #endregion

        #region Internal tokens

        private const string Plus = OperatorMarker + "+";
        private const string UnPlus = OperatorMarker + "un+";
        private const string Minus = OperatorMarker + "-";
        private const string UnMinus = OperatorMarker + "un-";
        private const string Multiply = OperatorMarker + "*";
        private const string Divide = OperatorMarker + "/";
        private const string Degree = OperatorMarker + "^";
        private const string LeftParent = OperatorMarker + "(";
        private const string RightParent = OperatorMarker + ")";
        private const string Sqrt = FunctionMarker + "sqrt";
        private const string Sin = FunctionMarker + "sin";
        private const string Cos = FunctionMarker + "cos";
        private const string Tg = FunctionMarker + "tg";
        private const string Ctg = FunctionMarker + "ctg";
        private const string Sh = FunctionMarker + "sh";
        private const string Ch = FunctionMarker + "ch";
        private const string Th = FunctionMarker + "th";
        private const string Log = FunctionMarker + "log";
        private const string Ln = FunctionMarker + "ln";
        private const string Exp = FunctionMarker + "exp";
        private const string Abs = FunctionMarker + "abs";

        #endregion

        #region Dictionaries (containts supported input tokens, exclude number)

        private readonly Dictionary<string, string> supportedOperators =
            new Dictionary<string, string>
            {
                { "+", Plus },
                { "-", Minus },
                { "*", Multiply },
                { "/", Divide },
                { "^", Degree },
                { "(", LeftParent },
                { ")", RightParent }
            };

        private readonly Dictionary<string, string> supportedFunctions =
            new Dictionary<string, string>
            {
                { "sqrt", Sqrt },
                { "√", Sqrt },
                { "sin", Sin },
                { "cos", Cos },
                { "tg", Tg },
                { "ctg", Ctg },
                { "sh", Sh },
                { "ch", Ch },
                { "th", Th },
                { "ln", Ln },
                { "log", Log },
                { "exp", Exp },
                { "abs", Abs }
            };

        private readonly Dictionary<string, string> supportedConstants =
            new Dictionary<string, string>
            {
                {"pi", NumberMaker +  Math.PI.ToString() },
                {"e", NumberMaker + Math.E.ToString() }
            };

        #endregion

        #endregion

        private readonly char decimalSeparator;
        private bool isRadians;

        #region Constructors

        public MathParser()
        {
            try
            {
                decimalSeparator = Char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Ошибка формата", ex);
            }
        }

        public MathParser(char decimalSeparator)
        {
            this.decimalSeparator = decimalSeparator;
        }

        #endregion

        public double Parse(string expression, bool isRadians = true)
        {
            this.isRadians = isRadians;

            try
            {
                return Calculate(ConvertToRPN(FormatString(expression)));
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private string FormatString(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("Выражение пустое");
            }

            StringBuilder formattedString = new StringBuilder();
            int balanceOfParenth = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(')
                {
                    balanceOfParenth++;
                }
                else if (ch == ')')
                {
                    balanceOfParenth--;
                }

                if (Char.IsWhiteSpace(ch))
                {
                    continue;
                }
                else if (Char.IsUpper(ch))
                {
                    formattedString.Append(Char.ToLower(ch));
                }
                else
                {
                    formattedString.Append(ch);
                }
            }

            if (balanceOfParenth != 0)
            {
                throw new FormatException("Неправильно расставлены скобки");
            }

            return formattedString.ToString();
        }

        #region Convert to Reverse-Polish Notation

        private string ConvertToRPN(string expression)
        {
            int pos = 0;
            StringBuilder outputString = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            while (pos < expression.Length)
            {
                string token = LexicalAnalysisInfixNotation(expression, ref pos);

                outputString = SyntaxAnalysisInfixNotation(token, outputString, stack);
            }

            while (stack.Count > 0)
            {
                if (stack.Peek()[0] == OperatorMarker[0])
                {
                    outputString.Append(stack.Pop());
                }
                else
                {
                    throw new FormatException("Format exception,"
                    + " there is function without parenthesis");
                }
            }

            return outputString.ToString();
        }

        private string LexicalAnalysisInfixNotation(string expression, ref int pos)
        {
            StringBuilder token = new StringBuilder();
            token.Append(expression[pos]);

            if (supportedOperators.ContainsKey(token.ToString()))
            {
                bool isUnary = pos == 0 || expression[pos - 1] == '(';
                pos++;

                switch (token.ToString())
                {
                    case "+":
                        return isUnary ? UnPlus : Plus;
                    case "-":
                        return isUnary ? UnMinus : Minus;
                    default:
                        return supportedOperators[token.ToString()];
                }
            }
            else if (Char.IsLetter(token[0])
                || supportedFunctions.ContainsKey(token.ToString())
                || supportedConstants.ContainsKey(token.ToString()))
            {

                while (++pos < expression.Length
                    && Char.IsLetter(expression[pos]))
                {
                    token.Append(expression[pos]);
                }

                if (supportedFunctions.ContainsKey(token.ToString()))
                {
                    return supportedFunctions[token.ToString()];
                }
                else if (supportedConstants.ContainsKey(token.ToString()))
                {
                    return supportedConstants[token.ToString()];
                }
                else
                {
                    throw new ArgumentException("Неизвестный символ");
                }

            }
            else if (Char.IsDigit(token[0]) || token[0] == decimalSeparator)
            {
                if (Char.IsDigit(token[0]))
                {
                    while (++pos < expression.Length
                    && Char.IsDigit(expression[pos]))
                    {
                        token.Append(expression[pos]);
                    }
                }
                else
                {
                    token.Clear();
                }

                if (pos < expression.Length
                    && expression[pos] == decimalSeparator)
                {

                    token.Append(CultureInfo.CurrentCulture
                        .NumberFormat.NumberDecimalSeparator);

                    while (++pos < expression.Length
                    && Char.IsDigit(expression[pos]))
                    {
                        token.Append(expression[pos]);
                    }
                }

                if (pos + 1 < expression.Length && expression[pos] == 'e'
                    && (Char.IsDigit(expression[pos + 1])
                        || (pos + 2 < expression.Length
                            && (expression[pos + 1] == '+'
                                || expression[pos + 1] == '-')
                            && Char.IsDigit(expression[pos + 2]))))
                {
                    token.Append(expression[pos++]);

                    if (expression[pos] == '+' || expression[pos] == '-')
                        token.Append(expression[pos++]);

                    while (pos < expression.Length
                        && Char.IsDigit(expression[pos]))
                    {
                        token.Append(expression[pos++]);
                    }
                    return NumberMaker + Convert.ToDouble(token.ToString());
                }

                return NumberMaker + token.ToString();
            }
            else
            {
                throw new ArgumentException("Неизвестный символ в выражении");
            }
        }

        private StringBuilder SyntaxAnalysisInfixNotation(string token, StringBuilder outputString, Stack<string> stack)
        {
            if (token[0] == NumberMaker[0])
            {
                outputString.Append(token);
            }
            else if (token[0] == FunctionMarker[0])
            {
                stack.Push(token);
            }
            else if (token == LeftParent)
            {
                stack.Push(token);
            }
            else if (token == RightParent)
            {
                string elem;
                while ((elem = stack.Pop()) != LeftParent)
                {
                    outputString.Append(elem);
                }

                if (stack.Count > 0 &&
                    stack.Peek()[0] == FunctionMarker[0])
                {
                    outputString.Append(stack.Pop());
                }
            }
            else
            {
                while (stack.Count > 0 &&
                    Priority(token, stack.Peek()))
                {
                    outputString.Append(stack.Pop());
                }

                stack.Push(token);
            }

            return outputString;
        }

        private bool Priority(string token, string p)
        {
            return IsRightAssociated(token) ?
                GetPriority(token) < GetPriority(p) :
                GetPriority(token) <= GetPriority(p);
        }

        private bool IsRightAssociated(string token)
        {
            return token == Degree;
        }

        private int GetPriority(string token)
        {
            switch (token)
            {
                case LeftParent:
                    return 0;
                case Plus:
                case Minus:
                    return 2;
                case UnPlus:
                case UnMinus:
                    return 6;
                case Multiply:
                case Divide:
                    return 4;
                case Degree:
                case Sqrt:
                    return 8;
                case Sin:
                case Cos:
                case Tg:
                case Ctg:
                case Sh:
                case Ch:
                case Th:
                case Log:
                case Ln:
                case Exp:
                case Abs:
                    return 10;
                default:
                    throw new ArgumentException("Неизвестный оператор");
            }
        }

        #endregion

        #region Calculate expression in RPN

        private double Calculate(string expression)
        {
            int pos = 0;
            var stack = new Stack<double>();

            while (pos < expression.Length)
            {
                string token = LexicalAnalysisRPN(expression, ref pos);

                stack = SyntaxAnalysisRPN(stack, token);
            }

            if (stack.Count > 1)
            {
                throw new ArgumentException("Excess operand");
            }

            return stack.Pop();
        }

        private string LexicalAnalysisRPN(string expression, ref int pos)
        {
            StringBuilder token = new StringBuilder();

            token.Append(expression[pos++]);

            while (pos < expression.Length && expression[pos] != NumberMaker[0]
                && expression[pos] != OperatorMarker[0]
                && expression[pos] != FunctionMarker[0])
            {
                token.Append(expression[pos++]);
            }

            return token.ToString();
        }

        private Stack<double> SyntaxAnalysisRPN(Stack<double> stack, string token)
        {
            if (token[0] == NumberMaker[0])
            {
                stack.Push(double.Parse(token.Remove(0, 1)));
            }
            else if (NumberOfArguments(token) == 1)
            {
                double arg = stack.Pop();
                double rst;

                switch (token)
                {
                    case UnPlus:
                        rst = arg;
                        break;
                    case UnMinus:
                        rst = -arg;
                        break;
                    case Sqrt:
                        rst = Math.Sqrt(arg);
                        break;
                    case Sin:
                        rst = ApplyTrigFunction(Math.Sin, arg);
                        break;
                    case Cos:
                        rst = ApplyTrigFunction(Math.Cos, arg);
                        break;
                    case Tg:
                        rst = ApplyTrigFunction(Math.Tan, arg);
                        break;
                    case Ctg:
                        rst = 1 / ApplyTrigFunction(Math.Tan, arg);
                        break;
                    case Sh:
                        rst = Math.Sinh(arg);
                        break;
                    case Ch:
                        rst =
                    rst = Math.Cosh(arg);
                        break;
                    case Th:
                        rst = Math.Tanh(arg);
                        break;
                    case Ln:
                        rst = Math.Log(arg);
                        break;
                    case Exp:
                        rst = Math.Exp(arg);
                        break;
                    case Abs:
                        rst = Math.Abs(arg);
                        break;
                    default:
                        throw new ArgumentException("Неизвестный оператор");
                }

                stack.Push(rst);
            }
            else
            {
                double arg2 = stack.Pop();
                double arg1 = stack.Pop();

                double rst;

                switch (token)
                {
                    case Plus:
                        rst = arg1 + arg2;
                        break;
                    case Minus:
                        rst = arg1 - arg2;
                        break;
                    case Multiply:
                        rst = arg1 * arg2;
                        break;
                    case Divide:
                        if (arg2 == 0)
                        {
                            throw new DivideByZeroException("Second argument is zero");
                        }
                        rst = arg1 / arg2;
                        break;
                    case Degree:
                        rst = Math.Pow(arg1, arg2);
                        break;
                    case Log:
                        rst = Math.Log(arg2, arg1);
                        break;
                    default:
                        throw new ArgumentException("Неизвестный оператор");
                }

                stack.Push(rst);
            }

            return stack;
        }

        private double ApplyTrigFunction(Func<double, double> func, double arg)
        {
            if (!isRadians)
            {
                arg = arg * Math.PI / 180;
            }

            return func(arg);
        }

        private int NumberOfArguments(string token)
        {
            switch (token)
            {
                case UnPlus:
                case UnMinus:
                case Sqrt:
                case Tg:
                case Sh:
                case Ch:
                case Th:
                case Ln:
                case Ctg:
                case Sin:
                case Cos:
                case Exp:
                case Abs:
                    return 1;
                case Plus:
                case Minus:
                case Multiply:
                case Divide:
                case Degree:
                case Log:
                    return 2;
                default:
                    throw new ArgumentException("Неизвестный оператор");
            }
        }

        #endregion
    }
}