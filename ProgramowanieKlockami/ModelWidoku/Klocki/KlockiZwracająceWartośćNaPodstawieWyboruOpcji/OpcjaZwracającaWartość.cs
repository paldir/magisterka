namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class OpcjaZwracającaWartość<T> : Opcja
    {
        public abstract T Wartość { get; }
    }
}