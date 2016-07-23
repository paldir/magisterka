using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

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
                    foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
                        klocekPionowy.Debugowanie = value;
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
                    foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
                        klocekPionowy.KrokPoKroku = value;
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
            }
        }

        public abstract void Wykonaj();
    }
}