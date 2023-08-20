using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class SuperCell : IEnumerable<int>
    {
        private List<int> _matrixNota;

        public void Add(int v)
        {
            _matrixNota.Add(v);
        }

        public void Remove(int v)
        {
            _matrixNota.Remove(v);
        }

        public int this[int i]
        {
            get
            {
                Controllo(i);
                return _matrixNota[i];
            }
            set
            {
                Controllo(i);
                _matrixNota[i] = value;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int v in _matrixNota)
                yield return v;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Controllo(int i)
        {
            if (i < 0
                    ||
                    i >= _matrixNota.Count)
                throw new Exception("Error");
        }

        public SuperCell()
        {
            _matrixNota = new List<int>();
        }

        public SuperCell(List<int> mat)
        {
            _matrixNota = mat;
        }

    }
}
