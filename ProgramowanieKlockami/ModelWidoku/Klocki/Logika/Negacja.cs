﻿using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Negacja : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Negacja";
        public override string Opis => "Zwraca prawdę, jeśli wejście jest fałszywe. Zwraca fałsz, jeśli wejście jest prawdziwe";
        public override Type ZwracanyTyp => typeof(bool);

        public Negacja() : base(typeof(bool))
        {
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość = Wartość[0];

            object warunek = wartość?.Zwróć();

            if (!(warunek is bool))
                return false;

            return !(bool) warunek;
        }
    }
}