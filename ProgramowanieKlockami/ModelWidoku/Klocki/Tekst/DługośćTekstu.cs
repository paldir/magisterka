using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class DługośćTekstu : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override string Nazwa => "Długość tekstu";
        public override string Opis => "Zwraca liczbę znaków tekstu.";
        public override Type ZwracanyTyp => typeof(double);

        public DługośćTekstu() : base(typeof(object))
        {
            Kolor = Kolory.Tekst;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            string napis = Wartość.Zwróć<object>().ToString();

            return napis.Length;
        }
    }
}