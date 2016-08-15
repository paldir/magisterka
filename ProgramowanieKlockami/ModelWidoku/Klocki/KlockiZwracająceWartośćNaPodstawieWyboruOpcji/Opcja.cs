namespace ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji
{
    public abstract class Opcja
    {
        public abstract string ReprezentacjaTekstowa { get; }

        public override bool Equals(object obj) => GetType() == obj.GetType();
        public override int GetHashCode() => ReprezentacjaTekstowa[0];
    }
}