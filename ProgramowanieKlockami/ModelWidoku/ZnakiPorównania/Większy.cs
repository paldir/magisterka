using System;

namespace ProgramowanieKlockami.ModelWidoku.ZnakiPorównania
{
    public class Większy : IZnakPorównania
    {
        public string ReprezentacjaTekstowa => ">";

        public bool Porównaj(IComparable x, IComparable y)
        {
            return x.CompareTo(y) > 0;
        }
    }
}