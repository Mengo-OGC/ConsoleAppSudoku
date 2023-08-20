using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Sudoku : Dimensioni, IEnumerable<Cell>
    {
        private Cell[,] _matrix;
        private SuperCell[,] _matrixValoriNoti;

        #region interfacce
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

        #region proprietà
        public Cell this[int r, int c]
        {
            get
            {
                Controllo(r, c);
                return _matrix[r, c];
            }
            set
            {
                Controllo(r, c);
                _matrix[r, c] = value;
            }
        }

        private void Controllo(int r, int c)
        {
            if (r < 0
                    ||
                    r >= _matrix.GetLength(0)
                    ||
                    c < 0
                    ||
                    c >= _matrix.GetLength(1))
                throw new Exception("Error");
        }

        #endregion

        #region costruttori

        public Sudoku() : this (9, 3) { }


        public Sudoku(int d, int dSuperCell) : this(d, d, dSuperCell, dSuperCell)
        {

        }

        public Sudoku(int r, int c, int rSC, int cSC)
        {
            _matrix = new Cell[r, c];
            _matrixValoriNoti = new SuperCell[rSC, cSC];

            Righe = r;
            Colonne = c;

            for (int i = 0; i < Righe; i++)
                for (int j = 0; j < Colonne; j++)
                    _matrix[i, j] = new Cell(i, j);
        }

        public Sudoku(Cell[,] mat)
        {
            _matrix = mat;
        }
        #endregion


        public void Risolvi()
        {
            Riempi();
            //Semplifica();
        }

        #region metodi
        private void Riempi()
        {
            for (int i = 0; i < Righe; i++)
                for (int j = 0; j < Colonne; j++)
                {
                    Cell c = _matrix[i, j];
                    if (c.Valore == null)
                        for (int k = 1; k <= Righe; k++)
                            _matrix.AssegnaNumeri(c, k);
                }
        }

        private void Semplifica()
        {
            int continua;
            do
            {
                continua = 0;
                for (int i = 0; i < Righe; i++)
                    for (int j = 0; j < Colonne; j++)
                    {
                        Cell c = _matrix[i, j];
                        if (c.NumeriPossibili == 1 && c.Valore ==  null)
                        {
                            _matrix.UnicizzaRigaColonna(c);
                            continua++;
                        }
                    }

            } while (continua > 0);
        }
        #endregion

        public int?[,] ToIntMatrix()
        {
            int?[,] mat = new int?[Righe, Colonne];

            for (int i = 0; i < Righe; i++)
                for (int j = 0; j < Colonne; j++)
                    mat[i, j] = _matrix[i, j].Valore;

            return mat;
        }

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Righe; i++)
            {
                for (int j = 0; j < Colonne; j++)
                    s += this[i, j].FormattaInStringa(Righe) + " ";
                s += "\n";
            }

            return s;
        }
    }
}
