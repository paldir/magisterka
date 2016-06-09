namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Alternatywa : IDziałanieLogiczne
    {
        public string ReprezentacjaTekstowa => "lub";

        public bool Wykonaj(bool a, bool b) => a || b;
    }
}