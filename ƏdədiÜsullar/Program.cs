using System;
using System.Collections.Generic;
using System.Data;

namespace ƏdədiÜsullar
{
    public class Program
    {
        static double Function(double x)
        {
            double func = (5 * Math.Pow(x, 2) + 3 * x - 2);
            //double func = (3 * Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + 2 * x - 5);
            return func;
        }
        static double IterationFunc(double x)
        {
            return (2 - Math.Pow(x, 2)) / (3);
        }
        static double IntegralFunction(double x)
        {
            double func = (Math.Pow(x, 4) + 2 * Math.Pow(x, 2) - 5);
            return func;
        }
        static double Diferation(double x,double h)
        {
            return (IterationFunc(x + h) - IterationFunc(x)) / h;
        }
        static double TwiceDiferation(double x, double h)
        {
            double func = (Function(x + h) - 2 * Function(x) + Function(x - h)) / (Math.Pow(h, 2));
            return func;
        }
        static List<String> Iteration(double eps)
        {
            List<string> points = new List<string>();
            double x = 0;
            double xn = 0;
            double leftPoint = 0;
            double rightPoint = 0;
            int start = 0;
            if (Function(start) > 0)
            {
                while (Function(start) > 0)
                {
                    start--;
                }
                leftPoint = start;
                rightPoint = leftPoint + 1;
            }
            else
            {
                if (Function(start) == 0)
                {
                    points.Add($"The Route : {0}");
                    return points;
                }
                else
                {
                    while (Function(start) < 0)
                    {
                        start++;
                    }
                    rightPoint = start;
                    leftPoint = rightPoint - 1;
                }
            }

            if (Math.Abs(IterationFunc(leftPoint)) < 1 && Math.Abs(IterationFunc(rightPoint)) < 1)
            {
                x = leftPoint;
                do
                {
                    xn = IterationFunc(x);
                    x= xn;

                    points.Add($"X=> {x}");

                } while (Math.Abs(Function(x) - Function(xn)) > eps);
            }
            else
            {
                points.Add($"Sade Iterasiya yararli deyil !");
            }

            return points;
        }
        static List<string> SplitHalf(double eps)
        {
            List<string> points = new List<string>();
            double leftPoint = 0;
            double rightPoint = 0;
            int start = 0;
            if (Function(start) > 0)
            {
                while (Function(start) > 0)
                {
                    start--;
                }
                leftPoint = start;
                rightPoint = leftPoint + 1;
            }
            else
            {
                if (Function(start) == 0)
                {
                    points.Add($"The Route : {0}");
                    return points;
                }
                else
                {
                    while (Function(start) < 0)
                    {
                        start++;
                    }
                    rightPoint = start;
                    leftPoint = rightPoint - 1;
                }
            }
            points.Add($"Koklerden Biri [{leftPoint}:{rightPoint}] arasinda Yerlesir ");

            while (Math.Abs(leftPoint - rightPoint) > eps)
            {
                if ((Function(leftPoint) + Function(rightPoint)) / 2 > 0)
                {
                    rightPoint = (rightPoint + leftPoint) / 2;
                }
                else if ((Function(leftPoint) + Function(rightPoint)) / 2 == 0)
                {
                    points.Add($"Funksiyanin Koku : {(Function(leftPoint) + Function(rightPoint)) / 2 }");
                    return points;
                }
                else
                {
                    leftPoint = (rightPoint + leftPoint) / 2;
                }
                points.Add($"Koklerden Biri [{leftPoint}:{rightPoint}] arasinda Yerlesir ");
            }
            return points;
        }

