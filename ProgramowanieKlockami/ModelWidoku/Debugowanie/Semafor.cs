using System;
using System.Threading;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public class Semafor
    {
        private int _liczbaOpuszczeń;
        private int _liczbaPodniesień;
        private AutoResetEvent _semafor;

        public bool Opuszczony { get; private set; }

        public Semafor()
        {
            Resetuj();
        }

        public void Opuść()
        {
            if (_liczbaOpuszczeń != _liczbaPodniesień)
                Resetuj();

            Opuszczony = true;
            _liczbaOpuszczeń++;

            OnSemaforOpuszczony(new EventArgs());
            _semafor.WaitOne();
        }

        public void Podnieś()
        {
            if (_liczbaOpuszczeń == _liczbaPodniesień + 1)
            {
                _semafor.Set();

                Opuszczony = false;
                _liczbaPodniesień++;
            }
            else
                Resetuj();
        }


        private void Resetuj()
        {
            _semafor = new AutoResetEvent(false);
            _liczbaPodniesień = _liczbaOpuszczeń = 0;
            Opuszczony = false;
        }

        public event EventHandler SemaforOpuszczony;

        private void OnSemaforOpuszczony(EventArgs e)
        {
            SemaforOpuszczony?.Invoke(this, e);
        }
    }
}