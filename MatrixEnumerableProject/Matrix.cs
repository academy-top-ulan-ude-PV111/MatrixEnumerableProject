using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEnumerableProject
{
    public class MatrixHorizontalEnumerator : IEnumerator
    {
        int[,] items;
        int row, col;

        int rows, columns;

        public MatrixHorizontalEnumerator(int[,] items)
        {
            this.items = items;
            row = 0;
            col = -1;

            rows = this.items.GetUpperBound(0) + 1;
            columns = this.items.Length / rows;
        }
        //public int Current => throw new NotImplementedException();

        object IEnumerator.Current
        {
            get
            {
                if (col == -1 || col >= columns)
                    throw new IndexOutOfRangeException();
                return items[row, col];
            }
        }
        public bool MoveNext()
        {
            if(col < columns - 1)
            {
                col++;
                return true;
            }
            else
            {
                if(row < rows - 1)
                {
                    row++;
                    col = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Reset()
        {
            row = 0;
            col = -1;
        }
    }

    public class MatrixVerticalEnumerator : IEnumerator
    {
        int[,] items;
        int row, col;

        int rows, columns;
        public MatrixVerticalEnumerator(int[,] items) => this.items = items;
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    public class Matrix : IEnumerable
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public int[,] matrix;

        public Matrix()
        {
            matrix = null;
        }
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = new int[Rows, Columns];
        }

        public int this[int row, int col]
        {
            get => matrix[row, col];
            set => matrix[row, col] = value;
        }

        public void RandomInit(int maxValue = 100)
        {
            Random random = new Random();

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    matrix[i, j] = random.Next(maxValue);
        }


        public override string ToString()
        {
            string strMatrix = "";

            for(int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    strMatrix += $"{matrix[i, j]}\t";
                strMatrix += "\n";
            }
            return strMatrix;
        }

        public IEnumerator GetEnumerator()
        {
            //return new MatrixHorizontalEnumerator(matrix);
            return new MatrixVerticalEnumerator(matrix);
        }
    }
}
