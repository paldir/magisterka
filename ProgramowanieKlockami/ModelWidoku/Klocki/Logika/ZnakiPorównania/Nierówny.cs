using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public class Nierówny : IZnakPorównania
    {
        public string ReprezentacjaTekstowa => "!=";

        public bool Porównaj(IComparable x, IComparable y) => x.CompareTo(y) != 0;
    }
}