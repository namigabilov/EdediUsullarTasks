using System;
using System.Collections.Generic;

namespace ƏdədiÜsullar
{
    public class Program
    {
        static double Function(double x)
        {
            double func = (2 * Math.Pow(x, 2) + 3 * x - 2);
            return func;
        }

        static double TwiceDiferation(double x, double h)
        {
            double func = (Function(x + h) - 2 * Function(x) + Function(x - h)) / (Math.Pow(h, 2));
            return func;
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
                else if((Function(leftPoint) + Function(rightPoint)) / 2 == 0)
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

        static List<string> NyutonVeterler(double eps)
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
            if (Function(rightPoint)*TwiceDiferation(rightPoint,h) > 0)
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
            if (TwiceDiferation(leftPoint,h) < 0)
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
            foreach (var item in NyutonVeterler(eps))
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
        }
    }
}