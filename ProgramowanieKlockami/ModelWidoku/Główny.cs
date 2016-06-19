using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeTrygonometryczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Pętle;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        private Klocek _klocekPosiadającySkupienie;
        private string _nazwaNowejZmiennej;
        private double _powiększenie;

        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>> CechyLiczby { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool>> DziałaniaLogiczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double>> DziałaniaMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> FunkcjeMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> FunkcjeTrygonometryczne { get; }
        public IEnumerable<Klocek> KlockiDotyczącePętli { get; }
        public IEnumerable<Klocek> KlockiDotycząceZmiennych { get; }
        public IEnumerable<Klocek> KlockiLogiczne { get; }
        public IEnumerable<Klocek> KlockiMatematyczne { get; }
        public IEnumerable<Klocek> KlockiTekstowe { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaPrzejęciaSkupienia { get; }
        public Komenda KomendaStartuProgramu { get; }
        public Komenda KomendaUsunięciaKlockaPionowego { get; }
        public Komenda KomendaUsunięciaKlockaZwracającegoWartość { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Komenda KomendaZwinięciaRozwinięciaKlockaZZawartością { get; }
        public Konsola Konsola { get; }
        public ObsługującyPrzeciąganieZPrzybornika ObsługującyPrzeciąganieZPrzybornika { get; }
        public ObsługującyPrzenoszenieKlockówPionowych ObsługującyPrzenoszenieKlockówPionowych { get; }
        public ObsługującyPrzenoszenieKlockówZwracającychWartość ObsługującyPrzenoszenieKlockówZwracającychWartość { get; }
        public ObsługującyUpuszczanieKlockówPionowych ObsługującyUpuszczanieKlockówPionowych { get; }
        public ObsługującyUpuszczanieKlockówZwracającychWartość ObsługującyUpuszczanieKlockówZwracającychWartość { get; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public IEnumerable<IOpcjaZwracającaWartość<bool>> StałeLogiczne { get; }
        public IEnumerable<IOpcjaZwracającaWartość<double>> StałeMatematyczne { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable>> ZnakiPorównania { get; }

        public string NazwaNowejZmiennej
        {
            get { return _nazwaNowejZmiennej; }

            set
            {
                _nazwaNowejZmiennej = value;

                OnPropertyChanged();
            }
        }

        public double Powiększenie
        {
            get { return _powiększenie; }

            set
            {
                _powiększenie = value;

                OnPropertyChanged();
            }
        }

        public Główny()
        {
            Konsola = new Konsola();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaPrzejęciaSkupienia = new Komenda(PrzejmijSkupienie);
            KomendaStartuProgramu = new Komenda(RozpocznijWykonywanieProgramu);
            KomendaUsunięciaKlockaPionowego = new Komenda(UsuńKlocekPionowy) { MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy };
            KomendaUsunięciaKlockaZwracającegoWartość = new Komenda(UsuńKlocekZwracającyWartość);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            KomendaZwinięciaRozwinięciaKlockaZZawartością = new Komenda(ZwińRozwińKlocekZZawartością) { MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy };
            ObsługującyPrzeciąganieZPrzybornika = new ObsługującyPrzeciąganieZPrzybornika();
            ObsługującyPrzenoszenieKlockówPionowych = new ObsługującyPrzenoszenieKlockówPionowych();
            ObsługującyPrzenoszenieKlockówZwracającychWartość = new ObsługującyPrzenoszenieKlockówZwracającychWartość();
            ObsługującyUpuszczanieKlockówPionowych = new ObsługującyUpuszczanieKlockówPionowych();
            ObsługującyUpuszczanieKlockówZwracającychWartość = new ObsługującyUpuszczanieKlockówZwracającychWartość();
            Powiększenie = 1;
            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();

            CechyLiczby = new IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>[]
            {
                new Parzystość(),
                new Nieparzystość(),
                new Całkowitość(),
                new Dodatniość(),
                new Ujemność()
            };

            DziałaniaLogiczne = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool>[]
            {
                new Koniunkcja(),
                new Alternatywa()
            };

            DziałaniaMatematyczne = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double>[]
            {
                new Dodawanie(),
                new Odejmowanie(),
                new Mnożenie(),
                new Dzielenie(),
                new Potęgowanie()
            };

            FunkcjeMatematyczne = new IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>[]
            {
                new PierwiastekKwadratowy(),
                new WartośćBezwzględna(),
                new WartośćOdwrotna(),
                new LogarytmNaturalny(),
                new LogarytmOPodstawie10(),
                new FunkcjaEksponencjalna(),
                new PotęgaOPodstawie10()
            };

            FunkcjeTrygonometryczne = new IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>[]
            {
                new Sinus(),
                new Cosinus(),
                new Tangens(),
                new ArcusSinus(),
                new ArcusCosinus(),
                new ArcusTangens()
            };

            StałeLogiczne = new IOpcjaZwracającaWartość<bool>[]
            {
                new Prawda(),
                new Fałsz()
            };

            StałeMatematyczne = new IOpcjaZwracającaWartość<double>[]
            {
                new Pi(),
                new LiczbaE(),
                new LiczbaPhi(),
                new PierwiastekZDwóch(),
                new PierwiastekZJednejDrugiej(),
                new Nieskończoność()
            };

            ZnakiPorównania = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable>[]
            {
                new Równy(),
                new Nierówny(),
                new Mniejszy(),
                new MniejszyRówny(),
                new Większy(),
                new WiększyRówny()
            };

            KlockiDotyczącePętli = new Klocek[]
            {
                new Dopóki(),
                new Odliczanie(),
                new PominięcieIteracji(),
                new Przerwanie()
            };

            KlockiDotycząceZmiennych = new Klocek[]
            {
                new UstawZmienną(),
                new WartośćZmiennej()
            };

            KlockiLogiczne = new Klocek[]
            {
                new Jeżeli(),
                new Negacja(),
                new Porównanie {WybranaOpcja = ZnakiPorównania.First()},
                new StałaLogiczna {WybranaOpcja = StałeLogiczne.First()},
                new WarunekZłożony {WybranaOpcja = DziałaniaLogiczne.First()}
            };

            KlockiMatematyczne = new Klocek[]
            {
                new FunkcjaMatematyczna {WybranaOpcja = FunkcjeMatematyczne.First()},
                new FunkcjaTrygonometryczna {WybranaOpcja = FunkcjeTrygonometryczne.First()},
                new PodzielnośćLiczbyPrzezLiczbę(),
                new StałaLiczbowa(),
                new StałaMatematyczna {WybranaOpcja = StałeMatematyczne.First()},
                new WynikDziałania {WybranaOpcja = DziałaniaMatematyczne.First()},
                new WystępowanieCechyLiczby {WybranaOpcja = CechyLiczby.First()},
                new ZmianaWartościZmiennejOLiczbę()
            };

            KlockiTekstowe = new Klocek[]
            {
                new Napis(),
                new Wyświetl {Konsola = Konsola}
            };
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) { Nazwa = NazwaNowejZmiennej });

                NazwaNowejZmiennej = null;
            }
        }

        private void PrzejmijSkupienie(object obiektKlocka)
        {
            if (_klocekPosiadającySkupienie != null)
                _klocekPosiadającySkupienie.PosiadaSkupienie = false;

            Klocek klocek = (Klocek)obiektKlocka;
            klocek.PosiadaSkupienie = true;
            _klocekPosiadającySkupienie = klocek;
            KomendaUsunięciaKlockaPionowego.MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy;
            KomendaZwinięciaRozwinięciaKlockaZZawartością.MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy;
        }

        private void RozpocznijWykonywanieProgramu()
        {
            Konsola.Czyść();
            RozpoczęcieProgramu.Wykonaj();
        }

        private bool SprawdźCzyMożnaUsunąćKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = _klocekPosiadającySkupienie as KlocekPionowy;

            return usuwanyKlocek?.Rodzic != null;
        }

        private bool SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy()
        {
            KlocekPionowyZZawartością klocek = _klocekPosiadającySkupienie as KlocekPionowyZZawartością;

            return klocek != null;
        }

        private void UsuńKlocekPionowy()
        {
            KlocekPionowy usuwanyKlocek = (KlocekPionowy) _klocekPosiadającySkupienie;
            ZawartośćKlockaPionowegoZZawartością miejsceUmieszczenia = usuwanyKlocek.Rodzic.Zawartość;

            miejsceUmieszczenia?.Remove(usuwanyKlocek);
        }

        private void UsuńKlocekZwracającyWartość()
        {
            KlocekZwracającyWartość usuwanyKlocek = (KlocekZwracającyWartość)_klocekPosiadającySkupienie;
            usuwanyKlocek.MiejsceUmieszczenia[0] = null;
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = (Zmienna)zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }

        private void ZwińRozwińKlocekZZawartością()
        {
            KlocekPionowyZZawartością klocek = (KlocekPionowyZZawartością)_klocekPosiadającySkupienie;
            klocek.Rozwinięty = !klocek.Rozwinięty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}