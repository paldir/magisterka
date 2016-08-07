using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika.ZnakiPorównania;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<bool, object, object>
    {
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public Porównanie()
        {
            Kolor = Kolory.Logika;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            if (Wartość1.Zwróć<object>().GetType() == Wartość2.Zwróć<object>().GetType())
                return base.ZwróćNiebezpiecznie(sprawdzanieBłędów);

            return WybranaOpcja is Nierówny;
        }
    }
}