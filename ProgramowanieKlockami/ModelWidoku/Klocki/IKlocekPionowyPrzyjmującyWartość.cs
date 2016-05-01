using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public interface IKlocekPionowyPrzyjmującyWartość : IKlocekPionowy
    {
        ObservableCollection<IKlocekZwracającyWartość> Wartość { get; }
    }
}