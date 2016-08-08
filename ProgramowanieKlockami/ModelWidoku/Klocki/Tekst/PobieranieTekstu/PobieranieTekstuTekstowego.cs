namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public class PobieranieTekstuTekstowego : IPobieranieTekstu
    {
        public string ReprezentacjaTekstowa => "tekst";
        public object WartośćDomyślna => string.Empty;

        public object Konwertuj(string x)
        {
            return string.IsNullOrEmpty(x) ? string.Empty : x;
        }
    }
}