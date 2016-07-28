using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class StanAplikacji
    {
        public RozpoczęcieProgramu Kod { get; }

        public StanAplikacji(ICloneable aktualnyStan)
        {
            Kod = (RozpoczęcieProgramu) aktualnyStan.Clone();
        }
    }
}