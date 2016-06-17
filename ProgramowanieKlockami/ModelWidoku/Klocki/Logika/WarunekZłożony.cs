using System.Collections.ObjectModel;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class WarunekZłożony : KlocekZwracającyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Warunek złożony";
        public override string Opis => "Zwraca prawdę, jeśli oba warunki są prawdziwe lub gdy przynajmniej jeden jest prawdziwy.";

        public ObservableCollection<KlocekZwracającyWartość> Wartość1 { get; set; }
        public ObservableCollection<KlocekZwracającyWartość> Wartość2 { get; set; }
        public IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<bool, bool> WybraneDziałanie { get; set; }

        public WarunekZłożony()
        {
            Wartość1 = new ObservableCollection<KlocekZwracającyWartość> {null};
            Wartość2 = new ObservableCollection<KlocekZwracającyWartość> {null};
        }

        public override object Clone()
        {
            WarunekZłożony kopia = (WarunekZłożony) base.Clone();
            kopia.WybraneDziałanie = WybraneDziałanie;

            return kopia;
        }

        public override object Zwróć()
        {
            KlocekZwracającyWartość wartość1 = Wartość1[0];
            KlocekZwracającyWartość wartość2 = Wartość2[0];

            if ((wartość1 == null) || (wartość2 == null))
                return false;

            object warunek1 = wartość1.Zwróć();
            object warunek2 = wartość2.Zwróć();

            if (!(warunek1 is bool) || !(warunek2 is bool))
                return false;

            return WybraneDziałanie.Zwróć((bool) warunek1, (bool) warunek2);
        }
    }
}