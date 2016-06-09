namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Dodawanie : IDziałanieMatematyczne
    {
        public string ReprezentacjaTekstowa => "+";

        public double Wykonaj(double a, double b) => a + b;
    }
}