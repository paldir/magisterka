using System.Collections.Generic;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy
{
    public class SortowanieLiczbowe : ISposóbSortowaniaListy
    {
        public string ReprezentacjaTekstowa => "liczbowo";

        public ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco)
        {
            IEnumerable<double> kolekcja = lista.OfType<double>();
            kolekcja = rosnąco ? kolekcja.OrderBy(x => x) : kolekcja.OrderByDescending(x => x);

            return new ZmiennaTypuListowego(kolekcja.Cast<object>());
        }
    }
}