namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class OpcjaZwracającaWartośćNaPodstawieParametru<TZwracanaWartość, TParametr> : Opcja
    {
        public abstract TZwracanaWartość Zwróć(TParametr x);
    }
}