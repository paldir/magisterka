using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Mnożenie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double>
    {
        public string ReprezentacjaTekstowa => "*";

        public double Zwróć(double a, double b) => a*b;
    }
}