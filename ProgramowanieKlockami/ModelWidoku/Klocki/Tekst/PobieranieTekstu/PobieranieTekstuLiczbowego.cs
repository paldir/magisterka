namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public class PobieranieTekstuLiczbowego : IPobieranieTekstu
    {
        public string ReprezentacjaTekstowa => "liczbę";
        public object WartośćDomyślna => 0.0;

        public object Konwertuj(string x)
        {
            double liczba;

            double.TryParse(x, out liczba);

            return liczba;
        }
    }
}