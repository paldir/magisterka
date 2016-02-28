namespace ProgramowanieKlockami.ModelWidoku.Zmienne
{
    public class WartośćZmiennej : KlocekZwracającyWartość
    {
        public override string Nazwa
        {
            get { return "Wartość zmiennej"; }
        }

        public override string Opis
        {
            get { return "Zwraca wartość wybranej zmiennej."; }
        }
    }
}
