using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class Pi : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "π";
        public double Wartość => Math.PI;
    }
}