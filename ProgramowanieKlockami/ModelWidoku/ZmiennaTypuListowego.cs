using System.Collections.Generic;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class ZmiennaTypuListowego : List<object>
    {
        public ZmiennaTypuListowego()
        {
        }

        public ZmiennaTypuListowego(IEnumerable<object> kolekcja) : base(kolekcja)
        {
        }

        public override string ToString()
        {
            return $"[{string.Join("; ", this)}]";
        }
    }
}