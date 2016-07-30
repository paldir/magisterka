using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class ManipulacjaKlockiemZwracającymWartość : ManipulacjaKlockiem<KlocekZwracającyWartość>
    {
        public ManipulacjaKlockiemZwracającymWartość(ManipulacjeKlockiem rodzajManipulacji, KlocekZwracającyWartość klocek) : base(rodzajManipulacji, klocek)
        {
        }

        protected override void Dodaj()
        {
            Klocek.MiejsceUmieszczenia[0] = Klocek;
        }

        protected override void Usuń()
        {
            Klocek.MiejsceUmieszczenia[0] = null;
        }
    }
}