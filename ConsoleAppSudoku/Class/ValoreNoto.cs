using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class ValoreNoto : Cordinate
    {
        public int? Valore { get; set; }

        public ValoreNoto(int i, int j, int n) : this(i, j)
        {
            Valore = n;
        }

        public ValoreNoto(int i, int j) : base(i, j)
        {
            
        }

        public ValoreNoto()
        {
            
        }
    }
}
