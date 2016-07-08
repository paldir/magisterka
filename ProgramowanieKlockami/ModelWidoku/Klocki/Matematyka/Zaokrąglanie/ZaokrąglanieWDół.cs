using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.Zaokrąglanie
{
    public class ZaokrąglanieWDół : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Zaokrąglij w dół";

        public double Zwróć(double x) => Math.Floor(x);
    }
}