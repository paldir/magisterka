using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class DodajDoListy : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Dodanie elementu do listy";
        public override string Opis => "Dodaje element na koniec listy.";

        public Zmienna WybranaZmienna { get; set; }

        public DodajDoListy() : base(typeof(object))
        {
        }

        public override void Wykonaj()
        {
            ZmiennaTypuListowego lista = WybranaZmienna?.Wartość as ZmiennaTypuListowego;
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((lista != null) && (klocekZwracającyWartość != null))
                lista.Add(klocekZwracającyWartość.Zwróć<object>());
        }
    }
}