using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class DodajTekst : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Dodaj tekst";
        public override string Opis => "Dodaje tekst do zmiennej.";

        public Zmienna WybranaZmienna { get; set; }

        public DodajTekst() : base(typeof(object))
        {
        }

        public override void Wykonaj()
        {
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