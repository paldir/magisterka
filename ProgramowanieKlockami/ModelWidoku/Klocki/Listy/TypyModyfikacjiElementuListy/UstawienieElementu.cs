namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.TypyModyfikacjiElementuListy
{
    public class UstawienieElementu : ITypUstawieniaElementuListy
    {
        public string ReprezentacjaTekstowa => "ustaw element o nr";

        public void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość)
        {
            for (int i = lista.Count - 1; i < indeks; i++)
                lista.Add(null);

            if (indeks >= 0)
                lista[indeks] = wartość;
        }
    }
}