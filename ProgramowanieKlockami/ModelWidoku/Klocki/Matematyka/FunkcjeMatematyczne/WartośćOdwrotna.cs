using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class WartośćOdwrotna : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "-";

        public double Zwróć(double x) => -x;
    }
}