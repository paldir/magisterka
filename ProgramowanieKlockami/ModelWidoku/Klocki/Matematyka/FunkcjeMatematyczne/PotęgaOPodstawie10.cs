using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class PotęgaOPodstawie10 : IFunkcjaMatematyczna
    {
        public string ReprezentacjaTekstowa => "10^";

        public double ObliczWartość(double x) => Math.Pow(10, x);
    }
}