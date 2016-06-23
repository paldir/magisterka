using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaPowtórzonegoElementu : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Lista złożona z powtórzonego elementu";
        public override string Opis => "Tworzy listę zawierającą wybrany element powtórzony określoną liczbę razy.";
        public override Type ZwracanyTyp => typeof(List<object>);

        public WartośćKlockaPrzyjmującegoWartość Element { get; }
        public WartośćKlockaPrzyjmującegoWartość Liczba { get; }

        public ListaPowtórzonegoElementu()
        {
            Element = new WartośćKlockaPrzyjmującegoWartość(typeof(object));
            Liczba = new WartośćKlockaPrzyjmującegoWartość(typeof(double));
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość klocekElementu = Element[0];
            KlocekZwracającyWartość klocekLiczby = Liczba[0];

            if ((klocekElementu == null) || (klocekLiczby == null))
                return new List<object>();

            object liczba = klocekLiczby.Zwróć();

            if (!(liczba is double))
                return new List<object>();

            object element = klocekElementu.Zwróć();

            return new List<object>(Enumerable.Repeat(element, (int) Math.Round((double) liczba)));
        }
    }
}