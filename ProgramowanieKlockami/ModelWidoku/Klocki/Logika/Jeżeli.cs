using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Jeżeli : KlocekPionowyPrzyjmującyWartość
    {
        private KlocekPionowy _zawartość;
        private bool _widoczny;

        public override string Nazwa => "Jeżeli";
        public override string Opis => "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";
        public override Brush Kolor => Kolory.Logika;
        public Komenda KomendaOdwróceniaWidoczności { get; }

        public KlocekPionowy Zawartość
        {
            get { return _zawartość; }

            set
            {
                _zawartość = value; 
                
                OnPropertyChanged();
            }
        }

        public bool Widoczny
        {
            get { return _widoczny; }

            private set
            {
                _widoczny = value;

                OnPropertyChanged();
            }
        }

        public Jeżeli()
        {
            Widoczny = true;
            KomendaOdwróceniaWidoczności = new Komenda(OdwróćWidoczność);
        }

        private void OdwróćWidoczność()
        {
            Widoczny = !Widoczny;
        }
    }
}