using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania
{
    public interface IZnakPorównania
    {
        string ReprezentacjaTekstowa { get; }

        bool Porównaj(IComparable x, IComparable y);
    }
}