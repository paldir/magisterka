namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public interface IOpcjaZwracającaWartość<out T> : IOpcja
    {
        T Wartość { get; }
    }
}