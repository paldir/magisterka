namespace ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość
{
    public interface IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<out TZwracanaWartość, in TParametr> : IOpcja
    {
        TZwracanaWartość Zwróć(TParametr a, TParametr b);
    }
}