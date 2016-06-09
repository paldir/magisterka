using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne
{
    public class Potęgowanie : IDziałanieMatematyczne
    {
        public string ReprezentacjaTekstowa => "^";

        public double Wykonaj(double a, double b) => Math.Pow(a, b);
    }
}