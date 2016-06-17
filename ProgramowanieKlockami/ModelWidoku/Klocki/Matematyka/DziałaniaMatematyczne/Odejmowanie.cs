using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Odejmowanie : IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double>
    {
        public string ReprezentacjaTekstowa => "-";

        public double Zwróć(double a, double b) => a - b;
    }
}