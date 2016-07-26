using System;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public class BłądKlockaUmieszczonegoWewnątrzLubPodłączonego : BłądKlockaZwiązanyZTypami
    {
        public BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(Type oczekiwanyTyp, Type umieszczonyTyp) : base(oczekiwanyTyp, umieszczonyTyp)
        {
        }

        public override string ToString()
        {
            return $"Umieszczony wewnątrz lub podłączony klocek zwraca wartość nieprawidłowego typu. Oczekiwany typ: {TypNaNazwę(OczekiwanyTyp)}, typ wartości zwracanej: {TypNaNazwę(UmieszczonyTyp)}";
        }
    }
}