using System;


namespace lab5
{
    public class Matrix
    {
        public int DegreeOfMatrix { get; }
        public double[] row;
        public double[] column;
        public Matrix(int n)
        {
            DegreeOfMatrix = n;
            row = new double[DegreeOfMatrix];
            column = new double[DegreeOfMatrix];
            for (int i = 0; i < n; i++)
            {
                row[i] = i + 1;
                column[i] = i + n;
            }
        }
        public Matrix(Matrix matrix)
        {
            DegreeOfMatrix = matrix.DegreeOfMatrix;
            row = new double[DegreeOfMatrix];
            column = new double[DegreeOfMatrix];
            for (int i = 0; i < DegreeOfMatrix; i++)
            {
                row[i] = matrix.row[i];
                column[i] = matrix.column[i];
            }
        }
        public Matrix()
        {
			int num = -1;
			Console.Write("Enter degree of matrix: ");
			while (!int.TryParse(Console.ReadLine(), out num) || num < 0)
			{
				Console.Write("Invalid input. Try again: ");
			}
            DegreeOfMatrix = num;
			row = new double[DegreeOfMatrix];
			column = new double[DegreeOfMatrix];
			for (int i = 0; i < DegreeOfMatrix; i++)
			{
				Console.Write("Enter value of element in first row: ");
				row[i] = Convert.ToDouble(Console.ReadLine());
			}
            for (int i = 0; i < DegreeOfMatrix; i++)
            {
                Console.Write("Enter value of element in last column: ");
                column[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
        public void SolveSystemOfLinearEquations(double[] right_part, double[] solution)
        {
            double Fk, sk, rk;
            var x = new double[DegreeOfMatrix];
            double[] y = new double[DegreeOfMatrix];
            double[] a = row;
            x[0] = 1/a[0];
            y[0] = 1/a[0];
            solution[0] = right_part[0] * x[0];
            for (int k = 2; k < DegreeOfMatrix + 1; ++k)
            {
                x[k-1] = 0;
                solution[k-1] = 0;
                rk = 0;
                Fk = 0;
                for (int i = 2; i < k + 1; ++i)
                {
                    y[i - 1] = x[k - i];
                    rk += a[i - 1] * y[i - 1];
                    Fk += a[i - 1] * solution[k - i];
                }
                Fk = right_part[k - 1] - Fk;
                sk = 1/(1 - rk * rk);
                rk = sk * (-rk);
                for (int j = 1; j < k + 1; ++j)
                {
                    x[j - 1] = x[j - 1] * sk + y[j - 1] * rk;
                    solution[k - j] += x[j - 1] * Fk;
                }
            }
        }
        public override string ToString()
        {
            string str = "";
            for (var i = 0; i < row.Length; i++)
            {
                for (var j = 0; j < column.Length; j++)
                {
                    if (i + j < row.Length) { str += row[i + j].ToString(); }
                    else { str += column[i + j - row.Length + 1].ToString(); }
                }
                str += "\n";
            }
            return str;
        }
    }
}
