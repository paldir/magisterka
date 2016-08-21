using System;
using System.Windows;
using System.Windows.Threading;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private bool _aktualnieWykonywany;
        private bool _debugowanie;
        private bool _krokPoKroku;
        private bool _punktPrzerwania;
        private Semafor _semafor;

        public KlocekPionowyZZawartością Rodzic { get; set; }

        public bool AktualnieWykonywany
        {
            get { return _aktualnieWykonywany; }

            set
            {
                _aktualnieWykonywany = value;
                Kolor = KolorObramowania = AktualnieWykonywany && Debugowanie ? Kolory.AktualnieWykonywany : KolorPierwotny;

                if (AktualnieWykonywany && (Rodzic != null))
                    Rodzic.AktualnieWykonywany = false;
            }
        }

        public bool Debugowanie
        {
            get { return _debugowanie; }

            set
            {
                _debugowanie = value;
                KlocekPionowyZZawartością klocekPionowyZZawartością = this as KlocekPionowyZZawartością;

                if (klocekPionowyZZawartością != null)
                {
                    foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
                        klocekPionowy.Debugowanie = value;

                    WykonajJeżeli jeżeli = klocekPionowyZZawartością as WykonajJeżeli;

                    if (jeżeli != null)
                        foreach (KlocekPionowy klocekPionowy in jeżeli.AlternatywnaZawartość)
                            klocekPionowy.Debugowanie = value;
                }
            }
        }

        public bool KrokPoKroku
        {
            get { return _krokPoKroku; }

            set
            {
                _krokPoKroku = value;
                KlocekPionowyZZawartością klocekPionowyZZawartością = this as KlocekPionowyZZawartością;

                if (klocekPionowyZZawartością != null)
                {
                    foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
                        klocekPionowy.KrokPoKroku = value;

                    WykonajJeżeli jeżeli = klocekPionowyZZawartością as WykonajJeżeli;

                    if (jeżeli != null)
                        foreach (KlocekPionowy klocekPionowy in jeżeli.AlternatywnaZawartość)
                            klocekPionowy.KrokPoKroku = value;
                }
            }
        }

        public bool PunktPrzerwania
        {
            get { return _punktPrzerwania; }

            set
            {
                _punktPrzerwania = value;

                OnPropertyChanged();
            }
        }

        public Semafor Semafor
        {
            get { return _semafor; }

            set
            {
                _semafor = value;
                KlocekPionowyZZawartością klocekPionowyZZawartością = this as KlocekPionowyZZawartością;

                if (klocekPionowyZZawartością != null)
                    foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
                        klocekPionowy.Semafor = value;

                WykonajJeżeli jeżeli = klocekPionowyZZawartością as WykonajJeżeli;

                if (jeżeli != null)
                    foreach (KlocekPionowy klocekPionowy in jeżeli.AlternatywnaZawartość)
                        klocekPionowy.Semafor = value;
            }
        }

        protected void SprawdźPoprawnośćZmiennej(Zmienna zmienna, Type typZmiennej)
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;

            if (zmienna == null)
            {
                Błąd = true;

                dispatcher.Invoke(delegate { Błędy.Add(new BłądZwiązanyZBrakiemWyboruZmiennej()); });

                return;
            }

            if (typZmiennej != null)
            {
                object wartośćZmiennej = zmienna.Wartość;

                if (!typZmiennej.IsInstanceOfType(wartośćZmiennej))
                {
                    Błąd = true;

                    dispatcher.Invoke(delegate { Błędy.Add(new BłądZwiązanyZTypemZmiennej(typZmiennej, wartośćZmiennej?.GetType())); });
                }
            }
        }

        public abstract void Wykonaj();

        public override object Clone()
        {
            KlocekPionowy kopia = (KlocekPionowy) base.Clone();

            return kopia;
        }
    }
}