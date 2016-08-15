using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.SzukanieTekstuWTekście
{
    public class OstatnieWystąpienieTekstuWTekście : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>
    {
        public override string ReprezentacjaTekstowa => "ostatnie";

        public override double Zwróć(object a, object b)
        {
            return a.ToString().LastIndexOf(b.ToString(), StringComparison.Ordinal);
        }
    }
}