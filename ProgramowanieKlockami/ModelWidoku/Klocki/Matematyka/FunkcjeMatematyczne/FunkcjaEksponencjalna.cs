using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class FunkcjaEksponencjalna : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "e^";

        public override double Zwróć(double x) => Math.Exp(x);
    }
}