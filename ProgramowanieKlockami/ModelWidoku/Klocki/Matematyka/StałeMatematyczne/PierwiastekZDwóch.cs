using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class PierwiastekZDwóch : OpcjaZwracającaWartość<double>
    {
        public override string ReprezentacjaTekstowa => "Pierwiastek z 2";
        public override double Wartość => Math.Sqrt(2);
    }
}