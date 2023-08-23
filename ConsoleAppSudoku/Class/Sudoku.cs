using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Sudoku : Dimensioni, IEnumerable<Cell>
    {
        private Cell[,] _matrix;
        private SuperCell[,] _matrixValoriNoti;
        private int numeroCelleVerticale, numeroCelleOrrizontale;

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

        public Sudoku(int d, int dSuperCell) : this(d, d, dSuperCell, dSuperCell) { }

        public Sudoku(int r, int c, int rSC, int cSC) : base(r, c)
        {
            _matrix = new Cell[r, c];

            for (int i = 0; i < Righe; i++)
                for (int j = 0; j < Colonne; j++)
                    _matrix[i, j] = new Cell(i, j);

            _matrixValoriNoti = new SuperCell[rSC, cSC];

            for (int i = 0; i < rSC; i++)
                for (int j = 0; j < cSC; j++)
                    _matrixValoriNoti[i, j] = new SuperCell();

            numeroCelleVerticale = rSC;
            numeroCelleOrrizontale = cSC;
        }

        public Sudoku(Cell[,] mat, SuperCell[,] matSC) 
            : 
            base (mat.GetLength(0), mat.GetLength(1))
        {
            _matrix = mat;
            _matrixValoriNoti = matSC;

            numeroCelleVerticale = matSC.GetLength(0);
            numeroCelleOrrizontale = matSC.GetLength(1);
        }
        #endregion


        public void Risolvi()
        {
            Riempi();
            Semplifica();
        }

        #region metodi
        public void AggiungiNumero(int r, int c, int val)
        {
            r--;
            c--;

            this[r, c].Valore = val;

            _matrixValoriNoti
                [r / numeroCelleVerticale, c / numeroCelleOrrizontale].Add(val);
        }

        private void Riempi()
        {
            for (int i = 0; i < Righe; i++)
                for (int j = 0; j < Colonne; j++)
                {
                    Cell c = _matrix[i, j];
                    if (c.Valore == null)
                        for (int k = 1; k <= Righe; k++)
                            _matrix.AssegnaNumeri(_matrixValoriNoti[i / numeroCelleVerticale, j / numeroCelleOrrizontale], c, k);
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
