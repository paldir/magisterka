using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście
{
    public class ŚredniaListy : OpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>
    {
        public override string ReprezentacjaTekstowa => "Średnia";

        public override double Zwróć(ZmiennaTypuListowego x)
        {
            double suma = 0;
            int liczbaElementów = 0;

            foreach (double liczba in x.OfType<double>())
            {
                liczbaElementów++;
                suma += liczba;
            }

            if (liczbaElementów == 0)
                liczbaElementów = 1;

            return suma/liczbaElementów;
        }
    }
}