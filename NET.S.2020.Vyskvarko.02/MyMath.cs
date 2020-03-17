using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2020.Vyskvarko._02
{
    internal static class MyMath
    {
        /// <summary>
        /// The method accepts a positive integer, converts it to a character.
        /// And in a cycle starting from this number, it searches for the next number that contains these characters.
        /// </summary>
        /// <param name="number">Positive integer.</param>
        /// <param name="time">Number finding time. "Environment.TickCount"</param>
        /// <param name="time2">Number finding time. " Stopwatch"</param>
        /// <returns>Next bigger number, if it is.</returns>
        private static int FindNextBiggerNumber(int number, out double time, out double time2)
        {
            double start = Environment.TickCount;
            double end;

            Stopwatch stopwatch = Stopwatch.StartNew();

            if (number != null)
            {
                if (number > 0)
                {
                    char[] chNumber = number.ToString().ToCharArray();
                    int numberDepth = (int)Math.Pow(10, chNumber.Length);

                    for (int i = number + 1; i < numberDepth; i++)
                    {
                        int count = 0;
                        string potentialNumber = i.ToString();

                        for (int j = 0; j < chNumber.Length; j++)
                        {
                            if (potentialNumber.Contains(chNumber[j].ToString()))
                            {
                                count++;
                                var index = potentialNumber.IndexOf(chNumber[j]);
                                potentialNumber = potentialNumber.Remove(index, 1);
                            }
                        }

                        if (count == chNumber.Length)
                        {
                            end = Environment.TickCount;
                            time = end - start;

                            stopwatch.Stop();
                            time2 = stopwatch.ElapsedMilliseconds;

                            return i;
                        }
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            end = Environment.TickCount;
            time = end - start;

            stopwatch.Stop();
            time2 = stopwatch.ElapsedMilliseconds;

            return -1;
        }

        /// <summary>
        /// The method takes a positive integer and passes it to the method "FindNextBiggerNumber".
        /// The result of execution is output to the console.
        /// </summary>
        /// <param name="number">Positive integer.</param>
        public static void DisplayBiggerNumber(int number)
        {
            int result = FindNextBiggerNumber(number, out double time, out double time2);

            Console.WriteLine($"{number}, Result: {result}, {time}ms, {time2}ms");
        }

        /// <summary>
        /// The method accepts a list of integers and a number to search.
        /// Translates them to a string. And checks the entry.
        /// If the list item contains a given number, adds it to the resulting list.
        /// </summary>
        /// <param name="sourceList">List of integers.</param>
        /// <param name="number">Number to search.</param>
        /// <returns>Filtered list.</returns>
        private static List<int> FilterDigit(List<int> sourceList, int number)
        {
            if (sourceList != null && number != null)
            {
                if (sourceList.Count != 0)
                {
                    List<int> resultList = new List<int>();
                    string numString = number.ToString();

                    for (int i = 0; i < sourceList.Count; i++)
                    {
                        string potentialElement = sourceList[i].ToString();

                        if (potentialElement.Contains(numString))
                        {
                            resultList.Add(sourceList[i]);
                        }
                    }
                    return resultList;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The method passes a list of integers and the number to search for the method "FilterDigit".
        /// The result of execution is output to the console.
        /// </summary>
        /// <param name="sourceList">List of integers.</param>
        /// <param name="number">Number to search.</param>
        public static void DisplayFilterDigit(List<int> sourceList, int number)
        {
            List<int> result = FilterDigit(sourceList, number);

            foreach (var s in sourceList)
            {
                Console.Write($"{s} ");
            }
            Console.Write("--> ");
            if (result.Count > 0)
            {
                foreach (var r in result)
                {
                    Console.Write($"{r} ");
                }
            }
            else
            {
                Console.Write("Not found!");
            }


            Console.WriteLine();
        }

        /// <summary>
        /// The method calculates the root of the number using the Newton method.
        /// </summary>
        /// <param name="a">Rational number.</param>
        /// <param name="n">Pow, natural number.</param>
        /// <param name="accuracy">Accuracy of calculation.</param>
        /// <returns>Root of the number.</returns>
        private static double FindNthRoot(double a, int n, double accuracy = 0.0001)
        {
            if (a != null && n != null && accuracy != null)
            {
                if (n > 0 && accuracy >= 0)
                {
                    double x0 = a / n;
                    double x1 = (1 / (double)n) * ((n - 1) * x0 + a / Pow(x0, (int)n - 1));

                    while (Math.Abs(x1 - x0) > accuracy)
                    {
                        x0 = x1;
                        x1 = (1 / (double)n) * ((n - 1) * x0 + a / Pow(x0, (int)n - 1));
                    }

                    double Pow(double a1, int pow)
                    {
                        double result = 1;
                        for (int i = 0; i < pow; i++)
                        {
                            result *= a1;
                        }
                        return result;
                    }

                    return x1;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The method accepts the number, pow and accuracy and passes them to the method "FindNthRoot"
        /// The result of execution is output to the console.
        /// </summary>
        /// <param name="a">Rational number.</param>
        /// <param name="n">Pow, natural number.</param>
        /// <param name="accuracy">Accuracy of calculation.</param>
        public static void DisplayFindNthRoot(double a, int n, double accuracy = 0.0001)
        {
            double result = MyMath.FindNthRoot(a, n, accuracy);

            Console.WriteLine($"({a},{n},{accuracy}), Result: {result}");
        }

        /// <summary>
        /// The method takes two numbers and bit positions and inserts the bits of the first number into the second.
        /// </summary>
        /// <param name="numberSource">First number.</param>
        /// <param name="numberIn">Second number.</param>
        /// <param name="i">i-bit.</param>
        /// <param name="j">j-bit.</param>
        /// <returns>The new number.The result of inserting bits.</returns>
        private static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (numberSource != null && numberIn != null && i != null && j != null)
            {
                if (i >= 0 || j >= 0 || i < 31 || j < 31)
                {
                    if (i <= j)
                    {
                        int bitMask = ((2 << (j - i)) - 1) << i;
                        int result = (numberSource & ~bitMask) | ((numberIn << i) & bitMask);
                        return result;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The method takes two numbers and bit positions and passes them to the method "InsertNumber"
        /// The result of execution is output to the console.
        /// </summary>
        /// <param name="numberSource">First number.</param>
        /// <param name="numberIn">Second number.</param>
        /// <param name="i">i-bit.</param>
        /// <param name="j">j-bit.</param>
        public static void DisplayInsertNumber(int numberSource, int numberIn, int i, int j)
        {
            int result = InsertNumber(numberSource, numberIn, i, j);
            Console.WriteLine($"({numberSource},{numberIn},{i},{j}) --> {result}");
        }
    }   
}
