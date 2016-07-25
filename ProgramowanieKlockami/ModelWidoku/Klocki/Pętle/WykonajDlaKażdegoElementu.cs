using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonajDlaKażdegoElementu : KlocekPionowyZZawartościąPrzyjmującyWartość, IPętla
    {
        public override string Nazwa => "Dla każdego elementu listy";
        public override string Opis => "Ustawia wartość wybranej zmiennej na kolejne elementy listy.";

        public PowódSkoku PowódSkoku { get; set; }
        public Zmienna WybranaZmienna { get; set; }

        public WykonajDlaKażdegoElementu() : base(typeof(ZmiennaTypuListowego))
        {
            Kolor = Kolory.Pętle;
        }

        public override object Clone()
        {
            WykonajDlaKażdegoElementu kopia = (WykonajDlaKażdegoElementu) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            object obiektListy = Wartość[0]?.Zwróć<object>();
            Błędy = new ObservableCollection<BłądKlocka>();
            Błąd = false;
            ZmiennaTypuListowego lista = obiektListy as ZmiennaTypuListowego;

            if (lista == null)
            {
                Błąd = true;
                lista = new ZmiennaTypuListowego(new object[0]);

                Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(ZmiennaTypuListowego), obiektListy?.GetType()));
            }

            if (WybranaZmienna == null)
            {
                Błąd = true;

                Błędy.Insert(0, new BłądZwiązanyZBrakiemWyboruZmiennej());

                return;
            }

            foreach (object element in lista)
            {
                ZresetujRekurencyjnieFlagęSkokuWPętli(this);

                if (PowódSkoku == PowódSkoku.PrzerwaniePętli)
                {
                    PowódSkoku = PowódSkoku.Brak;

                    break;
                }

                PowódSkoku = PowódSkoku.Brak;
                WybranaZmienna.Wartość = element;

                base.Wykonaj();
            }
        }
    }
}