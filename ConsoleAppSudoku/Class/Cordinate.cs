using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Cordinate
    {
        public int Colonna { get; set; }
        public int Riga { get; set; }

        public Cordinate(int r, int c)
        {
            Colonna = c;
            Riga = r;
        }

        public Cordinate()
        {
            
        }
    }
}
