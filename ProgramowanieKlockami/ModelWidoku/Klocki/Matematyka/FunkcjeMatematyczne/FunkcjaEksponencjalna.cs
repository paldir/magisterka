using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class FunkcjaEksponencjalna : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "e^";

        public double Zwróć(double x) => Math.Exp(x);
    }
}