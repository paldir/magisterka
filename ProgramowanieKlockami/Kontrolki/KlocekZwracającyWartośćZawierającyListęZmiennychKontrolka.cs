using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekZwracającyWartośćZawierającyListęZmiennychKontrolka : UserControl
    {
        public static readonly DependencyProperty ZmienneProperty = DependencyProperty.Register(
            "Zmienne", typeof (ObservableCollection<Zmienna>), typeof (KlocekZwracającyWartośćZawierającyListęZmiennychKontrolka), new PropertyMetadata(default(ObservableCollection<Zmienna>)));

        public ObservableCollection<Zmienna> Zmienne
        {
            get { return (ObservableCollection<Zmienna>) GetValue(ZmienneProperty); }
            set { SetValue(ZmienneProperty, value); }
        }
    }
}