        static List<string> Nyuton(double eps)
        {
            List<string> points = new List<string>();
            double leftPoint = 0;
            double rightPoint = 0;
            int start = 0;
            double prevValue = 0;
            if (Function(start) > 0)
            {
                while (Function(start) > 0)
                {
                    start--;
                }
                leftPoint = start;
                rightPoint = leftPoint + 1;
            }
            else
            {
                if (Function(start) == 0)
                {
                    points.Add($"The Route : {0}");
                    return points;
                }
                else
                {
                    while (Function(start) < 0)
                    {
                        start++;
                    }
                    rightPoint = start;
                    leftPoint = rightPoint - 1;
                }
            }
            double h = 0.0001;
            if (Function(rightPoint) * TwiceDiferation(rightPoint, h) > 0)
            {
                while (Math.Abs(prevValue - rightPoint) > eps)
                {
                    prevValue = rightPoint;
                    points.Add($" : {prevValue}");
                    rightPoint = prevValue - (Function(prevValue) / TwiceDiferation(prevValue, h));
                }

            }
            else
            {
                while (Math.Abs(prevValue - rightPoint) > eps)
                {
                    prevValue = leftPoint;
                    points.Add($" : {prevValue}");
                    leftPoint = prevValue - (Function(prevValue) / TwiceDiferation(prevValue, h));
                }
            }
            return points;

        }

        static List<string> Veterler(double eps)
        {
            List<string> points = new List<string>();
            double leftPoint = 0;
            double rightPoint = 0;
            int start = 0;
            double value = 0;
            double prevValue = 0;
            if (Function(start) > 0)
            {
                while (Function(start) > 0)
                {
                    start--;
                }
                leftPoint = start;
                rightPoint = leftPoint + 1;
            }
            else
            {
                if (Function(start) == 0)
                {
                    points.Add($"The Route : {0}");
                    return points;
                }
                else
                {
                    while (Function(start) < 0)
                    {
                        start++;
                    }
                    rightPoint = start;
                    leftPoint = rightPoint - 1;
                }
            }
            double h = 0.0001;
            if (TwiceDiferation(leftPoint, h) < 0)
            {
                prevValue = leftPoint;
                while (Math.Abs(prevValue - value) > eps)
                {
                    if (value != 0)
                    {
                        prevValue = value;
                    }
                    points.Add($" : {prevValue}");
                    value = ((prevValue * Function(rightPoint)) - (rightPoint * Function(prevValue))) / (Function(rightPoint) - Function(prevValue));
                }
            }
            else
            {
                prevValue = rightPoint;
                while (Math.Abs(prevValue - value) > eps)
                {
                    if (value != 0)
                    {
                        prevValue = value;
                    }
                    points.Add($" : {prevValue}");
                    value = ((leftPoint * Function(prevValue)) - (prevValue * Function(leftPoint))) / (Function(prevValue) - Function(leftPoint));
                }
            }
            return points;
        }

        static List<string> Common(double eps)
        {
            List<string> points = new List<string>();
            double leftPoint = 0;
            double rightPoint = 0;
            int start = 0;
            double value = 0;
            double prevValueNewton = 0;
            double prevValue = 0;
            if (Function(start) > 0)
            {
                while (Function(start) > 0)
                {
                    start--;
                }
                leftPoint = start;
                rightPoint = leftPoint + 1;
            }
            else
            {
                if (Function(start) == 0)
                {
                    points.Add($"The Route : {0}");
                    return points;
                }
                else
                {
                    while (Function(start) < 0)
                    {
                        start++;
                    }
                    rightPoint = start;
                    leftPoint = rightPoint - 1;
                }
            }
            double h = 0.0001;
            if (Function(rightPoint) * TwiceDiferation(rightPoint, h) > 0)
            {
                prevValue = rightPoint;
                while (Math.Abs(prevValueNewton - rightPoint) > eps)
                {
                    prevValueNewton = rightPoint;
                    points.Add($" : {prevValueNewton} - Nyuton Toxunanlar Koku");
                    rightPoint = prevValueNewton - (Function(prevValueNewton) / TwiceDiferation(prevValueNewton, h));

                    if (value != 0)
                    {
                        prevValue = value;
                    }
                    points.Add($" : {prevValue} - Veterler Koku");
                    value = ((leftPoint * Function(prevValue)) - (prevValue * Function(leftPoint))) / (Function(prevValue) - Function(leftPoint));
                }

            }
            else
            {
                prevValue = leftPoint;
                while (Math.Abs(prevValueNewton - rightPoint) > eps)
                {
                    prevValueNewton = leftPoint;
                    points.Add($" : {prevValueNewton} - Nyuton Toxunanlar Koku");
                    leftPoint = prevValueNewton - (Function(prevValueNewton) / TwiceDiferation(prevValueNewton, h));

                    if (value != 0)
                    {
                        prevValue = value;
                    }
                    points.Add($" : {prevValue} - Veterler Koku");
                    value = ((prevValue * Function(rightPoint)) - (rightPoint * Function(prevValue))) / (Function(rightPoint) - Function(prevValue));
                }
            }
            return points;

        }

