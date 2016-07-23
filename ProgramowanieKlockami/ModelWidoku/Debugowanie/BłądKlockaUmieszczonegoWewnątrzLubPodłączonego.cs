using System;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public class BłądKlockaUmieszczonegoWewnątrzLubPodłączonego : BłądKlocka
    {
        public Type OczekiwanyTyp { get; set; }
        public Type UmieszczonyTyp { get; set; }

        public override string ToString()
        {
            return $"oczekiwany: {TypNaNazwę(OczekiwanyTyp)}, umieszczony: {TypNaNazwę(UmieszczonyTyp)}";
        }

        private static string TypNaNazwę(Type typ)
        {
            if (typ == null)
                return "brak";

            if (typ == typeof(ZmiennaTypuListowego))
                return "lista";

            if (typ == typeof(bool))
                return "wartość logiczna";

            if (typ == typeof(double))
                return "liczba";

            if (typ == typeof(string))
                return "napis";

            return typ == typeof(object) ? "dowolny" : "NIEOKREŚLONY";
        }
    }
}