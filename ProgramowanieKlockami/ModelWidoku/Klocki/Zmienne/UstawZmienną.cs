namespace ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne
{
    public class UstawZmienną : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Ustaw zmienną";
        public override string Opis => "Ustawia zmiennej wybraną wartość";

        public Zmienna WybranaZmienna { get; set; }

        public UstawZmienną() : base(typeof(object))
        {
            Kolor = Kolory.Zmienne;
        }

        public override object Clone()
        {
            UstawZmienną kopia = (UstawZmienną) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość wartość = Wartość[0];

            if ((WybranaZmienna != null) && (wartość != null))
                WybranaZmienna.Wartość = wartość.Zwróć<object>();
        }
    }
}