using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class PierwiastekKwadratowy : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "Pierwiastek kwadratowy z";

        public double ObliczWartość(double x) => Math.Sqrt(x);
    }
}