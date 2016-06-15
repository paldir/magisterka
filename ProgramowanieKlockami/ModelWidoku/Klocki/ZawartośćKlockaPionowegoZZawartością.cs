using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public class ZawartośćKlockaPionowegoZZawartością : ObservableCollection<KlocekPionowy>
    {
        public KlocekPionowyZZawartością KlocekPionowyZZawartością { get; set; }
    }
}