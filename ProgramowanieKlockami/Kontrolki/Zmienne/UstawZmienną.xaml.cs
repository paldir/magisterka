using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramowanieKlockami.Kontrolki.Zmienne
{
    /// <summary>
    /// Interaction logic for UstawZmienną.xaml
    /// </summary>
    public partial class UstawZmienną : KlocekPionowyPrzyjmującyWartośćKontrolka
    {
        public static readonly DependencyProperty ZmienneProperty = DependencyProperty.Register(
            "Zmienne", typeof (ObservableCollection<string>), typeof (UstawZmienną), new PropertyMetadata(default(ObservableCollection<string>)));

        public ObservableCollection<string> Zmienne
        {
            get { return (ObservableCollection<string>) GetValue(ZmienneProperty); }
            set { SetValue(ZmienneProperty, value); }
        }
        
        public UstawZmienną()
        {
            InitializeComponent();
        }
    }
}
