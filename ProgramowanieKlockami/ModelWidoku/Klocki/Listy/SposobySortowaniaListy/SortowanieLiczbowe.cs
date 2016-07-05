using System.Collections.Generic;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SposobySortowaniaListy
{
    public class SortowanieLiczbowe : ISposóbSortowaniaListy
    {
        public string ReprezentacjaTekstowa => "liczbowo";

        public List<object> Uporządkuj(List<object> lista, bool rosnąco)
        {
            IEnumerable<double> kolekcja = lista.OfType<double>();
            kolekcja = rosnąco ? kolekcja.OrderBy(x => x) : kolekcja.OrderByDescending(x => x);

            return kolekcja.Cast<object>().ToList();
        }
    }
}