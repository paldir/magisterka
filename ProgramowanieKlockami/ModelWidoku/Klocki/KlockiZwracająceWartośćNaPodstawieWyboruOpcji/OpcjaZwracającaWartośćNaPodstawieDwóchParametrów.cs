namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class OpcjaZwracającaWartośćNaPodstawieDwóchParametrów<TZwracanaWartość, TParametr1, TParametr2> : Opcja
    {
        public abstract TZwracanaWartość Zwróć(TParametr1 a, TParametr2 b);
    }
}