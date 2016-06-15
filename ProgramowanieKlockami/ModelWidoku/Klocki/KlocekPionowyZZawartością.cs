namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        public ZawartośćKlockaPionowegoZZawartością Zawartość { get; }

        public bool PrzerwanieWykonywania { get; set; }

        private bool _rozwinięty;

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
                if (PrzerwanieWykonywania)
                {
                    PrzerwanieWykonywania = false;

                    break;
                }
                else
                    klocekPionowy.Wykonaj();
        }
    }
}