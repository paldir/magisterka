using System;
using System.Linq;
using System.Threading;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu;
using ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class PobranyTekst : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Pobrany tekst";
        public override string Opis => "Pobiera od użytkownika tekst/liczbę.";
        public override Type ZwracanyTyp => typeof(object);

        public Konsola Konsola { get; set; }
        public IPobieranieTekstu WybranaOpcja { get; set; }

        public PobranyTekst() : base(typeof(object))
        {
        }

        protected override object ZwróćNiebezpiecznie()
        {
            string wiadomość = Wartość.Zwróć<object>().ToString();

            Konsola.DodajLinię(wiadomość);
            Konsola.DodajPoleTekstowe();

            LiniaKonsoli ostatniaLinia = Konsola.LinieKonsoli.Last();

            while (ostatniaLinia.Edytowalna)
                Thread.Sleep(100);

            return WybranaOpcja.Konwertuj(ostatniaLinia.Zawartość);
        }

        public override object Clone()
        {
            PobranyTekst kopia = (PobranyTekst) base.Clone();
            kopia.Konsola = Konsola;
            kopia.WybranaOpcja = WybranaOpcja;

            return kopia;
        }
    }
}