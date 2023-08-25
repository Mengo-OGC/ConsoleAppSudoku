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

            Sudoku sudoku = new Sudoku();

            /*
            int n = 0;
            bool ok = true;
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
                
                sudoku.AggiungiNumero(r, c, num);
            }
            */

            // test
            sudoku.AggiungiNumero(1, 4, 7);
            sudoku.AggiungiNumero(1, 5, 1);
            sudoku.AggiungiNumero(2, 2, 2);
            sudoku.AggiungiNumero(2, 6, 3);
            sudoku.AggiungiNumero(3, 2, 9);
            sudoku.AggiungiNumero(3, 4, 5);
            sudoku.AggiungiNumero(3, 6, 2);
            sudoku.AggiungiNumero(3, 8, 7);
            sudoku.AggiungiNumero(3, 9, 3);
            sudoku.AggiungiNumero(4, 8, 6);
            sudoku.AggiungiNumero(5, 1, 6);
            sudoku.AggiungiNumero(5, 2, 8);
            sudoku.AggiungiNumero(5, 5, 5);
            sudoku.AggiungiNumero(5, 6, 9);
            sudoku.AggiungiNumero(6, 1, 2);
            sudoku.AggiungiNumero(6, 2, 5);
            sudoku.AggiungiNumero(6, 3, 4);
            sudoku.AggiungiNumero(6, 5, 3);
            sudoku.AggiungiNumero(6, 6, 6);
            sudoku.AggiungiNumero(6, 7, 1);
            sudoku.AggiungiNumero(7, 2, 3);
            sudoku.AggiungiNumero(7, 6, 7);
            sudoku.AggiungiNumero(7, 9, 9);
            sudoku.AggiungiNumero(8, 1, 1);
            sudoku.AggiungiNumero(8, 2, 6);
            sudoku.AggiungiNumero(8, 6, 5);
            sudoku.AggiungiNumero(9, 1, 4);
            sudoku.AggiungiNumero(9, 2, 7);
            sudoku.AggiungiNumero(9, 7, 6);
            sudoku.AggiungiNumero(9, 8, 8);

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
