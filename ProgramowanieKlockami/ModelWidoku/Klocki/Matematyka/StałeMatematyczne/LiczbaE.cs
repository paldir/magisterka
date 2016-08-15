using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class LiczbaE : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "e";
        public override double Wartość => Math.E;
    }
}