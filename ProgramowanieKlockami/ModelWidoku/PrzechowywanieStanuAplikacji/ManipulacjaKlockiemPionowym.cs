using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class ManipulacjaKlockiemPionowym : ManipulacjaKlockiem<KlocekPionowy>
    {
        public ZawartośćKlockaPionowegoZZawartością Cel { get; set; }
        public int IndeksDocelowy { get; set; }
        public int IndeksŹródłowy { get; set; }
        public ZawartośćKlockaPionowegoZZawartością Źródło { get; set; }

        public ManipulacjaKlockiemPionowym(ManipulacjeKlockiem rodzajManipulacji, KlocekPionowy klocekPionowy) : base(rodzajManipulacji, klocekPionowy)
        {
        }

        protected override void Dodaj()
        {
            Źródło?.RemoveAt(IndeksŹródłowy);

            if (Cel != null)
            {
                Klocek.Rodzic = Cel.KlocekPionowyZZawartością;

                Cel.Insert(IndeksDocelowy, Klocek);
            }
        }

        protected override void Usuń()
        {
            Cel?.RemoveAt(IndeksDocelowy);

            if (Źródło != null)
            {
                Klocek.Rodzic = Źródło.KlocekPionowyZZawartością;

                Źródło.Insert(IndeksŹródłowy, Klocek);
            }
        }
    }
}