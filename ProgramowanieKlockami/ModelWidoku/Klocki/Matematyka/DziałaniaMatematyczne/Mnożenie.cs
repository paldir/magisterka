using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Mnożenie : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double, double>
    {
        public override string ReprezentacjaTekstowa => "*";

        public override double Zwróć(double a, double b) => a*b;
    }
}