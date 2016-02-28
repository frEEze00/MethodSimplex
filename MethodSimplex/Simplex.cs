using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodSimplex
{
    public class Simplex : ISimplex
    {
        private double answer = 0;
        private int columns;
        private int rows;
        private List<List<double>> matrix;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">Values matrix</param>
        /// <param name="columns">Count columns</param>
        /// <param name="rows">Count rows</param>
        public Simplex(List<List<double>> matrix, int columns, int rows)
        {
            this.matrix = matrix;
            this.columns = columns;
            this.rows = rows;
        }

        public void Calculate()
        {
            int i = 0;
            double buf;
            double minElement = matrix[columns - 1].Min();

            while (minElement < 0)
            {
                buf = Double.MaxValue;
                int j = matrix[columns - 1].IndexOf(minElement);

                for (int n = 0; n < columns - 1; n++)
                {
                    double value = matrix[n][0] / matrix[n][j];

                    if (value < buf && value > 0)
                    {
                        buf = value;
                        i = n;
                    }
                }

                buf = matrix[i][j];
                if (matrix[i][j] != 1)
                {
                    for (int n = 0; n < rows; n++)
                        matrix[i][n] /= buf;
                }

                for (int n = 0; n < columns; n++)
                {
                    if (n != i)
                    {
                        buf = matrix[n][j];

                        if (buf != 0)
                        {
                            for (int k = 0; k < rows; k++)
                                matrix[n][k] -= (buf * matrix[i][k]);
                        }
                    }
                }

                minElement = matrix[columns - 1].Min();
            }

            answer = matrix[columns - 1][0];
        }

        public double Answer
        {
            get { return answer; }
        }
    }
}