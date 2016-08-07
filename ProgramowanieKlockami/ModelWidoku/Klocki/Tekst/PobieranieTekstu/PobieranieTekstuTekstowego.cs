namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public class PobieranieTekstuTekstowego : IPobieranieTekstu
    {
        public string ReprezentacjaTekstowa => "tekst";
        public object WartośćDomyślna => string.Empty;

        public object Konwertuj(string x) => x;
    }
}