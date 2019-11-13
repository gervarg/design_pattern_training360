using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    class Matrix : IEnumerable<int>
    {
        private int[,] table { get; set; }

        private Matrix(int[,] table)
        {
            this.table = table;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MatrixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MatrixEnumerator : IEnumerator<int>
        {
            int i, j = 0;
            private readonly Matrix matrix;

            public MatrixEnumerator(Matrix matrix)
            {
                this.matrix = matrix;
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                i++;

                if (i >= matrix.table.GetLength(0))
                {
                    i = 0;
                    j++;
                }
                
                if (i < matrix.table.GetLength(0) && j < matrix.table.GetLength(1))
                {
                    Current = matrix.table[i, j];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                i = -1;
                j = -1;
            }
        }
    }
}
