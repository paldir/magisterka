using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartość
    {
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";
        public override Brush Kolor => Kolory.Logika;
        public ObservableCollection<KlocekZwracającyWartość> WartośćPierwsza { get; set; }
        public ObservableCollection<KlocekZwracającyWartość> WartośćDruga { get; set; }

        public Porównanie()
        {
            WartośćPierwsza = new ObservableCollection<KlocekZwracającyWartość> {null};
            WartośćDruga = new ObservableCollection<KlocekZwracającyWartość> {null};
        }
    }
}