﻿using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class LiteraTekstu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Indeks, Tekst};

        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Litera tekstu";
        public override string Opis => "Zwraca literę z podanej pozycji.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Tekst { get; }

        public LiteraTekstu()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Tekst = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            int indeks = (int) Math.Round(Indeks.Zwróć<double>());
            string tekst = Tekst.Zwróć<object>().ToString();
            int długośćTekstu = tekst.Length;

            if (indeks < 0)
                indeks = 0;

            if (indeks >= długośćTekstu)
                indeks = długośćTekstu - 1;

            return długośćTekstu > 0 ? tekst[indeks].ToString() : string.Empty;
        }
    }
}