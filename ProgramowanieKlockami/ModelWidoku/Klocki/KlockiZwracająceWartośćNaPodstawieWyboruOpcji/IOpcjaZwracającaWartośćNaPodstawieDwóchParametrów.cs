namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public interface IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<out TZwracanaWartość, in TParametr> : IOpcja
    {
        TZwracanaWartość Zwróć(TParametr a, TParametr b);
    }
}