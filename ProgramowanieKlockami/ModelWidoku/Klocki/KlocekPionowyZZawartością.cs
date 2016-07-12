using System.Linq;
using System.Threading;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        private bool _rozwinięty;

        public ZawartośćKlockaPionowegoZZawartością Zawartość { get; }

        public AutoResetEvent Semafor { get; set; }
        public bool SkokPętli { get; set; }

        public bool Rozwinięty
        {
            get { return _rozwinięty; }

            set
            {
                _rozwinięty = value;

                OnPropertyChanged();
            }
        }

        protected KlocekPionowyZZawartością()
        {
            Zawartość = new ZawartośćKlockaPionowegoZZawartością {KlocekPionowyZZawartością = this};
            Rozwinięty = true;
        }

        public override void Wykonaj()
        {
            foreach (KlocekPionowy klocekPionowy in Zawartość)
                if (SkokPętli)
                    break;
                else
                {
                    klocekPionowy.AktualnieWykonywany = true;

                    if (klocekPionowy.PunktPrzerwania)
                        Semafor.WaitOne();

                    klocekPionowy.Wykonaj();

                    klocekPionowy.AktualnieWykonywany = false;
                }
        }

        public static void ZresetujRekurencyjnieFlagęSkokuWPętli(KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            klocekPionowyZZawartością.SkokPętli = false;

            foreach (KlocekPionowyZZawartością klocek in klocekPionowyZZawartością.Zawartość.Where(k => k is KlocekPionowyZZawartością).Cast<KlocekPionowyZZawartością>())
                ZresetujRekurencyjnieFlagęSkokuWPętli(klocek);
        }
    }
}