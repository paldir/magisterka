using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Potęgowanie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double>
    {
        public string ReprezentacjaTekstowa => "^";

        public double Zwróć(double a, double b) => Math.Pow(a, b);
    }
}