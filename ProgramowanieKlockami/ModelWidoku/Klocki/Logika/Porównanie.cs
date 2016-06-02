using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.ZnakiPorównania;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public ObservableCollection<KlocekZwracającyWartość> Wartość1 { get; set; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość2 { get; set; }
        public IZnakPorównania ZnakPorównania { get; set; }

        public Porównanie()
        {
            Wartość1 = new ObservableCollection<KlocekZwracającyWartość> {null};
            Wartość2 = new ObservableCollection<KlocekZwracającyWartość> {null};
        }

        public override object Clone()
        {
            Porównanie nowyObiekt = (Porównanie) base.Clone();
            nowyObiekt.ZnakPorównania = ZnakPorównania;

            return nowyObiekt;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość1 = Wartość1[0];
            KlocekZwracającyWartość wartość2 = Wartość2[0];

            if ((wartość1 == null) || (wartość2 == null))
                return false;

            return ZnakPorównania.Porównaj((IComparable) wartość1.Zwróć(), (IComparable) wartość2.Zwróć());
        }
    }
}