using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class FunkcjaEksponencjalna : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "e^";

        public double ObliczWartość(double x) => Math.Exp(x);
    }
}