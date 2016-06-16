using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class LogarytmNaturalny : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "Ln";

        public double ObliczWartość(double x) => Math.Log(x);
    }
}