using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace lab5
{
    class Program
    {
        [DllImport(@"C:\\Users\\etest\\source\\repos\\DllForLab5\\Debug\\DLLForLab5.dll")]
        public static extern void hello();

        [DllImport(@"C:\\Users\\etest\\source\\repos\\DllForLab5\\Debug\\DLLForLab5.dll")]
        public static extern double MeasureTime(int degree_of_matrix, int repeats);

        [DllImport(@"C:\\Users\\etest\\source\\repos\\DllForLab5\\Debug\\DLLForLab5.dll")]
        public static extern void MatrixSolution(double[] row, double[] column, double[] right, double[] answers, int length);

        public static double CSMeasureTime(int degreeMatrix, int repeats)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int i = 0; i < repeats; i++)
            {
                Random random = new Random();
                Matrix matrix = new Matrix(degreeMatrix);
                double[] right = new double[degreeMatrix];
                double[] ans = new double[degreeMatrix];
                for (int j = 0; j < degreeMatrix; j++)
                {
                    right[j] = random.NextDouble() * 5;
                }
                matrix.SolveSystemOfLinearEquations(right, ans);
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------1ST ASSIGNMENT-----------------");
            double[] rights = new double[] { -3, 1, 2 };
            Matrix matrix_cs = new Matrix(3);
            Console.WriteLine(matrix_cs.ToString());
            double[] ans = new double[] { 0, 0, 0 };
            matrix_cs.SolveSystemOfLinearEquations(rights, ans);
            Console.WriteLine("Solution for C#: ");
            foreach (var a in ans)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine("\n-----------------2ND ASSIGNMENT-----------------");
            hello();
            double[] ans2 = new double[] { 0, 0, 0 };
            MatrixSolution(matrix_cs.row, matrix_cs.column, rights, ans2, matrix_cs.DegreeOfMatrix);
            Console.WriteLine("Solution for C++: ");
            foreach (var a in ans2)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine("\n-----------------3RD ASSIGNMENT-----------------");
            TimeList timelist = new TimeList();
            Console.WriteLine("Enter name of file: ");
            string filename;
            filename = Console.ReadLine();
            try
            {
                if (File.Exists(filename))
                {
                    timelist.Load(filename);
                }
                else
                {
                    Console.WriteLine("File with this name is not found");
                    var myFile = File.Create(filename);
                    myFile.Close();
                }
                int repeat = 1;
                while (repeat < 2 && repeat > 0)
                {
                    Console.WriteLine("Enter matrix - 1");
                    Console.WriteLine("Exit out of program - 2");
                    repeat = Convert.ToInt32(Console.ReadLine());
                    switch (repeat)
                    {
                        case 1:
                            {
                                Console.Write("Enter degree of matrix: ");
                                int degree = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter number of repeats: ");
                                int number = Convert.ToInt32(Console.ReadLine());
                                double CSTime = CSMeasureTime(degree, number);
                                double CPPTime = MeasureTime(degree, number);
                                timelist.Add(new TimeItem(degree, number, CSTime, CPPTime, CSTime / CPPTime));
                                break;
                            }
                        case 2:
                            Console.WriteLine("TimeList: ");
                            Console.WriteLine(timelist.ToString());
                            timelist.Save(filename);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
