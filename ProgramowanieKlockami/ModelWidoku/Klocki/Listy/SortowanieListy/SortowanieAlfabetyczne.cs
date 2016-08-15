using System.Collections.Generic;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy
{
    public class SortowanieAlfabetyczne : SposóbSortowaniaListy
    {
        public override string ReprezentacjaTekstowa => "alfabetycznie";

        public override ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco)
        {
            IEnumerable<string> kolekcja = lista.Select(x => x.ToString());
            kolekcja = rosnąco ? kolekcja.OrderBy(x => x) : kolekcja.OrderByDescending(x => x);

            return new ZmiennaTypuListowego(kolekcja);
        }
    }
}