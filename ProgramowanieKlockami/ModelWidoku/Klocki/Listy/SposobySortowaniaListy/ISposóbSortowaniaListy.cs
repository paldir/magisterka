using System.Collections.Generic;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SposobySortowaniaListy
{
    public interface ISposóbSortowaniaListy
    {
        string ReprezentacjaTekstowa { get; }

        List<object> Uporządkuj(List<object> lista, bool rosnąco);
    }
}