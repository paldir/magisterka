using System;
using System.Linq;
using System.Threading;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu;
using ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class PobranyTekst : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override string Nazwa => "Pobrany tekst";
        public override string Opis => "Pobiera od użytkownika tekst/liczbę.";
        public override Type ZwracanyTyp => null;

        public Konsola Konsola { get; set; }
        public IPobieranieTekstu WybranaOpcja { get; set; }

        public PobranyTekst() : base(typeof(object))
        {
            Kolor = Kolory.Tekst;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            string wiadomość = Wartość.Zwróć<object>().ToString();

            if (sprawdzanieBłędów)
                return string.Empty;

            AutoResetEvent semafor = new AutoResetEvent(false);

            Konsola.DodajLinię(wiadomość);
            Konsola.DodajPoleTekstowe();

            LiniaKonsoli ostatniaLinia = Konsola.LinieKonsoli.Last();
            ostatniaLinia.Semafor = semafor;

            semafor.WaitOne();

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