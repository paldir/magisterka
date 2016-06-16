namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class WartośćOdwrotna : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "-";

        public double ObliczWartość(double x) => -x;
    }
}