using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.Zaokrąglanie
{
    public class ZaokrąglanieWGórę : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Zaokrąglij w górę";

        public double Zwróć(double x) => Math.Ceiling(x);
    }
}