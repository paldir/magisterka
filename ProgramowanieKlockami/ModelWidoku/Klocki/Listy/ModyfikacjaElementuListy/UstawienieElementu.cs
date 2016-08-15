namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy
{
    public class UstawienieElementu : TypUstawieniaElementuListy
    {
        public override string ReprezentacjaTekstowa => "ustaw element o nr";

        public override void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość)
        {
            for (int i = lista.Count - 1; i < indeks; i++)
                lista.Add(null);

            if (indeks >= 0)
                lista[indeks] = wartość;
        }
    }
}