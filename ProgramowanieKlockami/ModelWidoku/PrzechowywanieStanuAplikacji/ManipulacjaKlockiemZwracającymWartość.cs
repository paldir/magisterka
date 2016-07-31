using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class ManipulacjaKlockiemZwracającymWartość : ManipulacjaKlockiem<KlocekZwracającyWartość>
    {
        public WartośćWewnętrznegoKlockaZwracającegoWartość Cel { get; set; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Źródło { get; set; }

        public ManipulacjaKlockiemZwracającymWartość(ManipulacjeKlockiem rodzajManipulacji, KlocekZwracającyWartość klocek) : base(rodzajManipulacji, klocek)
        {
        }

        protected override void Dodaj()
        {
            if (Źródło != null)
                Źródło[0] = null;

            if (Cel != null)
            {
                Klocek.MiejsceUmieszczenia = Cel;
                Cel[0] = Klocek;
            }
        }

        protected override void Usuń()
        {
            if (Cel != null)
                Cel[0] = null;

            if (Źródło != null)
            {
                Klocek.MiejsceUmieszczenia = Źródło;
                Źródło[0] = Klocek;
            }
        }
    }
}