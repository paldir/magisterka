using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public class Semafor
    {
        private readonly AutoResetEvent _semafor;
        private bool _opuszczony;

        public bool Opuszczony
        {
            get { return _opuszczony; }

            private set { _opuszczony = value; }
        }

        public Semafor()
        {
            _semafor = new AutoResetEvent(false);
        }

        public void Opuść()
        {
            Opuszczony = true;

            OnSemaforOpuszczony(new EventArgs());
            _semafor.WaitOne();
        }

        public void Podnieś()
        {
            if (!_semafor.WaitOne(0))
                _semafor.Set();

            Opuszczony = false;
        }

        public event EventHandler SemaforOpuszczony;

        private void OnSemaforOpuszczony(EventArgs e)
        {
            SemaforOpuszczony?.Invoke(this, e);
        }
    }
}