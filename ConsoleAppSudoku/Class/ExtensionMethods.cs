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
        public static void UnicizzaRigaColonna(this Cell[,] mat, Cell cell)
        {
            cell.Remove();

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (i != cell.Riga)
                    mat[cell.Riga, i].Remove(cell.Valore);

                if (i != cell.Colonna)
                    mat[i, cell.Colonna].Remove(cell.Valore);
            }
        }

        public static void AssegnaNumeri(this Cell[,] mat, Cell cell, int n)
        {
            if (ControlloAntiOrario(mat, cell, n)) // todo: aggiungere controllo nei rettangoli
                cell.Add(n);
        }

        private static bool ControlloAntiOrario(Cell[,] mat, Cell cell, int n)
        {
            int i;
            for (i = 0; i < cell.Colonna; i++)
                if (mat[cell.Riga, i].Valore == n)
                    return false;

            for (i = cell.Colonna + 1; i < mat.GetLength(0); i++)
                if (mat[cell.Riga, i].Valore == n)
                    return false;

            for (i = 0; i < cell.Riga; i++)
                if (mat[i, cell.Colonna].Valore == n)
                    return false;

            for (i = cell.Colonna + 1; i < mat.GetLength(1); i++)
                if (mat[i, cell.Colonna].Valore == n)
                    return false;

            return true;
        }
    }
}
