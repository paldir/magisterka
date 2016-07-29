using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public class ManipulacjaKlockiem : ManipulacjaKlockiem<KlocekPionowy>
    {
        private readonly int _indeks;

        public ManipulacjaKlockiem(ManipulacjeKlockiem rodzajManipulacji, KlocekPionowy klocekPionowy, int indeks) : base(rodzajManipulacji, klocekPionowy)
        {
            _indeks = indeks;
        }

        public override void Cofnij()
        {
            if (RodzajManipulacji == ManipulacjeKlockiem.Dodanie)
                Usuń();
            else
                Dodaj();
        }

        public override void Przywróć()
        {
            if (RodzajManipulacji == ManipulacjeKlockiem.Dodanie)
                Dodaj();
            else
                Usuń();
        }

        private void Dodaj()
        {
            Klocek.Rodzic.Zawartość.Insert(_indeks, Klocek);
        }

        private void Usuń()
        {
            Klocek.Rodzic.Zawartość.RemoveAt(_indeks);
        }
    }
}