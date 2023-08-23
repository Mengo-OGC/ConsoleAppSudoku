using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class SuperCell : IEnumerable<Cell>
    {
        private Cell[,] _matrix;

        #region metodi
        public void Add(int r, int c, int v)
        {
            if (_matrix.ControlloDimensioni(r, c))
                _matrix[r, c].Valore = v;
        }

        public void Remove(int r, int c, int v)
        {
            if (_matrix.ControlloDimensioni(r, c))
                _matrix[r, c].Remove(v);
        }
        #endregion

        #region interfaccie
        public IEnumerator<Cell> GetEnumerator()
        {
            foreach (Cell c in _matrix)
                yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public Cell this[int i, int j]
        {
            get
            {
                if (_matrix.ControlloDimensioni(i, j))
                    return _matrix[i, j];
                return null;
            }
            set
            {
                if (_matrix.ControlloDimensioni(i, j))
                    _matrix[i, j] = value;
            }
        }

        #region costruttori
        public SuperCell() : this (3)
        {
            
        }

        public SuperCell(int d)
        {
            _matrix = new Cell[d,d];
        }

        public SuperCell(Cell[,] mat)
        {
            _matrix = mat;
        }
        #endregion
    }
}
