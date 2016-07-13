using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private bool _aktualnieWykonywany;
        private bool _debugowanie;
        private bool _punktPrzerwania;

        public KlocekPionowyZZawartością Rodzic { get; set; }
        public Semafor Semafor { get; set; }

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

        public bool PunktPrzerwania
        {
            get { return _punktPrzerwania; }

            set
            {
                _punktPrzerwania = value;

                OnPropertyChanged();
            }
        }

        public abstract void Wykonaj();
    }
}