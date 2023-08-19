using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using ConsoleAppSudoku.Class;

namespace ConsoleAppSudoku
{
    public class Program
    {
        #region Messaggi

        const string CHIUSURA = "Premere qualsiasi tasto per chiudere . . .",
                     DIMENSIONI = "Inserire la dimensione del tabellone: ",
                     TITOLO = "*** SUDOKU - SUDOKU - SUDOKU ***",
                     NUMERO = "Inserire il numero: ",
                     COLONNA = "Inserire la colonna: ",
                     RIGA = "Inserire la riga: ",
                     ERRORE_NUMERO = "Numero non idoneo, riprova!!!",
                     ERRORE_COLONNA = "Colonna non idonea, riprova!!!",
                     ERRORE_RIGA = "Riga non idonea, riprova!!!",
                     ERRORE_DIMENSIONI = "Dimensioni non idone, riprova!!!";

        #endregion
        private static int Conversione(string mess, string err, int d = 9)
        {
            int n;
            while (true)
            {
                Write(mess);
                if (int.TryParse(ReadLine(), out n) && n - 1 >= 0 && n - 1 < d)
                    return n;
                else 
                    WriteLine(mess);
            }
        }

        static void Main(string[] args)
        {
            Title = TITOLO;

            // DIMENSIONI
            /*
            //dimensioni sodoku
            int d = 0;
            bool ok = true;
            do
            {
                Write(DIMENSIONI);
                if (int.TryParse(ReadLine(), out d) && d > 0)
                    ok = false;
                else
                    Write(ERRORE_DIMENSIONI);
            } while (ok);

            Sudoku sudoku = new Sudoku(d);
            */

            Sudoku sudoku = new Sudoku();

            //dimensioni sodoku
            /*
            int n = 0;
            do
            {
                Write("Numero celle note: ");
                if (int.TryParse(ReadLine(), out n) && n > 0)
                    ok = false;
                else
                    WriteLine("Numero non idone, riprova!!!");
            } while (ok);

            // valori noti
            for (int i = 0; i < n; i++)
            {
                int num = Conversione(NUMERO, ERRORE_NUMERO);
                int r = Conversione(RIGA, ERRORE_RIGA);
                int c = Conversione(COLONNA, ERRORE_COLONNA);
                
                sudoku[r - 1, c - 1].Valore = num;
            }
            */

            // todo: togliere, solo per test:
            sudoku[0, 0].Valore = 1;
            sudoku[0, 2].Valore = 2;
            sudoku[1, 2].Valore = 3;
            sudoku[2, 8].Valore = 4;
            sudoku[3, 1].Valore = 4;
            sudoku[3, 4].Valore = 5;
            sudoku[4, 1].Valore = 6;
            sudoku[4, 4].Valore = 7;
            sudoku[5, 7].Valore = 2;
            sudoku[6, 1].Valore = 8;
            sudoku[8, 6].Valore = 8;

            DateTime inizio = DateTime.Now;
            sudoku.Risolvi();
            DateTime fine = DateTime.Now;

            WriteLine("Tempo esecuzione: " + (fine - inizio).ToString());
            Write(sudoku.ToString());

            // chiusura
            Write(CHIUSURA);
            ReadKey(true);
        }
    }
}
