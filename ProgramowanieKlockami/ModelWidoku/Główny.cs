using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Inne;
using ProgramowanieKlockami.ModelWidoku.Tekst;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny
    {
        public ObservableCollection<KlocekPionowy> KlockiPionowe { get; private set; }
        public ObservableCollection<KlocekZwracającyWartość> KlockiZwracająceWartość { get; private set; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; private set; }

        public Główny()
        {
            KlockiPionowe = new ObservableCollection<KlocekPionowy>
            {
                new Wyświetl()
            };

            KlockiZwracająceWartość = new ObservableCollection<KlocekZwracającyWartość>
            {
                new Napis()
            };

            Napis napis = new Napis {WpisanaZawartość = "Hello, World!"};
            Wyświetl wyświetl = new Wyświetl {Wartość = napis};
            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            //RozpoczęcieProgramu.Następny = wyświetl;
        }
    }
}