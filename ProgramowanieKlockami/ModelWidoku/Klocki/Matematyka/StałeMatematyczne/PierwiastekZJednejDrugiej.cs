using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class PierwiastekZJednejDrugiej : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "Pierwiastek z 0.5";
        public double Wartość => Math.Sqrt(0.5);
    }
}