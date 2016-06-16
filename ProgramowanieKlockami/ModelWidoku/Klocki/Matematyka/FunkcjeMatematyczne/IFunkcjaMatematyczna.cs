namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public interface IFunkcjaMatematyczna
    {
        string ReprezentacjaTekstowa { get; }

        double ObliczWartość(double x);
    }
}