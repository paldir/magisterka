namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public class PobieranieTekstuTekstowego : PobieranieTekstu
    {
        public override string ReprezentacjaTekstowa => "tekst";
        public override object WartośćDomyślna => string.Empty;

        public override object Konwertuj(string x)
        {
            return string.IsNullOrEmpty(x) ? string.Empty : x;
        }
    }
}