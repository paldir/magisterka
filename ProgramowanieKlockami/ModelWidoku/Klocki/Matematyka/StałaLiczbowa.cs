﻿using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class StałaLiczbowa : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Stała liczbowa";
        public override string Opis => "Zwraca liczbę.";
        public override Type ZwracanyTyp => typeof(double);

        public double Liczba { get; set; }

        public StałaLiczbowa()
        {
            Kolor = Kolory.Matematyka;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów) => Liczba;

        public override object Clone()
        {
            StałaLiczbowa kopia = (StałaLiczbowa) base.Clone();
            kopia.Liczba = Liczba;

            return kopia;
        }
    }
}