using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.Zaokrąglanie
{
    public class ZaokrąglanieWDół : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "Zaokrąglij w dół";

        public override double Zwróć(double x) => Math.Floor(x);
    }
}