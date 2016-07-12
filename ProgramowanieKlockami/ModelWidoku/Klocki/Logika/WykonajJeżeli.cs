namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class WykonajJeżeli : KlocekPionowyZZawartościąPrzyjmującyWartość
    {
        public override string Nazwa => "Jeżeli";
        public override string Opis => "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";

        public ZawartośćKlockaPionowegoZZawartością AlternatywnaZawartość { get; }

        public WykonajJeżeli() : base(typeof(bool))
        {
            AlternatywnaZawartość = new ZawartośćKlockaPionowegoZZawartością();
            Kolor = Kolory.Logika;
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość klocekZwracającyWartość = Wartość[0];

            if (klocekZwracającyWartość == null)
                return;

            bool wartośćWarunku = klocekZwracającyWartość.Zwróć<bool>();

            if (wartośćWarunku)
                base.Wykonaj();
            else
                foreach (KlocekPionowy klocekPionowy in AlternatywnaZawartość)
                    if (SkokPętli)
                        break;
                    else
                        klocekPionowy.Wykonaj();
        }
    }
}