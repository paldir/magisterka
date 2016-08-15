using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Modulo : OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double, double>
    {
        public override string ReprezentacjaTekstowa => "modulo";

        public override double Zwróć(double a, double b) => a%b;
    }
}