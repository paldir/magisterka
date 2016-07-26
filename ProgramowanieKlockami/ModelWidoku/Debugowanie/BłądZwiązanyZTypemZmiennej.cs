using System;

namespace ProgramowanieKlockami.ModelWidoku.Debugowanie
{
    public class BłądZwiązanyZTypemZmiennej : BłądKlockaZwiązanyZTypami
    {
        public BłądZwiązanyZTypemZmiennej(Type oczekiwanyTyp, Type umieszczonyTyp) : base(oczekiwanyTyp, umieszczonyTyp)
        {
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}