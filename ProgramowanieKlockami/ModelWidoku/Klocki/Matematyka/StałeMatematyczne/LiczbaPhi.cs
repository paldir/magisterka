using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class LiczbaPhi : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "φ";
        public double Wartość => (1 + Math.Sqrt(5))/2;
    }
}