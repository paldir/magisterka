using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.Zaokrąglanie
{
    public class ZaokrąglanieWGórę : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "Zaokrąglij w górę";

        public override double Zwróć(double x) => Math.Ceiling(x);
    }
}