﻿using System;
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
            sudoku.AggiungiNumero(1, 1, 5);
            sudoku.AggiungiNumero(1, 2, 3);
            sudoku.AggiungiNumero(1, 5, 7);
            sudoku.AggiungiNumero(2, 1, 6);
            sudoku.AggiungiNumero(2, 4, 1);
            sudoku.AggiungiNumero(2, 5, 9);
            sudoku.AggiungiNumero(2, 6, 5);
            sudoku.AggiungiNumero(3, 2, 9);
            sudoku.AggiungiNumero(3, 3,8 );
            sudoku.AggiungiNumero(3, 8, 6);
            sudoku.AggiungiNumero(4, 1,8 );
            sudoku.AggiungiNumero(4, 5,6 );
            sudoku.AggiungiNumero(4, 9,3 );
            sudoku.AggiungiNumero(5,1 ,4 );
            sudoku.AggiungiNumero(5, 4,8 );
            sudoku.AggiungiNumero(5, 6,3 );
            sudoku.AggiungiNumero(5, 9,1 );
            sudoku.AggiungiNumero(6, 1,7 );
            sudoku.AggiungiNumero(6, 5,2 );
            sudoku.AggiungiNumero(6, 9,6 );
            sudoku.AggiungiNumero(7, 2, 6);
            sudoku.AggiungiNumero(7, 7,2 );
            sudoku.AggiungiNumero(7, 8,8 );
            sudoku.AggiungiNumero(8, 4, 4);
            sudoku.AggiungiNumero(8, 5,1 );
            sudoku.AggiungiNumero(8, 6, 9);
            sudoku.AggiungiNumero(8, 9,5 );
            sudoku.AggiungiNumero(9,5 ,8 );
            sudoku.AggiungiNumero(9, 8, 7);
            sudoku.AggiungiNumero(9, 9, 9);

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
