using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class PierwiastekZDwóch : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "Pierwiastek z 2";
        public double Wartość => Math.Sqrt(2);
    }
}