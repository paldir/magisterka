using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class WartośćBezwzględna : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "Wartość bezwzględna z";

        public double ObliczWartość(double x) => Math.Abs(x);
    }
}