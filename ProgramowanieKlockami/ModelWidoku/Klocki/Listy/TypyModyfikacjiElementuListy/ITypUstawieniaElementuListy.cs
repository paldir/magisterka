using System.Collections.Generic;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.TypyModyfikacjiElementuListy
{
    public interface ITypUstawieniaElementuListy
    {
        string ReprezentacjaTekstowa { get; }

        void ModyfikujListę(List<object> lista, int indeks, object wartość);
    }
}