using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public interface IKlocekPionowyZZawartością : IKlocekPionowy, INotifyPropertyChanged
    {
        ObservableCollection<IKlocekPionowy> Zawartość { get; }
        bool Widoczny { get; }
        Komenda OdwrócenieWidoczności { get; }
    }
}