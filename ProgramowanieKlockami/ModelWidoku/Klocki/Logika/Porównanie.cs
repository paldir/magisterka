using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : IKlocekZwracającyWartość
    {
        public string Nazwa => "Porównanie";
        public string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";
        public Brush Kolor => Kolory.Logika;
        public ObservableCollection<IKlocekZwracającyWartość> WartośćPierwsza { get; set; }
        public ObservableCollection<IKlocekZwracającyWartość> WartośćDruga { get; set; }

        public Porównanie()
        {
            WartośćPierwsza = new ObservableCollection<IKlocekZwracającyWartość> {null};
            WartośćDruga = new ObservableCollection<IKlocekZwracającyWartość> {null};
        }
    }
}