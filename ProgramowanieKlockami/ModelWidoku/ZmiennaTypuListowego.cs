using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class ZmiennaTypuListowego : ObservableCollection<object>
    {
        public ZmiennaTypuListowego()
        {
        }

        public ZmiennaTypuListowego(IEnumerable<object> kolekcja) : base(kolekcja)
        {
        }

        public override string ToString() => $"[{string.Join("; ", this)}]";
    }
}