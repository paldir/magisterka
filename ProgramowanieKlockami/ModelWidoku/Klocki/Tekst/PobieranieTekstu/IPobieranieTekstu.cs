namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public interface IPobieranieTekstu
    {
        string ReprezentacjaTekstowa { get; }

        object Konwertuj(string x);
    }
}
