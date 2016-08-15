using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeTrygonometryczne
{
    public class Sinus : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "Sin";

        public override double Zwróć(double x) => Math.Sin(x/180*Math.PI);
    }
}