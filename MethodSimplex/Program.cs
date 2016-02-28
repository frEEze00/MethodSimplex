using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSimplex
{
    class Program
    {
        //Matrix for test
        private static List<List<double>> matrix = new List<List<double>>
        {
            new List<double>{ 14, 3, 2, 8, 1, 0, 0 },
            new List<double>{ 5, 2, 0, 1, 0, 1, 0 },
            new List<double>{ 13, 3, 3, 1, 0, 0, 1 },
            new List<double>{ 0, -11, -5, -4, 0, 0, 20 }
        };

        static void Main(string[] args) {
            ISimplex simplexMethod = new Simplex(matrix, 4, 7);
            simplexMethod.GetDataFromFile(@"Input Data\test.txt");
            simplexMethod.Calculate();
            Console.WriteLine("Answer: {0}", simplexMethod.Answer.ToString());
            Console.ReadKey();
        }
    }
}