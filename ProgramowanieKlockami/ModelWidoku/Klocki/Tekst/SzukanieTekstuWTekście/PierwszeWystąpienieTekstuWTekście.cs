using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.SzukanieTekstuWTekście
{
    public class PierwszeWystąpienieTekstuWTekście : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>
    {
        public override string ReprezentacjaTekstowa => "pierwsze";

        public override double Zwróć(object a, object b)
        {
            return a.ToString().IndexOf(b.ToString(), StringComparison.Ordinal);
        }
    }
}