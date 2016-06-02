using System;

namespace ProgramowanieKlockami.ModelWidoku.ZnakiPorównania
{
    public interface IZnakPorównania
    {
        string ReprezentacjaTekstowa { get; }

        bool Porównaj(IComparable x, IComparable y);
    }
}