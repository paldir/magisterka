using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class LiczbaE : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "e";
        public double Wartość => Math.E;
    }
}