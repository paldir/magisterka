namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public interface IOpcjaZwracającaWartośćNaPodstawieParametru<out TZwracanaWartość, in TParametr> : IOpcja
    {
        TZwracanaWartość Zwróć(TParametr x);
    }
}