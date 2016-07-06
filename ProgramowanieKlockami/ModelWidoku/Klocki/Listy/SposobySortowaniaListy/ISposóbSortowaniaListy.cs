namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SposobySortowaniaListy
{
    public interface ISposóbSortowaniaListy
    {
        string ReprezentacjaTekstowa { get; }

        ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco);
    }
}