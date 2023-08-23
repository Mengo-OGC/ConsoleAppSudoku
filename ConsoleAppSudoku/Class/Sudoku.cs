using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Sudoku
    {
        private SuperCell[,] _matrix;

        #region proprietà
        private int NumeroCelle { get; set; }
        private int NumeroSuperCelle { get; set; }

        public SuperCell this[int r, int c]
        {
            get
            {
                if(_matrix.ControlloDimensioni(r, c))
                    return _matrix[r, c];
                return null;
            }
            set
            {
                if (_matrix.ControlloDimensioni(r, c))
                    _matrix[r, c] = value;
            }
        }
        #endregion

        #region costruttori
        public Sudoku() : this (3) { }

        public Sudoku(int d)
        {
            NumeroCelle = d * d;
            NumeroSuperCelle = d;

            _matrix = new SuperCell[d, d];

            for (int i = 0; i < d; i++)
                for (int j = 0; j < d; j++)
                    _matrix[i, j] = new SuperCell(d);

            int riga, colonna;
            for (int R = 0; R < d; R++)
                for (int C = 0; C < d; C++)
                    for (int r = 0; r < d; r++)
                        for (int c = 0; c < d; c++)
                        {
                            riga = R * d + r;
                            colonna = C * d + c;
                            _matrix[R, C][r, c] = new Cell(riga, colonna);
                        }
        }
        #endregion

        public void Risolvi()
        {
            Riempi();
            //Semplifica();
        }

        #region metodi
        public void AggiungiNumero(int r, int c, int val)
        {
            r--;
            c--;

            this[r / NumeroSuperCelle, c / NumeroSuperCelle][r % NumeroSuperCelle, c % NumeroSuperCelle].Valore = val;
        }

        private void Riempi()
        {
            for (int i = 0; i < NumeroCelle; i++)
                for (int j = 0; j < NumeroCelle; j++)
                {
                    Cell c = _matrix.OttieniCellaNonProtetta(i, j);
                    if (c.Valore == null)
                        for (int k = 1; k <= NumeroCelle; k++)
                            _matrix.AssegnaNumeri(c, k);
                }
        }

        private void Semplifica()
        {
            int continua;
            do
            {
                continua = 0;
                for (int i = 0; i < NumeroCelle; i++)
                    for (int j = 0; j < NumeroCelle; j++)
                    {
                        Cell c = _matrix.OttieniCellaNonProtetta(i, j);
                        if (c.NumeriPossibili == 1 && c.Valore ==  null)
                        {
                            _matrix.UnicizzaRigaColonna(c);
                            continua++;
                        }
                    }

            } while (continua > 0);
        }
        #endregion

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < NumeroCelle; i++)
            {
                for (int j = 0; j < NumeroCelle; j++)
                    s += _matrix.OttieniCellaNonProtetta(i, j).FormattaInStringa(NumeroCelle) + " ";
                s += "\n";
            }

            return s;
        }
    }
}
