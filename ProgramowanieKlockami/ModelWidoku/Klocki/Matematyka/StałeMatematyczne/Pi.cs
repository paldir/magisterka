using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class Pi : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "π";
        public override double Wartość => Math.PI;
    }
}