using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji
{
    public abstract class ManipulacjaKlockiem<T> where T : Klocek
    {
        protected ManipulacjeKlockiem RodzajManipulacji { get; }

        public T Klocek { get; }

        protected ManipulacjaKlockiem(ManipulacjeKlockiem rodzajManipulacji, T klocek)
        {
            Klocek = klocek;
            RodzajManipulacji = rodzajManipulacji;
        }

        public abstract void Cofnij();
        public abstract void Przywróć();
    }

    public enum ManipulacjeKlockiem
    {
        Dodanie,
        Usunięcie
    }
}