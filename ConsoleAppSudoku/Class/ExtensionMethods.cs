using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public static class ExtensionMethods
    {
        public static void UnicizzaRigaColonna(this SuperCell[,] mat, Cell cell)
        {
            cell.Remove();

            for (int i = 0; i < Math.Pow(mat.GetLength(0), 2); i++)
            {
                if (i != cell.Riga)
                    mat.OttieniCellaNonProtetta(cell.Riga, i).Remove(cell.Valore);

                if (i != cell.Colonna)
                    mat.OttieniCellaNonProtetta(i, cell.Colonna).Remove(cell.Valore);
            }
        }

        public static void AssegnaNumeri(this SuperCell[,] mat, Cell cell, int n)
        {
            int riga = cell.Riga / mat.GetLength(0);
            int colonna = cell.Colonna / mat.GetLength(1);

            if (ControlloAntiOrario(mat, cell, n) && mat[riga, colonna].Contains(n))
                cell.Add(n);
        }

        private static bool ControlloAntiOrario(SuperCell[,] mat, Cell cell, int n)
        {
            int i;

            for (i = 0; i < cell.Colonna; i++)
                if (mat.OttieniCellaNonProtetta(cell.Riga, i).Valore == n)
                    return false;

            for (i = cell.Colonna + 1; i < mat.GetLength(0); i++)
                if (mat.OttieniCellaNonProtetta(cell.Riga, i).Valore == n)
                    return false;

            for (i = 0; i < cell.Riga; i++)
                if (mat.OttieniCellaNonProtetta(i, cell.Colonna).Valore == n)
                    return false;

            for (i = cell.Colonna + 1; i < mat.GetLength(1); i++)
                if (mat.OttieniCellaNonProtetta(i, cell.Colonna).Valore == n)
                    return false;

            return true;
        }

        #region piccoli
        public static bool Contains(this SuperCell mat, int v)
        {
            foreach(Cell c in mat)
                if (c.Valore == v) return true;
            return false;
        }

        public static bool ControlloDimensioni(this Cell[,] mat, int r, int c)
        {
            return Controllo(r, c, mat.GetLength(0), mat.GetLength(1));
        }

        public static bool ControlloDimensioni(this SuperCell[,] mat, int r, int c)
        {
            return Controllo(r, c, mat.GetLength(0), mat.GetLength(1));
        }

        private static bool Controllo(int riga, int colonna, int righe, int colonne)
        {
            if (riga < 0
                    ||
                    riga >= righe
                    ||
                    colonna < 0
                    ||
                    colonna >= colonne)
                return false;
            return true;
        }

        public static Cell OttieniCellaNonProtetta(this SuperCell[,] mat, int r, int c)
        {
            int n = mat.GetLength(0);
            return mat[r / n, c / n][r % n, c % n];
        }
        #endregion
    }
}
