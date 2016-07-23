namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class DodajDoListy : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Dodanie elementu do listy";
        public override string Opis => "Dodaje element na koniec listy.";

        public Zmienna WybranaZmienna { get; set; }

        public DodajDoListy() : base(typeof(object))
        {
            Kolor = Kolory.Listy;
        }

        public override object Clone()
        {
            DodajDoListy kopia = (DodajDoListy) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            base.Wykonaj();

            ZmiennaTypuListowego lista = WybranaZmienna?.Wartość as ZmiennaTypuListowego;
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((lista != null) && (klocekZwracającyWartość != null))
                lista.Add(klocekZwracającyWartość.Zwróć<object>());
        }
    }
}