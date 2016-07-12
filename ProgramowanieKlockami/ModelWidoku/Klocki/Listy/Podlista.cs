﻿using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class Podlista : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Lista, Indeks1, Indeks2};

        public override string Nazwa => "Podlista";
        public override string Opis => "Z istniejącej listy kopiuje fragment i zwraca jako nową listę.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Lista { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks1 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks2 { get; }

        public Podlista()
        {
            Indeks1 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Indeks2 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Listy;
            Lista = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(ZmiennaTypuListowego));
        }

        protected override object ZwróćNiebezpiecznie()
        {
            ZmiennaTypuListowego lista = Lista.Zwróć<ZmiennaTypuListowego>();
            int indeks1 = (int) Math.Round(Indeks1.Zwróć<double>());
            int indeks2 = (int) Math.Round(Indeks2.Zwróć<double>());
            int liczbaElementów = lista.Count;

            if (indeks1 > indeks2)
            {
                int tmp = indeks1;
                indeks1 = indeks2;
                indeks2 = tmp;
            }

            if (indeks1 < 0)
                indeks1 = 0;

            if (indeks1 >= liczbaElementów)
                indeks1 = liczbaElementów - 1;

            if (indeks2 < 0)
                indeks2 = 0;

            if (indeks2 >= liczbaElementów)
                indeks2 = liczbaElementów - 1;

            return lista.GetRange(indeks1, indeks2 - indeks1 + 1);
        }
    }
}