using System;
using System.Collections.Generic;

namespace NET.S._2020.Vyskvarko._02
{
    class Program
    {
        static void Main()
        {
            //InsertNumber
            Console.WriteLine("InsertNumber\n");
            MyMath.DisplayInsertNumber(15, 15, 0, 0);
            MyMath.DisplayInsertNumber(8, 15, 0, 0);
            MyMath.DisplayInsertNumber(8, 15, 3, 8);

            //FindNextBiggerNumber
            Console.WriteLine("\n\nFindNextBiggerNumber\n");
            MyMath.DisplayBiggerNumber(12);
            MyMath.DisplayBiggerNumber(513);
            MyMath.DisplayBiggerNumber(2017);
            MyMath.DisplayBiggerNumber(414);
            MyMath.DisplayBiggerNumber(144);
            MyMath.DisplayBiggerNumber(1234321);
            MyMath.DisplayBiggerNumber(1234126);
            MyMath.DisplayBiggerNumber(3456432);
            MyMath.DisplayBiggerNumber(10);
            MyMath.DisplayBiggerNumber(20);

            //FilterDigit
            Console.WriteLine("\n\nFilterDigit\n");
            MyMath.DisplayFilterDigit(new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7);
            MyMath.DisplayFilterDigit(new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 60, 65, 67 }, 6);
            MyMath.DisplayFilterDigit(new List<int> { 22, 2, 3, 4, 5, 6, 7, 68, 69, 70, 25, 27 }, 1);

            //FindNthRoot
            Console.WriteLine("\n\nFindNthRoot\n");
            MyMath.DisplayFindNthRoot(1, 5, 0.0001);
            MyMath.DisplayFindNthRoot(8, 3, 0.0001);
            MyMath.DisplayFindNthRoot(0.001, 3, 0.0001);
            MyMath.DisplayFindNthRoot(0.04100625, 4, 0.0001);
            MyMath.DisplayFindNthRoot(0.0279936, 7, 0.0001);
            MyMath.DisplayFindNthRoot(0.0081, 4, 0.1);
            MyMath.DisplayFindNthRoot(-0.008, 3, 0.1);
            MyMath.DisplayFindNthRoot(0.004241979, 9, 0.00000001);

            Console.ReadLine();
        }
    }
}
