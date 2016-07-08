using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.SzukanieTekstuWTekście
{
    public class PierwszeWystąpienieTekstuWTekście : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>
    {
        public string ReprezentacjaTekstowa => "pierwsze";

        public double Zwróć(object a, object b)
        {
            return a.ToString().IndexOf(b.ToString(), StringComparison.Ordinal);
        }
    }
}