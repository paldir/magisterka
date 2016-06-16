using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class LogarytmOPodstawie10 : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "Log10";

        public double ObliczWartość(double x) => Math.Log10(x);
    }
}