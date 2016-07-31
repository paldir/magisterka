using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;
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
using ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        private bool _debugowanie;
        private Klocek _klocekPosiadającySkupienie;
        private string _nazwaNowejZmiennej;
        private double _powiększenie;
        private readonly Semafor _semafor;
        private Thread _wątekDebugowania;
        private bool _wPunkciePrzerwania;

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
        public Komenda KomendaKopiowaniaKlocka { get; }
        public Komenda KomendaPrzejęciaSkupienia { get; }
        public Komenda KomendaCofnięciaStanuAplikacji { get; }
        public Komenda KomendaPrzywróceniaStanuAplikacji { get; }
        public Komenda KomendaStartuProgramu { get; }
        public Komenda KomendaUsunięciaKlockaPionowego { get; }
        public Komenda KomendaUsunięciaKlockaZwracającegoWartość { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Komenda KomendaWycięciaKlocka { get; }
        public Komenda KomendaWykonaniaNastępnegoKroku { get; }
        public Komenda KomendaZamknięciaOkna { get; }
        public Komenda KomendaZatrzymaniaDebugowania { get; }
        public Komenda KomendaZwinięciaRozwinięciaKlockaZZawartością { get; }
        public Konsola Konsola { get; }
        public MagazynZmian MagazynZmian { get; }
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
        public ObservableCollection<Klocek> Schowek { get; }
        public IEnumerable<ISposóbSortowaniaListy> SortowaniaListy { get; }
        public IEnumerable<IOpcjaZwracającaWartość<bool>> StałeLogiczne { get; }
        public IEnumerable<IOpcjaZwracającaWartość<double>> StałeMatematyczne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, object, object>> SzukaniaTekstuWTekście { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<object, object>> WielkościLiter { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<double, ZmiennaTypuListowego, object>> WystąpieniaElementuNaLiście { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>> ZaokrąglaniaLiczby { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public IEnumerable<IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, object, object>> ZnakiPorównania { get; }

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

        public bool WPunkciePrzerwania
        {
            get { return _wPunkciePrzerwania; }

            set
            {
                _wPunkciePrzerwania = value;

                if (!RozpoczęcieProgramu.Debugowanie == WPunkciePrzerwania)
                    RozpoczęcieProgramu.Debugowanie = WPunkciePrzerwania;

                OnPropertyChanged();
            }
        }

        public Główny()
        {
            _semafor = new Semafor();
            MagazynZmian = new MagazynZmian();
            Konsola = new Konsola();
            KomendaCofnięciaStanuAplikacji = new Komenda(CofnijStanAplikacji);
            KomendaDodaniaUsunięciaPunktuPrzerwania = new Komenda(DodajUsuńPunktPrzerwania);
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaKontynuacjiWykonywania = new Komenda(KontynuujWykonywanie);
            KomendaKopiowaniaKlocka = new Komenda(KopiujKlocek);
            KomendaPrzejęciaSkupienia = new Komenda(PrzejmijSkupienie);
            KomendaPrzywróceniaStanuAplikacji = new Komenda(PrzywróćStanAplikacji);
            KomendaStartuProgramu = new Komenda(RozpocznijWykonywanieProgramu);
            KomendaUsunięciaKlockaPionowego = new Komenda(UsuńKlocekPionowy);
            KomendaUsunięciaKlockaZwracającegoWartość = new Komenda(UsuńKlocekZwracającyWartość);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            KomendaWycięciaKlocka = new Komenda(WytnijKlocek);
            KomendaWykonaniaNastępnegoKroku = new Komenda(WykonajNastępnyKrok);
            KomendaZamknięciaOkna = new Komenda(ZamknijOkno);
            KomendaZatrzymaniaDebugowania = new Komenda(ZatrzymajDebugowanie);
            KomendaZwinięciaRozwinięciaKlockaZZawartością = new Komenda(ZwińRozwińKlocekZZawartością);
            ObsługującyPrzeciąganieZPrzybornika = new ObsługującyPrzeciąganieZPrzybornika();
            ObsługującyPrzenoszenieKlockówPionowych = new ObsługującyPrzenoszenieKlockówPionowych();
            ObsługującyPrzenoszenieKlockówZwracającychWartość = new ObsługującyPrzenoszenieKlockówZwracającychWartość();
            ObsługującyUpuszczanieKlockówPionowych = new ObsługującyUpuszczanieKlockówPionowych(DodajDziałanie);
            ObsługującyUpuszczanieKlockówZwracającychWartość = new ObsługującyUpuszczanieKlockówZwracającychWartość(DodajDziałanie);
            Powiększenie = 1;
            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Schowek = new ObservableCollection<Klocek> {null};
            Zmienne = new ObservableCollection<Zmienna>();
            _semafor.SemaforOpuszczony += _semafor_SemaforOpuszczony;

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

            ZnakiPorównania = new IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, object, object>[]
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

        private static void ResetujBłędy(KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            klocekPionowyZZawartością.Błąd = false;

            foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
            {
                klocekPionowy.Błąd = false;
                KlocekPionowyZZawartością wewnętrznyKlocekPionowyZZawartością = klocekPionowy as KlocekPionowyZZawartością;

                if (wewnętrznyKlocekPionowyZZawartością != null)
                    ResetujBłędy(wewnętrznyKlocekPionowyZZawartością);
            }
        }

        private static void ResetujFlagęAktualnegoWykonywania(KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            klocekPionowyZZawartością.AktualnieWykonywany = false;

            foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
            {
                klocekPionowy.AktualnieWykonywany = false;

                KlocekPionowyZZawartością wewnętrznyKlocekPionowyZZawartością = klocekPionowy as KlocekPionowyZZawartością;

                if (wewnętrznyKlocekPionowyZZawartością != null)
                    ResetujFlagęAktualnegoWykonywania(wewnętrznyKlocekPionowyZZawartością);
            }
        }

        private static void ZwińRozwińKlocekZZawartością(object obiektKlocka)
        {
            KlocekPionowyZZawartością klocek = (KlocekPionowyZZawartością) obiektKlocka;
            klocek.Rozwinięty = !klocek.Rozwinięty;
        }

        private void CofnijStanAplikacji()
        {
            MagazynZmian.Cofnij();
        }

        private void DodajDziałanie(ManipulacjaKlockiem manipulacja) 
        {
            MagazynZmian.DodajDziałanie(manipulacja);
        }

        private void DodajUsuńPunktPrzerwania(object obiektKlocka)
        {
            KlocekPionowy klocekPionowy = (KlocekPionowy) obiektKlocka;

            if (klocekPionowy.Rodzic != null)
            {
                klocekPionowy.PunktPrzerwania = !klocekPionowy.PunktPrzerwania;
                RozpoczęcieProgramu.Semafor = _semafor;
            }
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienna nowaZmienna = new Zmienna(Zmienne) {Nazwa = NazwaNowejZmiennej};
                List<string> nazwyZmiennych = Zmienne.Select(z => z.Nazwa).Concat(new[] {NazwaNowejZmiennej}).OrderBy(n => n).ToList();

                Zmienne.Insert(nazwyZmiennych.IndexOf(NazwaNowejZmiennej), nowaZmienna);

                NazwaNowejZmiennej = null;
            }
        }

        private void KontynuujWykonywanie()
        {
            if (WPunkciePrzerwania)
            {
                WPunkciePrzerwania = false;
                RozpoczęcieProgramu.KrokPoKroku = false;

                _semafor.Podnieś();
            }
        }

        private void KopiujKlocek(object obiektKlocka)
        {
            Klocek klocek = (Klocek) ((Klocek) obiektKlocka).Clone();
            klocek.ZPrzybornika = true;

            Schowek.RemoveAt(0);
            Schowek.Add(klocek);
        }

        private void PrzejmijSkupienie(object obiektKlocka)
        {
            if (_klocekPosiadającySkupienie != null)
                _klocekPosiadającySkupienie.PosiadaSkupienie = false;

            Klocek klocek = (Klocek) obiektKlocka;
            klocek.PosiadaSkupienie = true;
            _klocekPosiadającySkupienie = klocek;
        }

        private void PrzywróćStanAplikacji()
        {
            MagazynZmian.Przywróć();
        }

        private void RozpocznijWykonywanieProgramu()
        {
            if (!Debugowanie)
            {
                foreach (Zmienna zmienna in Zmienne)
                    zmienna.Wartość = null;

                ResetujBłędy(RozpoczęcieProgramu);
                ResetujFlagęAktualnegoWykonywania(RozpoczęcieProgramu);
                Konsola.LinieKonsoli.Clear();
                _wątekDebugowania?.Abort();

                _wątekDebugowania = new Thread(WykonujProgram);

                _wątekDebugowania.Start();
            }
        }

        private void _semafor_SemaforOpuszczony(object sender, EventArgs e)
        {
            WPunkciePrzerwania = true;
        }

        private void UsuńKlocekPionowy(object obiektKlocka)
        {
            KlocekPionowy usuwanyKlocek = (KlocekPionowy) obiektKlocka;
            KlocekPionowyZZawartością klocekPionowyZZawartością = usuwanyKlocek.Rodzic;

            if (klocekPionowyZZawartością != null)
            {
                ZawartośćKlockaPionowegoZZawartością miejsceUmieszczenia = klocekPionowyZZawartością.Zawartość;
                int indeks = miejsceUmieszczenia.IndexOf(usuwanyKlocek);

                miejsceUmieszczenia.RemoveAt(indeks);
                DodajDziałanie(new ManipulacjaKlockiemPionowym(ManipulacjeKlockiem.Usunięcie, usuwanyKlocek)
                {
                    IndeksDocelowy = indeks,
                    Cel = miejsceUmieszczenia
                });
            }
        }

        private void UsuńKlocekZwracającyWartość(object obiektKlocka)
        {
            KlocekZwracającyWartość usuwanyKlocek = (KlocekZwracającyWartość) obiektKlocka;
            WartośćWewnętrznegoKlockaZwracającegoWartość miejsceUmieszczenia = usuwanyKlocek.MiejsceUmieszczenia;
            miejsceUmieszczenia[0] = null;

            DodajDziałanie(new ManipulacjaKlockiemZwracającymWartość(ManipulacjeKlockiem.Usunięcie, usuwanyKlocek) {Cel = miejsceUmieszczenia});
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = (Zmienna) zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }

        private void WykonajNastępnyKrok()
        {
            if (WPunkciePrzerwania)
            {
                RozpoczęcieProgramu.KrokPoKroku = true;

                _semafor.Podnieś();
            }
        }

        private void WykonujProgram()
        {
            Debugowanie = true;

            RozpoczęcieProgramu.Wykonaj();

            Debugowanie = false;
            WPunkciePrzerwania = false;
            RozpoczęcieProgramu.KrokPoKroku = false;
        }

        private void WytnijKlocek(object obiektKlocka)
        {
            if (obiektKlocka is KlocekPionowy)
                UsuńKlocekPionowy(obiektKlocka);
            else
                UsuńKlocekZwracającyWartość(obiektKlocka);

            Klocek klocek = (Klocek) ((Klocek) obiektKlocka).Clone();
            klocek.ZPrzybornika = true;

            Schowek.RemoveAt(0);
            Schowek.Add(klocek);
        }

        private void ZamknijOkno()
        {
            _wątekDebugowania?.Abort();
        }

        private void ZatrzymajDebugowanie()
        {
            if (Debugowanie)
            {
                _wątekDebugowania?.Abort();
                ResetujFlagęAktualnegoWykonywania(RozpoczęcieProgramu);

                Debugowanie = false;
                WPunkciePrzerwania = false;
                RozpoczęcieProgramu.KrokPoKroku = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}