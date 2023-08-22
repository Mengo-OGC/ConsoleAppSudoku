using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSudoku.Class
{
    public class SuperCell
    {
        private List<int> _matrixNota;

        #region metodi
        public void Add(int v)
        {
            _matrixNota.Add(v);
        }

        public void Remove(int v)
        {
            _matrixNota.Remove(v);
        }

        public bool ValorePresente(int v)
        {
            if (_matrixNota.Contains(v))
            {
                return true;
            }
            return false;
        }

        private void Controllo(int i)
        {
            if (i < 0 || i >= _matrixNota.Count)
                throw new Exception("Error");
        }
        #endregion

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
