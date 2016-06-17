using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Fałsz : IOpcjaZwracającaWartość<bool>
    {
        public string ReprezentacjaTekstowa => "fałsz";
        public bool Wartość => false;
    }
}