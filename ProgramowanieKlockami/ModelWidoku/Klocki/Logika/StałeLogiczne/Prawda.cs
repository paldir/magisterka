using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Prawda : IOpcjaZwracającaWartość<bool>
    {
        public string ReprezentacjaTekstowa => "prawda";
        public bool Wartość => true;
    }
}