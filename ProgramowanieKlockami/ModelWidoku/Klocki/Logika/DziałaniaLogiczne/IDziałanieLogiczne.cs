namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public interface IDziałanieLogiczne
    {
        string ReprezentacjaTekstowa { get; }

        bool Wykonaj(bool a, bool b);
    }
}