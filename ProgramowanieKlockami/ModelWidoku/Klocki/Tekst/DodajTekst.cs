namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public sealed class DodajTekst : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Dodaj tekst";
        public override string Opis => "Dodaje tekst do zmiennej.";

        public Zmienna WybranaZmienna { get; set; }

        public DodajTekst() : base(typeof(object))
        {
            Kolor = Kolory.Tekst;
        }

        public override object Clone()
        {
            DodajTekst kopia = (DodajTekst) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            base.Wykonaj();

            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((klocekZwracającyWartość != null) && (WybranaZmienna != null))
            {
                object wartośćZmiennej = WybranaZmienna.Wartość;
                string zwróconaWartość = klocekZwracającyWartość.Zwróć<string>();

                if (wartośćZmiennej == null)
                    wartośćZmiennej = string.Empty;

                WybranaZmienna.Wartość = string.Concat(wartośćZmiennej, zwróconaWartość);
            }
        }
    }
}