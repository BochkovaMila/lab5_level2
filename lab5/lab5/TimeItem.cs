using System;

namespace lab5
{
    [Serializable]
    public class TimeItem
    {
        public int degree_of_matrix;
        public int repeats;
        public double cs_time;
        public double cpp_time;
        public double ratio;
        public TimeItem(int t_degree, int t_repeats, double t_cs, double t_cpp, double t_ratio)
        {
            degree_of_matrix = t_degree;
            repeats = t_repeats;
            cs_time = t_cs;
            cpp_time = t_cpp;
            ratio = t_ratio;
        }
        public override string ToString()
        {
            String str = "Matrix Degree\t" + "Repeats\t" + "Time for C#\t" + "Time for C++\t" + "C#/C++ ratio\n";
            str += degree_of_matrix.ToString() + "\t\t" + repeats.ToString() + "\t" + cs_time.ToString() + "\t\t" + cpp_time.ToString() + "\t\t" + ratio.ToString() + "\n";
            return str;
        }
    }
}
