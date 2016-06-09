namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public interface IDziałanieMatematyczne
    {
        string ReprezentacjaTekstowa { get; }

        double Wykonaj(double a, double b);
    }
}