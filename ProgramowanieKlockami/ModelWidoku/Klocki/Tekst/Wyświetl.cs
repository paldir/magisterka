﻿using ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Wyświetl : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Wyświetl";
        public override string Opis => "Wyświetla tekst, liczbę lub inną wartość.";

        public Konsola Konsola { get; set; }

        public Wyświetl() : base(typeof(object))
        {
            Kolor = Kolory.Tekst;
        }

        public override object Clone()
        {
            Wyświetl nowyKlocek = (Wyświetl) base.Clone();
            nowyKlocek.Konsola = Konsola;

            return nowyKlocek;
        }

        public override void Wykonaj()
        {
            SprawdźPoprawnośćKlockówKonfigurujących();

            if (Błąd)
                return;

            object wartość = Wartość.Zwróć<object>(false);

            if (wartość != null)
                Konsola.DodajLinię(wartość.ToString());
        }
    }
}