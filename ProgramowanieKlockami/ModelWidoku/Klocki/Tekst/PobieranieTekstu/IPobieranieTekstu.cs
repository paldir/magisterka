namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public interface IPobieranieTekstu
    {
        string ReprezentacjaTekstowa { get; }
        object WartośćDomyślna { get; }

        object Konwertuj(string x);
    }
}
