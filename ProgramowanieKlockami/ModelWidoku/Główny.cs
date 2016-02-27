using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Inne;
using ProgramowanieKlockami.ModelWidoku.Tekst;
using ProgramowanieKlockami.ModelWidoku.Zmienne;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny
    {
        public ObservableCollection<KlocekPionowy> KlockiPionowe { get; private set; }
        public ObservableCollection<KlocekZwracającyWartość> KlockiZwracająceWartość { get; private set; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; private set; }
        public ObservableCollection<string> Zmienne { get; private set; }

        public Główny()
        {
            KlockiPionowe = new ObservableCollection<KlocekPionowy>
            {
                new Wyświetl(),
                new UstawZmienną()
            };

            KlockiZwracająceWartość = new ObservableCollection<KlocekZwracającyWartość>
            {
                new Napis()
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            RozpoczęcieProgramu.Następny = new UstawZmienną();
            Zmienne = new ObservableCollection<string> {"Zmienna"};
        }
    }
}