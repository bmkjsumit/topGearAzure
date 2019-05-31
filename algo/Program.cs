using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region right angle triangle
            //var key = Console.ReadLine();
            //int resultTestCases = int.Parse(key);

            //List<int> lst = new List<int>();
            //for (int i = 0; i < resultTestCases; i++)
            //{
            //    var lines = Console.ReadLine();
            //    int resultLines = int.Parse(lines);
            //    lst.Add(resultLines);
            //}
            //int testCases = 1;
            //foreach (var rows in lst)
            //{
            //    int i, j;
            //    Console.WriteLine("Case #{0}:", testCases);
            //    for (i = 1; i <= rows; i++)
            //    {
            //        /* Print spaces in decreasing order of row */
            //        for (j = i; j < rows; j++)
            //        {
            //            Console.Write(" ");
            //        }

            //        /* Print star in increasing order or row */
            //        for (j = 1; j <= i; j++)
            //        {
            //            Console.Write("*");
            //        }

            //        /* Move to next line */
            //        Console.Write("\n");
            //    }
            //    testCases++;
            //}
            //Console.ReadKey();
            #endregion

            #region hollow diagram          

            //var key = Console.ReadLine();
            //int resultTestCases = int.Parse(key);

            //List<int> lst = new List<int>();
            //for (int i = 0; i < resultTestCases; i++)
            //{
            //    var lines = Console.ReadLine();
            //    int resultLines = int.Parse(lines);
            //    int numberType = resultLines % 2;
            //    if (numberType!=1)
            //    {
            //        Console.WriteLine("please enter odd number only");
            //        return;
            //    }
            //    lst.Add(resultLines);
            //}
            //int testCases = 1;
            //foreach (var row in lst)
            //{
            //    int i, j, k = 0;
            //    int n = row - row / 2;
            //    Console.WriteLine("Case #{0}:", testCases);
            //    // Print upper triangle 
            //    for (i = 1; i <= n; i++)
            //    {

            //        // Print spaces 
            //        for (j = 1; j <= n - i; j++)
            //        {
            //            Console.Write(" ");
            //        }

            //        // Print # 
            //        while (k != (2 * i - 1))
            //        {
            //            if (k == 0 || k == 2 * i - 2)
            //                Console.Write("*");
            //            else
            //                Console.Write(" ");
            //            k++;
            //        }
            //        k = 0;

            //        // move to next row 
            //        Console.WriteLine();
            //    }
            //    n--;

            //    // Print lower triangle 
            //    for (i = n; i >= 1; i--)
            //    {

            //        // Print spaces 
            //        for (j = 0; j <= n - i; j++)
            //        {
            //            Console.Write(" ");
            //        }

            //        // Print # 
            //        k = 0;
            //        while (k != (2 * i - 1))
            //        {
            //            if (k == 0 || k == 2 * i - 2)
            //                Console.Write("*");
            //            else
            //                Console.Write(" ");
            //            k++;
            //        }
            //        Console.WriteLine();
            //    }
            //    testCases++;
            //}
            //Console.ReadKey();

            #endregion

            #region Sum of array elements
            //var key = Console.ReadLine();
            //int resultTestCases = int.Parse(key);

            //List<string> lst = new List<string>();
            //for (int i = 0; i < resultTestCases*2; i++)
            //{
            //    var arr = Console.ReadLine();                
            //    lst.Add(arr);
            //}
            //int counter = 1;
            //foreach (var array in lst)
            //{
            //    if (counter % 2 == 0)
            //    {
            //        //Console.WriteLine(array.Trim().Split(' ').Sum(x=>int.Parse(x)).ToString());
            //        List<string> elements = array.Trim().Split(' ').ToList();
            //        long sum = 0;
            //        foreach (var item in elements)
            //        {
            //            sum = sum + Convert.ToInt64(item);
            //        }
            //        Console.WriteLine(sum.ToString());
            //    }
            //    counter++;
            //}
            //Console.ReadKey();
            #endregion
            #region Trailing Zeros Easy
            //var key = Console.ReadLine();
            //int resultTestCases = int.Parse(key);

            //List<long> lst = new List<long>();
            //for (int i = 0; i < resultTestCases ; i++)
            //{
            //    var arr = Console.ReadLine();
            //    lst.Add(Convert.ToInt64(arr));
            //}            
            //foreach (var number in lst)
            //{
            //    // Initialize result 
            //    long count = 0;

            //    // Keep dividing n by powers 
            //    // of 5 and update count 
            //    for (long i = 5; number / i >= 1; i *= 5)
            //        count += number / i;

            //    Console.WriteLine(count);
            //}
            //Console.ReadKey();
            #endregion

            #region rotate the matrix by 90 degrees in clockwise
            var key = Console.ReadLine();
            int resultTestCases = int.Parse(key);

            //List<int> lstMatrixSize = new List<int>();
           
            List<List<string>> lstMatrix = new List<List<string>>();
            for (int i = 0; i < resultTestCases; i++)
            {
                var size = int.Parse(Console.ReadLine().Trim());
                List<string> matrix = new List<string>();
                for (int j = 1; j <= size; j++)
                {
                    matrix.Add(Console.ReadLine().Trim());
                }
                lstMatrix.Add(matrix);
            }
            int testCases = 1;
            foreach (var matrixItem in lstMatrix)
            {
                //int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };                
                Console.WriteLine("Test Case #{0}:", testCases);
                var R = matrixItem.Count;
                var C = matrixItem.Count;
                int N = matrixItem.Count;
                var a = new int[R, C];
                for (int r = 0; r != R; r++)
                    for (int c = 0; c != C; c++)
                        a[r, c] = Convert.ToInt32(matrixItem[r].Split()[c]);

                // Traverse each cycle 
                for (int i = 0; i < N / 2; i++)
                {
                    for (int j = i; j < N - i - 1; j++)
                    {

                        // Swap elements of each cycle 
                        // in clockwise direction 
                        int temp = a[i, j];
                        a[i, j] = a[N - 1 - j, i];
                        a[N - 1 - j, i] = a[N - 1 - i, N - 1 - j];
                        a[N - 1 - i, N - 1 - j] = a[j, N - 1 - i];
                        a[j, N - 1 - i] = temp;
                    }
                }
                // Function for print matrix 
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(a[i, j] + " ");
                    Console.Write("\n");
                }
                //for (int i = matrixItem.Count()-1; i >=0 ; i--)
                //{
                //    int k = 0;
                //    for (int j = 0; j <= matrixItem.Count() - 1; j++)
                //    {
                //        Console.Write(matrixItem[i].Split(' ')[k]);  k++;
                //    }                    
                //    Console.Write("\n");
                //}                
                testCases++;
                //Console.Write("\n");
            }
            Console.ReadKey();
            #endregion
        }
    }
}
