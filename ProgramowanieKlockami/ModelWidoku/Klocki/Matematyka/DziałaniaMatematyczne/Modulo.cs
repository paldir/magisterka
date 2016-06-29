using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Modulo : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double, double>
    {
        public string ReprezentacjaTekstowa => "modulo";

        public double Zwróć(double a, double b) => a%b;
    }
}