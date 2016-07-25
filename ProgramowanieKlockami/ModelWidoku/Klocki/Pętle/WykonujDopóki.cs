using System.Collections.ObjectModel;
using System.Windows;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class WykonujDopóki : KlocekPionowyZZawartościąPrzyjmującyWartość, IPętla
    {
        public override string Nazwa => "Pętla dopóki";
        public override string Opis => "Dopóki wartość jest prawdziwa, wykonuje instrukcje.";

        public PowódSkoku PowódSkoku { get; set; }

        public WykonujDopóki() : base(typeof(bool))
        {
            Kolor = Kolory.Pętle;
        }

        public override void Wykonaj()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            Błąd = false;

            while (true)
            {
                object obiektWarunku = Wartość[0]?.Zwróć<object>();

                if (!(obiektWarunku is bool))
                {
                    Błąd = true;

                    //      !!!
                    //      !!!
                    //      !!!
                    Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(bool), obiektWarunku?.GetType())); });
                    //      !!!
                    //      !!!
                    //      !!!

                    break;
                }

                if (!(bool) obiektWarunku)
                    break;

                ZresetujRekurencyjnieFlagęSkokuWPętli(this);

                if (PowódSkoku == PowódSkoku.PrzerwaniePętli)
                {
                    PowódSkoku = PowódSkoku.Brak;

                    break;
                }

                PowódSkoku = PowódSkoku.Brak;

                base.Wykonaj();
            }
        }
    }
}