using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class LogarytmOPodstawie10 : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "Log10";

        public override double Zwróć(double x) => Math.Log10(x);
    }
}