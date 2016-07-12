using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class TekstZObciętymiSpacjami : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<object, object>
    {
        public override string Nazwa => "Tekst z obciętymi spacjami";
        public override string Opis => "Zwraca kopię tekstu z obciętymi spacjami z jednego lub obu końców.";

        public TekstZObciętymiSpacjami()
        {
            Kolor = Kolory.Tekst;
        }
    }
}