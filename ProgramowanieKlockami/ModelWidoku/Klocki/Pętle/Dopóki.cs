using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class Dopóki : KlocekPionowyZZawartościąPrzyjmującyWartość, IPętla
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Pętla dopóki";
        public override string Opis => "Dopóki wartość jest prawdziwa, wykonuje instrukcje.";

        public PowódSkoku PowódSkoku { get; set; }

        public Dopóki() : base(typeof(bool))
        {
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość wartość = Wartość[0];

            if (wartość?.Zwróć() is bool)
                while ((bool) wartość.Zwróć())
                {
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