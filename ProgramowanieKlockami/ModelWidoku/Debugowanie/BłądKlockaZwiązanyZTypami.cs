using System;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public abstract class BłądKlockaZwiązanyZTypami : BłądKlocka
    {
        public Type OczekiwanyTyp { get; protected set; }
        public Type UmieszczonyTyp { get; protected set; }

        protected static string TypNaNazwę(Type typ)
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