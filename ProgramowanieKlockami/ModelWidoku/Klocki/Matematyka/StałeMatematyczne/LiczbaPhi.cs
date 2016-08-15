using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class LiczbaPhi : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "φ";
        public override double Wartość => (1 + Math.Sqrt(5))/2;
    }
}