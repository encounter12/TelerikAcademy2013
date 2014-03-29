namespace Matrices
{
    using System;
    using System.Text;

    
    public class Matrix<Number>
    {
        protected Number[,] elements;

        protected int rows;
        protected int columns;

      
        public Matrix(int rows, int columns)
        {
            elements = new Number[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }

     
        public Number this[int x, int y]
        {
            get
            {
                return elements[x, y];
            }
            set
            {
                elements[x, y] = value;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }
        }

     
        public int Columns
        {
            get
            {
                return columns;
            }
        }

     
        public static Matrix<Number> operator +(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> addition = new Matrix<Number>(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    addition[i, j] = (dynamic)matrixOne[i, j] + matrixTwo[i, j];
                }
            }

            return addition;
        }

      
        public static Matrix<Number> operator -(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> subtraction = new Matrix<Number>(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    subtraction[i, j] = (dynamic)matrixOne[i, j] - matrixTwo[i, j];
                }
            }

            return subtraction;
        }

       
        public static Matrix<Number> operator *(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Columns == matrixTwo.Rows))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> m = new Matrix<Number>(matrixOne.Rows, matrixTwo.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    for (int k = 0; k < matrixOne.Columns; k++)
                    {
                        m[i, j] += (dynamic)matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            return m;
        }

        private static bool BoolOperator(Matrix<Number> matrix, bool value)
        {
            foreach (Number item in matrix.elements)
            {
                if ((dynamic)item != 0)
                {
                    return value;
                }
            }

            return !value;
        }

       
        public static bool operator true(Matrix<Number> matrix)
        {
            return BoolOperator(matrix, true);
        }

        public static bool operator false(Matrix<Number> matrix)
        {
            return BoolOperator(matrix, false);
        }

        public override string ToString()
        {
            Number maxElement = elements[0, 0];

            foreach (Number element in elements)
            {
                maxElement = Math.Max((dynamic)maxElement, (dynamic)element);
            }

            int maxCellSize = Convert.ToString(maxElement + " ").Length;

            StringBuilder info = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    info.Append(Convert.ToString(elements[i, j]).PadRight(maxCellSize, ' ') + (j != columns - 1 ? " " : Environment.NewLine));
                }
            }

            return info.ToString();
        }
    }
}