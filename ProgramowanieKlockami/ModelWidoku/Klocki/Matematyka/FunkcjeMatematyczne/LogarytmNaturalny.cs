using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class LogarytmNaturalny : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Ln";

        public double Zwróć(double x) => Math.Log(x);
    }
}