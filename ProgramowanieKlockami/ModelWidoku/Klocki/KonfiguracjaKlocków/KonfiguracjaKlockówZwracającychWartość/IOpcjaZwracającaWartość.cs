namespace ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość
{
    public interface IOpcjaZwracającaWartość<out T> : IOpcja
    {
        T Wartość { get; }
    }
}