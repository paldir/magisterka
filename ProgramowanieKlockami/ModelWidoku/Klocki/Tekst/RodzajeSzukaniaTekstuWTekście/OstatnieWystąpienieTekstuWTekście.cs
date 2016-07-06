using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.RodzajeSzukaniaTekstuWTekście
{
    public class OstatnieWystąpienieTekstuWTekście : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>
    {
        public string ReprezentacjaTekstowa => "ostatnie";

        public double Zwróć(object a, object b)
        {
            return a.ToString().LastIndexOf(b.ToString(), StringComparison.Ordinal);
        }
    }
}