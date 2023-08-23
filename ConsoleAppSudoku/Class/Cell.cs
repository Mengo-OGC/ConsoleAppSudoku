using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Cell
    {
        private List<int?> _valoriPossibili = new List<int?>();
        public int? Valore { get; set; }
        public int Colonna { get; set; }
        public int Riga { get; set; }

        #region metodi
        public void Add(int val)
        {
            _valoriPossibili.Add(val);
        }

        public void Remove()
        {
            Remove(_valoriPossibili[0]);
        }

        public void Remove(int? val)
        {
            if (NumeriPossibili == 1)
                Valore = _valoriPossibili[0];

            _valoriPossibili.Remove(val);
        }

        public string FormattaInStringa(int l)
        {
            string s;
            if (Valore != null)
                s = Valore.ToString();
            else
                s = string.Join("", _valoriPossibili.ToArray());

            for (int i = s.Length; i < l; i++)
                s += " ";

            return s;
        }
        #endregion

        public int NumeriPossibili
        {
            get
            {
                return _valoriPossibili.Count;
            }
        }

        #region costruttori
        public Cell(int r, int c, List<int?> val) : this(r, c)
        {
            _valoriPossibili = val;
        }
        public Cell(int r, int c, int n) : this(r, c)
        {
            Valore = n;
        }

        public Cell(int r, int c)
        {
            Riga = r;
            Colonna = c;
        }

        public Cell()
        {
            
        }
        #endregion
    }
}
