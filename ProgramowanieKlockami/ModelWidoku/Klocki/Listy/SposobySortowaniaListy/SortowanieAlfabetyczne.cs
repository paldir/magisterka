using System.Collections.Generic;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SposobySortowaniaListy
{
    public class SortowanieAlfabetyczne : ISposóbSortowaniaListy
    {
        public string ReprezentacjaTekstowa => "alfabetycznie";

        public ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco)
        {
            IEnumerable<string> kolekcja = lista.Select(x => x.ToString());
            kolekcja = rosnąco ? kolekcja.OrderBy(x => x) : kolekcja.OrderByDescending(x => x);

            return new ZmiennaTypuListowego(kolekcja);
        }
    }
}