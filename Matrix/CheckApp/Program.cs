using System;
using Matrix;

namespace CheckApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Matrix<int> m = new Matrix<int>(3,5);
			m.SetValue(1,2, 0);
			m.Print();
			m.TransposeMatrix();
			m.GetColumn(0);
			m.Print();
        }
    }
}
