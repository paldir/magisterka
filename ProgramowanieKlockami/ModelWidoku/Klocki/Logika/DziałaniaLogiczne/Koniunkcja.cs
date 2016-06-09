namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne
{
    public class Koniunkcja : IDziałanieLogiczne
    {
        public string ReprezentacjaTekstowa => "i";

        public bool Wykonaj(bool a, bool b) => a && b;
    }
}