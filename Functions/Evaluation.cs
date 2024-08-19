using scientificCalculatorBackEnd.Models;

namespace scientificCalculatorBackEnd.Functions
{
    public class Evaluation
    {
        public static List<string> GetConvertion(Calculator calculator)
        {
            List<string> result = new();

            char[] expression = calculator.Expression.ToCharArray();

            int prev = -1;
            int count = 0;
            for (int index = 0; index <= expression.Length; index++)
            {
                /* when charactor is number */
                if (index < expression.Length && ((expression[index] - '0' >= 0 && expression[index] - '0' <= 9) || expression[index] == '.'))
                {
                    count++;
                }
                /* when charactor's not string and non-trignometric, ........ */
                else
                {
                    if (count != 0)
                    {
                        result.Add(calculator.Expression.Substring(prev + 1 , count));
                        if (index < expression.Length)
                            result.Add(calculator.Expression.Substring(index, 1));
                    }
                    else
                    {
                        result.Add("error");
                        return result;
                    }
                    prev = index;
                    count = 0;
                }
            }
            return result;
        }

        public static double evaluation(List<string> expression)
        {
            Stack<String> stack = new Stack<String>();

            double result = 0;

            for (var index = 0; index < expression.Count; index++)
            {
                if (expression[index] == "+" || expression[index] == "-" || expression[index] == "*" || expression[index] == "/")
                {
                    double number2 = double.Parse(expression[index + 1]);

                    double number1 = double.Parse(stack.Peek());

                    stack.Pop();

                    if (((index + 1) < expression.Count) && number2 >= 0)
                    {
                        if (expression[index] == "+")
                        {
                            result = number1 + number2;
                        }
                        else if (expression[index] == "-")
                        {
                            result = number1 - number2;
                        }
                        else if (expression[index] == "*")
                        {
                            result = number1 * number2;
                        }
                        else
                        {
                            result = number1 / number2;
                        }
                        stack.Push(result+"");
                    }
                }
                else
                {
                    stack.Push(expression[index]);
                }
            }

            return result;
        }

        public static double EvaluateExpression(List<string> tokens)
        {
            // Stack for numbers
            Stack<double> numbers = new Stack<double>();

            // Stack for operators
            Stack<string> operators = new Stack<string>();

            // Operator precedence mapping
            Dictionary<string, int> precedence = new Dictionary<string, int>
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 }
        };

            // Function to apply an operator to the top two elements of the stack
            Func<double, double, string, double> applyOperator = (double a, double b, string op) =>
            {
                switch (op)
                {
                    case "+": return a + b;
                    case "-": return a - b;
                    case "*": return a * b;
                    case "/": return a / b;
                    case "^": return Math.Pow(a, b);
                    default: throw new ArgumentException("Unknown operator: " + op);
                }
            };

            for (int i = 0; i < tokens.Count; i++)
            {
                string token = tokens[i];

                // If the token is a number, push it onto the numbers stack
                if (double.TryParse(token, out double number))
                {
                    numbers.Push(number);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    // Solve entire bracketed expression
                    while (operators.Peek() != "(")
                    {
                        string op = operators.Pop();
                        double b = numbers.Pop();
                        double a = numbers.Pop();
                        numbers.Push(applyOperator(a, b, op));
                    }
                    operators.Pop(); // Remove the "(" from the stack
                }
                else
                {
                    // Operator handling
                    while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                           precedence[operators.Peek()] >= precedence[token])
                    {
                        string op = operators.Pop();
                        double b = numbers.Pop();
                        double a = numbers.Pop();
                        numbers.Push(applyOperator(a, b, op));
                    }
                    operators.Push(token);
                }
            }

            // Apply remaining operators
            while (operators.Count > 0)
            {
                string op = operators.Pop();
                double b = numbers.Pop();
                double a = numbers.Pop();
                numbers.Push(applyOperator(a, b, op));
            }

            // Result is the last number in the stack
            return numbers.Pop();
        }
    }
}
