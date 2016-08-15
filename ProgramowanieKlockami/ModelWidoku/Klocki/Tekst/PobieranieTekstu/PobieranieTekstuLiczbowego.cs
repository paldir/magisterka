namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public class PobieranieTekstuLiczbowego : PobieranieTekstu
    {
        public override string ReprezentacjaTekstowa => "liczbę";
        public override object WartośćDomyślna => 0.0;

        public override object Konwertuj(string x)
        {
            double liczba;

            double.TryParse(x, out liczba);

            return liczba;
        }
    }
}