        static double Duzbucaqlilar(double a, double b, int n)
        {
            double[] funcValues = new double[n + 1];
            double value = 0;
            double deltaX = Math.Abs(a - b) / n;
            double integralSum = 0;
            if (a < b)
            {
                value = a;
            }
            else
            {
                value = b;
            }
            for (int i = 0; i <= n; i++)
            {
                funcValues[i] = IntegralFunction(value);
                value += deltaX;
            }
            for (int i = 0; i < funcValues.Length - 1; i++)
            {
                integralSum += funcValues[i];
            }
            integralSum *= deltaX;
            return integralSum;
        }

        static double Trapesler(double a, double b, int n)
        {
            double[] funcValues = new double[n + 1];
            double value = 0;
            double deltaX = Math.Abs(a - b) / n;
            double integralSum = 0;
            if (a < b)
            {
                value = a;
            }
            else
            {
                value = b;
            }
            for (int i = 0; i <= n; i++)
            {
                funcValues[i] = IntegralFunction(value);
                value += deltaX;
            }
            for (int i = 0; i < funcValues.Length - 1; i++)
            {
                double x = ((deltaX / 2) * (funcValues[i] + funcValues[i + 1]));
                integralSum += x;
            }

            return integralSum;
        }
        static double Simpson(double a,double b,int n)
        {
            double[] funcValues = new double[n + 1];
            double value = 0;
            double deltaX = Math.Abs(a - b) / n;
            double integralSum = 0;
            if (a < b)
            {
                value = a;
            }
            else
            {
                value = b;
            }
            for (int i = 0; i <= n; i++)
            {
                funcValues[i] = IntegralFunction(value);
                value += deltaX;
            }
            for (int i = 0; i < funcValues.Length - 2; i++)
            {
                integralSum += (funcValues[i] + funcValues[i + 1] + funcValues[i + 2]);
            }
            integralSum *= deltaX / 3;
            return integralSum;
        }
        public static void Main()
        {
            int counter = 0;
            Console.Write("Epslon Daxil Edin : ");
            double eps = double.Parse(Console.ReadLine());

            Console.WriteLine("Parcanin Yariya Bolme Usulu : \n");
            foreach (var item in SplitHalf(eps))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Nyuton : ");
            foreach (var item in Nyuton(eps))
            {
                if (counter == 0)
                {
                    Console.WriteLine($"Parcanin Kokunun secildiyi ilk qiymet x0 dir ");
                }
                Console.WriteLine($"x{counter}" + item);
                counter++;
            }

            Console.WriteLine("\nVeterler :");
            counter = 0;
            foreach (var item in Veterler(eps))
            {
                if (counter == 0)
                {
                    Console.WriteLine($"Parcanin Kokunun secildiyi ilk qiymet x0 dir ");
                }
                Console.WriteLine($"x{counter}" + item);
                counter++;
            }

            Console.WriteLine("\nBirlesmis Usul : ");
            counter = 0;
            foreach (var item in Common(eps))
            {
                Console.WriteLine($"x{counter}" + item);
                counter++;
            }

            Console.WriteLine("\n Sade Iterasiya Usulu : ");
            counter = 0;
            foreach (var item in Iteration(eps))
            {
                Console.WriteLine($"x{counter}" + item);
                counter++;
            }

            Console.WriteLine($"\nTrapesler usulu integral ucun : {Trapesler(-1, 3, 100)}");

            Console.WriteLine($"\nDuzbucaqlialr usulu integral ucun : {Duzbucaqlilar(-1, 3, 100)}");

            Console.WriteLine($"\nSimpson usulu integral ucun : {Simpson(-1, 3, 100)}");

        }
    }
}