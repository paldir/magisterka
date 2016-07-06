namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.TypyModyfikacjiElementuListy
{
    public interface ITypUstawieniaElementuListy
    {
        string ReprezentacjaTekstowa { get; }

        void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość);
    }
}