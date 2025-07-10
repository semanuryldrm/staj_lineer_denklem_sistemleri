using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lineer_denklem_sistemleri
{
    internal class Gauss_Eliminasyonu
    {
        static void Main(string[] args)
        {
            int[,] A = new int[3, 4]
            {
                { 2, 1, 1, 5 },
                { 4, 3, 1, 11 },
                { -2, 1, 2, -1 }
            };
            #region x_degiskeni

            var pv1 = A[0, 0];
            var ratio1 = A[1, 0] / pv1;
            var ratio2 = A[2, 0] / pv1;

            for (int i = 0; i < 4; i++) { 
            for (int i = 0; i < 4; i++)
            {
                A[1, i] -= A[0, i] * ratio1;
                A[2, i] -= A[0, i] * ratio2;

            }

            Console.WriteLine("ok");

            #endregion

            var pv2 = A[1, 1];
            var ratio3 = A[2, 1];

            for (int i = 0; i < 4; i++)
            {
                A[2, i] -= A[1, i] * ratio3;
            }

            double z = (double)A[2, 3] / (double)A[2, 2];
            Console.WriteLine($"z: {z}");
            double y = (double)A[1, 3] + z;
            Console.WriteLine($"y: {y}");
            double x = ((double)A[0, 3] - y - z) / 2;
            Console.WriteLine($"x: {x}");

        }
    }

    internal class Gauss_Jordan_Eliminasyonu
    {
        static void Main(string[] args)
        {
            double[,] A = new double[3, 4]
            {
                { 2, 1, 1, 5 },
                { 4, 3, 1, 11 },
                { -2, 1, 2, -1 }
            };
            //birim matrise çevirerek çözüm yapıcaz

            var pv1 = A[0, 0];
            for (int i = 0; i < 4; i++)
            {
                A[0, i] -= A[0, i] / 2;
                A[1, i] = A[1, i] - (A[0, i] * 4);
                A[2, i] = A[2, i] + (A[0, i] * 2);
        }

            var pv2 = A[1, 1];
            for (int i = 0; i < 4; i++)
            {
                A[0, i] = A[0, i] - 0.5 * A[1, i];
                A[2, i] = A[2, i] - 2 * A[1, i];
            }

            var pv3 = A[2, 2];
            for (int i = 0; i < 4; i++)
            {
                A[2, i] = A[2, i] / 5;
                A[0, i] = A[0, i] - A[2, i];
                A[1, i] = A[1, i] + A[2, i];

            }
            double x = A[0, 3];
            Console.WriteLine($"x: {x}");
            double y = A[1, 3];
            Console.WriteLine($"y: {y}");
            double z = A[2, 3];
            Console.WriteLine($"z: {z}");

    }
}

    internal class LU_Decomposition
    {
        static void Main(string[] args)
        {
            double[,] A = new double[3, 3]
            {
                { 2, 1, 1 },
                { 4, 3, 1 },
                { -2, 1, 2 }
            };
            double[,] B = new double[3, 1]
            {
                { 5 },
                { 11 },
                { -1 },
            };
            double[,] U = new double[3, 3]
            {
                { 2, 1, 1 },
                { 4, 3, 1 },
                { -2, 1, 2 }
            };
            double[,] L = new double[3, 3]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            for (int i = 0; i < 3; i++)
            {
                U[1, i] -=2 * U[0, i];
                U[2, i] += U[0, i];

            }
            L[1, 0] = A[1, 0] / A[0, 0];
            L[2, 0] = A[2, 0] / A[0, 0];
            L[2, 1] = U[2, 1] / U[1, 1];

            for (int i = 0; (i < 3); i++)
            {
                U[2, i] -= 2 * U[1, i];
            }

            double[] y = new double[3];
            y[0] = B[0, 0];
            y[1] = B[1, 0] - L[1, 0] * y[0];
            y[2] = B[2, 0] - L[2, 0] * y[0] - L[2, 1] * y[1];

            double[] x = new double[3];

            x[2] = y[2] / U[2, 2]; 
            x[1] = (y[1] - U[1, 2] * x[2]) / U[1, 1];
            x[0] = (y[0] - U[0, 1] * x[1] - U[0, 2] * x[2]) / U[0, 0];

            Console.WriteLine($"x: {x[0]}");
            Console.WriteLine($"y: {x[1]}");
            Console.WriteLine($"z: {x[2]}");

        }



    }

}
