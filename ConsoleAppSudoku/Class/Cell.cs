using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class Cell : Cordinate
    {
        private List<int?> _valoriPossibili = new List<int?>();

        public int? Valore { get; set; }

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

        public  int NumeriPossibili
        {
            get
            {
                return _valoriPossibili.Count;
            }
        }

        public Cell(int r, int c) :base(r, c) { }
        
        public Cell(int r, int c, List<int?> val) : this(r, c)
        {
            _valoriPossibili = val;
        }

        public Cell(int r, int c, int n) : this(r, c)
        {
            Valore = n;
        }

        public Cell()
        {
            
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
    }
}
