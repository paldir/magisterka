using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Negacja : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override string Nazwa => "Negacja";
        public override string Opis => "Zwraca prawdę, jeśli wejście jest fałszywe. Zwraca fałsz, jeśli wejście jest prawdziwe";
        public override Type ZwracanyTyp => typeof(bool);

        public Negacja() : base(typeof(bool))
        {
            Kolor = Kolory.Logika;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            return !Wartość.Zwróć<bool>(sprawdzanieBłędów);
        }
    }
}