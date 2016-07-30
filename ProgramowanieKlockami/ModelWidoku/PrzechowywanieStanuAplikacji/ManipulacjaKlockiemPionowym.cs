using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class ManipulacjaKlockiemPionowym : ManipulacjaKlockiem<KlocekPionowy>
    {
        private readonly int _indeks;

        public ManipulacjaKlockiemPionowym(ManipulacjeKlockiem rodzajManipulacji, KlocekPionowy klocekPionowy, int indeks) : base(rodzajManipulacji, klocekPionowy)
        {
            _indeks = indeks;
        }

        protected override void Dodaj()
        {
            Klocek.Rodzic.Zawartość.Insert(_indeks, Klocek);
        }

        protected override void Usuń()
        {
            ZawartośćKlockaPionowegoZZawartością miejsceUmieszczenia = Klocek.Rodzic.Zawartość;

            if (_indeks < miejsceUmieszczenia.Count)
                miejsceUmieszczenia.RemoveAt(_indeks);
        }
    }
}