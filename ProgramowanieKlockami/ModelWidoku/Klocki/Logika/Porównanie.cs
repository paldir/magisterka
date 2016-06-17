﻿using System;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćKlockaPrzyjmującegoWartość Wartość1 { get; set; }
        public WartośćKlockaPrzyjmującegoWartość Wartość2 { get; set; }
        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, IComparable> WybranyZnakPorównania { get; set; }

        public Porównanie()
        {
            Wartość1 = new WartośćKlockaPrzyjmującegoWartość(typeof(object));
            Wartość2 = new WartośćKlockaPrzyjmującegoWartość(typeof(object));
        }

        public override object Clone()
        {
            Porównanie nowyObiekt = (Porównanie) base.Clone();
            nowyObiekt.WybranyZnakPorównania = WybranyZnakPorównania;

            return nowyObiekt;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość1 = Wartość1[0];
            KlocekZwracającyWartość wartość2 = Wartość2[0];

            if ((wartość1 == null) || (wartość2 == null))
                return false;

            object obiekt1 = wartość1.Zwróć();
            object obiekt2 = wartość2.Zwróć();

            return (obiekt1.GetType() == obiekt2.GetType()) && WybranyZnakPorównania.Zwróć((IComparable) obiekt1, (IComparable) obiekt2);
        }
    }
}