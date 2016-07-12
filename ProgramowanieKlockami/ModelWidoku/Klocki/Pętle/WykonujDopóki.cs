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
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if (klocekZwracającyWartość == null)
                return;

            while (klocekZwracającyWartość.Zwróć<bool>())
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