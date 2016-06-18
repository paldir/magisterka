using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne
{
    public class Nieskończoność : IOpcjaZwracającaWartość<double>
    {
        public string ReprezentacjaTekstowa => "∞";
        public double Wartość => double.PositiveInfinity;
    }
}