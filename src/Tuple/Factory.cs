using System.Text;

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

    public class EquationFactory<T1, T2>
        where T1 : System.ValueTuple<int, int, int, string>
        where T2 : QuadraticEquation
    {
        public static T2 CreateWith4Args(T1 dataTuple)
        {
            return new T2{
                A = dataTuple.Item1,
                B = dataTuple.Item2,
                C = dataTuple.Item3,
                Variable = dataTuple.Item4
            };
        }

        public static T2 CreateWith3Args(T1 dataTuple)
        {
            return new T2{
                A = dataTuple.Item1,
                B = dataTuple.Item2,
                C = dataTuple.Item3,
                Variable = "x"
            };
        }

        public static T2 CreateWith2Args(T1 dataTuple)
        {
            return new T2{
                A = dataTuple.Item1,
                B = dataTuple.Item2,
                C = 0,
                Variable = "x"
            };
        }

        public static T2 CreateWith1Args(T1 dataTuple)
        {
            return new T2(
                A = dataTuple.Item1,
                B = 0,
                C = 0,
                Variable = "x"
            );
        }

        public static T2 CreateWithNoArgs(T1 dataTuple)
        {
            return new T2(
                A = 0,
                B = 0,
                C = 0,
                Variable = "x"
            );
        }
    }
}