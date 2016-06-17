namespace ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość
{
    public interface IOpcjaZwracającaWartośćNaPodstawieParametru<out TZwracanaWartość, in TParametr> : IOpcja
    {
        TZwracanaWartość Zwróć(TParametr x);
    }
}