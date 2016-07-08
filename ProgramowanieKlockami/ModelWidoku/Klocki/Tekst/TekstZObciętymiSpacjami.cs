using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class TekstZObciętymiSpacjami : KlocekZwracającyWartośćNaPodstawieOpcjiIParametru<object, object>
    {
        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Tekst z obciętymi spacjami";
        public override string Opis => "Zwraca kopię tekstu z obciętymi spacjami z jednego lub obu końców.";
    }
}