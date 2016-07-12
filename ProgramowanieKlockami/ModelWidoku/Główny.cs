using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.PorządkiSortowaniaListy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.WystąpieniaElementuNaLiście;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.DziałaniaLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.CechyLiczby;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczneNaLiście;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeTrygonometryczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.StałeMatematyczne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.Zaokrąglanie;
using ProgramowanieKlockami.ModelWidoku.Klocki.Pętle;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.ObcinanieSpacji;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.SzukanieTekstuWTekście;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.WielkościLiter;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;
using ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        private bool _debugowanie;
        private Klocek _klocekPosiadającySkupienie;
        private string _nazwaNowejZmiennej;
        private double _powiększenie;
        private readonly AutoResetEvent _semafor;
        private Thread _wątekDebugowania;

        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<bool, double>> CechyLiczby { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool, bool>> DziałaniaLogiczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double, double>> DziałaniaMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>> DziałaniaMatematyczneNaLiście { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> FunkcjeMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> FunkcjeTrygonometryczne { get; }
        public IEnumerable<Klocek> KlockiDotycząceList { get; }
        public IEnumerable<Klocek> KlockiDotyczącePętli { get; }
        public IEnumerable<Klocek> KlockiDotycząceZmiennych { get; }
        public IEnumerable<Klocek> KlockiLogiczne { get; }
        public IEnumerable<Klocek> KlockiMatematyczne { get; }
        public IEnumerable<Klocek> KlockiTekstowe { get; }
        public Komenda KomendaDodaniaUsunięciaPunktuPrzerwania { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaKontynuacjiWykonywania { get; }
        public Komenda KomendaPrzejęciaSkupienia { get; }
        public Komenda KomendaStartuProgramu { get; }
        public Komenda KomendaUsunięciaKlockaPionowego { get; }
        public Komenda KomendaUsunięciaKlockaZwracającegoWartość { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Komenda KomendaZamknięciaOkna { get; }
        public Komenda KomendaZwinięciaRozwinięciaKlockaZZawartością { get; }
        public Konsola Konsola { get; }
        public IEnumerable<ITypUstawieniaElementuListy> ModyfikacjeElementuListy { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>> ObcinaniaSpacji { get; }
        public ObsługującyPrzeciąganieZPrzybornika ObsługującyPrzeciąganieZPrzybornika { get; }
        public ObsługującyPrzenoszenieKlockówPionowych ObsługującyPrzenoszenieKlockówPionowych { get; }
        public ObsługującyPrzenoszenieKlockówZwracającychWartość ObsługującyPrzenoszenieKlockówZwracającychWartość { get; }
        public ObsługującyUpuszczanieKlockówPionowych ObsługującyUpuszczanieKlockówPionowych { get; }
        public ObsługującyUpuszczanieKlockówZwracającychWartość ObsługującyUpuszczanieKlockówZwracającychWartość { get; }
        public IEnumerable<IPobieranieTekstu> PobieraniaTekstu { get; }
        public IEnumerable<IPorządekSortowania> PorządkiSortowania { get; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public IEnumerable<ISposóbSortowaniaListy> SortowaniaListy { get; }
        public IEnumerable<IOpcjaZwracającaWartość<bool>> StałeLogiczne { get; }
        public IEnumerable<IOpcjaZwracającaWartość<double>> StałeMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>> SzukaniaTekstuWTekście { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>> WielkościLiter { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>> WystąpieniaElementuNaLiście { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> ZaokrąglaniaLiczby { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable, IComparable>> ZnakiPorównania { get; }

        public bool Debugowanie
        {
            get { return _debugowanie; }

            private set
            {
                _debugowanie = value;

                OnPropertyChanged();
            }
        }

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
            _semafor = new AutoResetEvent(false);
            Konsola = new Konsola();
            KomendaDodaniaUsunięciaPunktuPrzerwania = new Komenda(DodajUsuńPunktPrzerwania);
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaKontynuacjiWykonywania = new Komenda(KontynuujWykonywanie);
            KomendaPrzejęciaSkupienia = new Komenda(PrzejmijSkupienie);
            KomendaStartuProgramu = new Komenda(RozpocznijWykonywanieProgramu);
            KomendaUsunięciaKlockaPionowego = new Komenda(UsuńKlocekPionowy) {MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy};
            KomendaUsunięciaKlockaZwracającegoWartość = new Komenda(UsuńKlocekZwracającyWartość);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            KomendaZamknięciaOkna = new Komenda(ZamknijOkno);
            KomendaZwinięciaRozwinięciaKlockaZZawartością = new Komenda(ZwińRozwińKlocekZZawartością) {MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy};
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

            DziałaniaLogiczne = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool, bool>[]
            {
                new Koniunkcja(),
                new Alternatywa()
            };

            DziałaniaMatematyczne = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, double, double>[]
            {
                new Dodawanie(),
                new Odejmowanie(),
                new Mnożenie(),
                new Dzielenie(),
                new Potęgowanie(),
                new Modulo()
            };

            DziałaniaMatematyczneNaLiście = new IOpcjaZwracającaWartośćNaPodstawieParametru<double, ZmiennaTypuListowego>[]
            {
                new SumaListy(),
                new MinimumListy(),
                new MaksimumListy(),
                new ŚredniaListy()
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

            ModyfikacjeElementuListy = new ITypUstawieniaElementuListy[]
            {
                new UstawienieElementu(),
                new WstawienieElementu()
            };

            ObcinaniaSpacji = new IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>[]
            {
                new ObcinanieSpacjiZObuStron(),
                new ObcinanieSpacjiZLewejStrony(),
                new ObcinanieSpacjiZPrawejStrony()
            };

            PobieraniaTekstu = new IPobieranieTekstu[]
            {
                new PobieranieTekstuTekstowego(),
                new PobieranieTekstuLiczbowego()
            };

            PorządkiSortowania = new IPorządekSortowania[]
            {
                new SortowanieRosnąco(),
                new SortowanieMalejąco()
            };

            SortowaniaListy = new ISposóbSortowaniaListy[]
            {
                new SortowanieLiczbowe(),
                new SortowanieAlfabetyczne()
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

            SzukaniaTekstuWTekście = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>[]
            {
                new PierwszeWystąpienieTekstuWTekście(),
                new OstatnieWystąpienieTekstuWTekście()
            };

            WielkościLiter = new IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>[]
            {
                new WielkieLitery(),
                new MałeLitery()
            };

            WystąpieniaElementuNaLiście = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>[]
            {
                new PierwszeWystąpienie(),
                new OstatnieWystąpienie()
            };

            ZaokrąglaniaLiczby = new IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>[]
            {
                new Zaokrąglanie(),
                new ZaokrąglanieWGórę(),
                new ZaokrąglanieWDół()
            };

            ZnakiPorównania = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable, IComparable>[]
            {
                new Równy(),
                new Nierówny(),
                new Mniejszy(),
                new MniejszyRówny(),
                new Większy(),
                new WiększyRówny()
            };

            KlockiDotycząceList = new Klocek[]
            {
                new DodajDoListy(),
                new UsuńElementZListy(),
                new ModyfikujElementListy {WybranyTypModyfikacjiListy = ModyfikacjeElementuListy.First()},

                new ElementListyOIndeksie(),
                new IndeksElementuNaLiście {WybranaOpcja = WystąpieniaElementuNaLiście.First()},
                new LiczbaElementówNaLiście(),
                new ListaPowtórzonegoElementu(),
                new ListaZElementów(),
                new Podlista(),
                new PosortowanaLista
                {
                    WybranyPorządekSortowania = PorządkiSortowania.First(),
                    WybranySposóbSortowania = SortowaniaListy.First()
                },
                new PustaLista(),
                new PustośćListy()
            };

            KlockiDotyczącePętli = new Klocek[]
            {
                new WykonajDlaKażdegoElementu(),
                new WykonujDopóki(),
                new WykonujOdliczając(),
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
                new WykonajJeżeli(),
                new Negacja(),
                new Porównanie {WybranaOpcja = ZnakiPorównania.First()},
                new StałaLogiczna {WybranaOpcja = StałeLogiczne.First()},
                new WarunekZłożony {WybranaOpcja = DziałaniaLogiczne.First()}
            };

            KlockiMatematyczne = new Klocek[]
            {
                new ZmieńWartośćZmiennejOLiczbę(),

                new FunkcjaMatematyczna {WybranaOpcja = FunkcjeMatematyczne.First()},
                new FunkcjaTrygonometryczna {WybranaOpcja = FunkcjeTrygonometryczne.First()},
                new LosowaLiczbaCałkowitaZZakresu(),
                new LosowyUłamek(),
                new PodzielnośćLiczbyPrzezLiczbę(),
                new StałaLiczbowa(),
                new StałaMatematyczna {WybranaOpcja = StałeMatematyczne.First()},
                new WynikDziałania {WybranaOpcja = DziałaniaMatematyczne.First()},
                new WynikDziałaniaMatematycznegoNaLiście {WybranaOpcja = DziałaniaMatematyczneNaLiście.First()},
                new WystępowanieCechyLiczby {WybranaOpcja = CechyLiczby.First()},
                new ZaokrąglonaLiczba {WybranaOpcja = ZaokrąglaniaLiczby.First()},
            };

            KlockiTekstowe = new Klocek[]
            {
                new DodajTekst(),
                new Wyświetl {Konsola = Konsola},

                new DługośćTekstu(),
                new IndeksTekstuWTekście {WybranaOpcja = SzukaniaTekstuWTekście.First()},
                new LiteraTekstu(),
                new Napis(),
                new PobranyTekst
                {
                    Konsola = Konsola,
                    WybranaOpcja = PobieraniaTekstu.First()
                },
                new Podciąg(),
                new PustośćTekstu(),
                new TekstOWielkościLiter {WybranaOpcja = WielkościLiter.First()},
                new TekstZObciętymiSpacjami {WybranaOpcja = ObcinaniaSpacji.First()}
            };
        }

        private static void ResetujTrybDebugowania(KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            klocekPionowyZZawartością.Debugowanie = false;

            foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
            {
                klocekPionowy.Debugowanie = false;

                KlocekPionowyZZawartością wewnętrznyKlocekPionowyZZawartością = klocekPionowy as KlocekPionowyZZawartością;

                if (wewnętrznyKlocekPionowyZZawartością != null)
                    ResetujTrybDebugowania(wewnętrznyKlocekPionowyZZawartością);
            }
        }

        private void DodajUsuńPunktPrzerwania()
        {
            KlocekPionowy klocekPionowy = (KlocekPionowy) _klocekPosiadającySkupienie;
            klocekPionowy.PunktPrzerwania = !klocekPionowy.PunktPrzerwania;
            klocekPionowy.Rodzic.Semafor = _semafor;
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) {Nazwa = NazwaNowejZmiennej});

                NazwaNowejZmiennej = null;
            }
        }

        private void KontynuujWykonywanie()
        {
                _semafor.Set();
        }

        private void PrzejmijSkupienie(object obiektKlocka)
        {
            if (_klocekPosiadającySkupienie != null)
                _klocekPosiadającySkupienie.PosiadaSkupienie = false;

            Klocek klocek = (Klocek) obiektKlocka;
            klocek.PosiadaSkupienie = true;
            _klocekPosiadającySkupienie = klocek;
            KomendaUsunięciaKlockaPionowego.MożnaWykonać = SprawdźCzyMożnaUsunąćKlocekPionowy;
            KomendaZwinięciaRozwinięciaKlockaZZawartością.MożnaWykonać = SprawdźCzyMożnaZwinąćRozwinąćKlocekPionowy;
        }

        private void RozpocznijWykonywanieProgramu()
        {
            foreach (Zmienna zmienna in Zmienne)
                zmienna.Wartość = null;

            ResetujTrybDebugowania(RozpoczęcieProgramu);
            Konsola.LinieKonsoli.Clear();
            _wątekDebugowania?.Abort();

            _wątekDebugowania = new Thread(WykonujProgram);

            _wątekDebugowania.Start();
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
            KlocekZwracającyWartość usuwanyKlocek = (KlocekZwracającyWartość) _klocekPosiadającySkupienie;
            usuwanyKlocek.MiejsceUmieszczenia[0] = null;
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = (Zmienna) zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }

        private void WykonujProgram()
        {
            Debugowanie = true;

            RozpoczęcieProgramu.Wykonaj();

            Debugowanie = false;
        }

        private void ZamknijOkno()
        {
            _wątekDebugowania?.Abort();
        }

        private void ZwińRozwińKlocekZZawartością()
        {
            KlocekPionowyZZawartością klocek = (KlocekPionowyZZawartością) _klocekPosiadającySkupienie;
            klocek.Rozwinięty = !klocek.Rozwinięty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}