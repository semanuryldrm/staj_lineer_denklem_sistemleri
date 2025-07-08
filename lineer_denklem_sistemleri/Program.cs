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
}
