namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public interface IOpcjaZwracającaWartośćNaPodstawieDwóchParametrów<out TZwracanaWartość, in TParametr1, in TParametr2> : IOpcja
    {
        TZwracanaWartość Zwróć(TParametr1 a, TParametr2 b);
    }
}