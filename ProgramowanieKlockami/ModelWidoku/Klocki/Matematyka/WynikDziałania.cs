using System.Collections.ObjectModel;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.DziałaniaMatematyczne;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka
{
    public class WynikDziałania : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Matematyka;
        public override string Nazwa => "Wynik działania";
        public override string Opis => "Zwraca wynik działania matematycznego.";

        public ObservableCollection<KlocekZwracającyWartość> Wartość1 { get; set; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość2 { get; set; }
        public IDziałanieMatematyczne WybraneDziałanieMatematyczne { get; set; }

        public WynikDziałania()
        {
            Wartość1 = new ObservableCollection<KlocekZwracającyWartość> {null};
            Wartość2 = new ObservableCollection<KlocekZwracającyWartość> {null};
        }

        public override object Clone()
        {
            WynikDziałania kopia = (WynikDziałania) base.Clone();
            kopia.WybraneDziałanieMatematyczne = WybraneDziałanieMatematyczne;

            return kopia;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość1 = Wartość1[0];
            KlocekZwracającyWartość wartość2 = Wartość2[0];

            if ((wartość1 == null) || (wartość2 == null))
                return 0;

            object liczba1 = wartość1.Zwróć();
            object liczba2 = wartość2.Zwróć();

            if (!(liczba1 is double) || !(liczba2 is double))
                return 0;

            return WybraneDziałanieMatematyczne.Wykonaj((double) liczba1, (double) liczba2);
        }
    }
}