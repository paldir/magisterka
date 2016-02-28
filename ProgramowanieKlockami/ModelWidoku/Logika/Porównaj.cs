namespace ProgramowanieKlockami.ModelWidoku.Logika
{
    public class Porównaj : KlocekZwracającyWartość
    {
        public override string Nazwa
        {
            get { return "Porównaj"; }
        }

        public override string Opis
        {
            get { return "Zwraca prawdę, jeśli oba wejścia są takie same."; }
        }
    }
}
