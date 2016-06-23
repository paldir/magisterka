using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PustośćListy : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Sprawdzenie pustości listy";
        public override string Opis => "Zwraca prawdę, jeśli lista jest pusta.";
        public override Type ZwracanyTyp => typeof(bool);

        public WartośćKlockaPrzyjmującegoWartość Lista { get; }

        public PustośćListy()
        {
            Lista = new WartośćKlockaPrzyjmującegoWartość(typeof(List<object>));
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Lista[0];
            object lista = klocekZwracającyWartość?.Zwróć();

            return (lista as List<object>)?.Count == 0;
        }
    }
}