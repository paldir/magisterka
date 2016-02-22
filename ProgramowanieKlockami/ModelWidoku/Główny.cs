using System;
using System.Collections.Generic;
using System.Linq;
using ProgramowanieKlockami.ModelWidoku.Inne;
using ProgramowanieKlockami.ModelWidoku.Tekst;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny
    {
        public KlocekPionowy[] KlockiPionowe { get; private set; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; private set; }

        public Główny()
        {
            Napis napis = new Napis() {WpisanaZawartość = "Hello, World!"};
            Wyświetl wyświetl = new Wyświetl {Wartość = napis};
            RozpoczęcieProgramu = new RozpoczęcieProgramu {Następny = wyświetl};

            Type typKlockaPionowego = typeof (KlocekPionowy);
            IEnumerable<Type> wszystkieTypy = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes());
            var tmp = wszystkieTypy.Where(t => typKlockaPionowego.IsAssignableFrom(t) && !t.IsAbstract);
        }
    }
}