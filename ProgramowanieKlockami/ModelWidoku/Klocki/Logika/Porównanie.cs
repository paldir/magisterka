using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public ObservableCollection<KlocekZwracającyWartość> Wartość1 { get; set; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość2 { get; set; }
        public IZnakPorównania WybranyZnakPorównania { get; set; }

        public Porównanie()
        {
            Wartość1 = new ObservableCollection<KlocekZwracającyWartość> {null};
            Wartość2 = new ObservableCollection<KlocekZwracającyWartość> {null};
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

            return (obiekt1.GetType() == obiekt2.GetType()) && WybranyZnakPorównania.Porównaj((IComparable) obiekt1, (IComparable) obiekt2);
        }
    }
}