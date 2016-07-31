using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public abstract class ManipulacjaKlockiem
    {
        protected ManipulacjeKlockiem RodzajManipulacji { get; }

        protected ManipulacjaKlockiem(ManipulacjeKlockiem rodzajManipulacji)
        {
            RodzajManipulacji = rodzajManipulacji;
        }

        protected abstract void Dodaj();
        protected abstract void Usuń();

        public void Cofnij()
        {
            if (RodzajManipulacji == ManipulacjeKlockiem.Dodanie)
                Usuń();
            else
                Dodaj();
        }

        public void Przywróć()
        {
            if (RodzajManipulacji == ManipulacjeKlockiem.Dodanie)
                Dodaj();
            else
                Usuń();
        }
    }

    public abstract class ManipulacjaKlockiem<T> : ManipulacjaKlockiem where T : Klocek
    {
        public T Klocek { get; }

        protected ManipulacjaKlockiem(ManipulacjeKlockiem rodzajManipulacji, T klocek) : base(rodzajManipulacji)
        {
            Klocek = klocek;
        }
    }

    public enum ManipulacjeKlockiem
    {
        Dodanie,
        Usunięcie
    }
}