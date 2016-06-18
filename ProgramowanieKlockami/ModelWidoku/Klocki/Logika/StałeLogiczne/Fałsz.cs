using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Fałsz : IOpcjaZwracającaWartość<bool>
    {
        public string ReprezentacjaTekstowa => "fałsz";
        public bool Wartość => false;
    }
}