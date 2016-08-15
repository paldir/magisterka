using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class PierwiastekZJednejDrugiej : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "Pierwiastek z 0.5";
        public override double Wartość => Math.Sqrt(0.5);
    }
}