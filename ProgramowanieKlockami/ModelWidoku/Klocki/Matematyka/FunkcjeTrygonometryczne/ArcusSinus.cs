using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeTrygonometryczne
{
    public class ArcusSinus : OpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public override string ReprezentacjaTekstowa => "Arcsin";

        public override double Zwróć(double x) => Math.Asin(x)/Math.PI*180;
    }
}