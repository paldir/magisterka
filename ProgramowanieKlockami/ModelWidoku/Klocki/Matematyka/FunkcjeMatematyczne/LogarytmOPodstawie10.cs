using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class LogarytmOPodstawie10 : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Log10";

        public double Zwróć(double x) => Math.Log10(x);
    }
}