﻿using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class DodanieDoListy : KlocekPionowyPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Dodanie elementu do listy";
        public override string Opis => "Dodaje element na koniec listy.";

        public Zmienna WybranaZmienna { get; set; }

        public DodanieDoListy() : base(typeof(object))
        {
        }

        public override void Wykonaj()
        {
            List<object> lista = WybranaZmienna?.Wartość as List<object>;
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if ((lista != null) && (klocekZwracającyWartość != null))
                lista.Add(klocekZwracającyWartość.Zwróć<object>());
        }
    }
}