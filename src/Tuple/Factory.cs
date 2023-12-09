using System.Text;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Tuple
{
    public class QuadraticEquation
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public string Variable { get; set; }

        public QuadraticEquation()
        {}

        public string GetText()
        {
            StringBuilder sb = new(String.Empty);

            if (A != 0)
            {
                sb.Append($"{A.ToString()}{Variable}^2");
            }

            sb.Append(' ');

            if (B > 0)
            {
                sb.Append($"+ {B.ToString()}{Variable}");
            }
            else if (B < 0)
            {
                sb.Append($"{B.ToString()}{Variable}");
                sb.Replace("-", "- ");
            }

            sb.Append(' ');

            if (C > 0)
            {
                sb.Append($"+ {C.ToString()}");
            }
            else if (C < 0)
            {
                sb.Append($"{C.ToString()}");
                sb.Replace("-", "- ");
            }

            return sb.ToString();
        }
    }

    public class QuadraticEquationFactory<T1>
        where T1 : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public static QuadraticEquation CreateWith4Args(T1 dataTuple)
        {
            return new QuadraticEquation
            {
                A = (int)dataTuple[0],
                B = (int)dataTuple[1],
                C = (int)dataTuple[2],
                Variable = (string)dataTuple[3]
            };
        }

        public static QuadraticEquation CreateWith3Args(T1 dataTuple)
        {
            return new QuadraticEquation
            {
                A = (int)dataTuple[0],
                B = (int)dataTuple[1],
                C = (int)dataTuple[2],
                Variable = "x"
            };
        }

        public static QuadraticEquation CreateWith2Args(T1 dataTuple)
        {
            return new QuadraticEquation
            {
                A = (int)dataTuple[0],
                B = (int)dataTuple[1],
                C = 0,
                Variable = "x"
            };
        }

        public static QuadraticEquation CreateWith1Args(T1 dataTuple)
        {
            return new QuadraticEquation
            {
                A = (int)dataTuple[0],
                B = 0,
                C = 0,
                Variable = "x"
            };
        }

        public static QuadraticEquation CreateWithNoArgs(T1 dataTuple)
        {
            return new QuadraticEquation
            {
                A = 0,
                B = 0,
                C = 0,
                Variable = "x"
            };
        }
    }
}