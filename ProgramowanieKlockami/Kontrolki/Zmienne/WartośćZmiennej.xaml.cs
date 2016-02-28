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
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki.Zmienne
{
    /// <summary>
    /// Interaction logic for WartośćZmiennej.xaml
    /// </summary>
    public partial class WartośćZmiennej : UserControl
    {
        public static readonly DependencyProperty ZmienneProperty = DependencyProperty.Register(
            "Zmienne", typeof (ObservableCollection<Zmienna>), typeof (WartośćZmiennej), new PropertyMetadata(default(ObservableCollection<Zmienna>)));

        public ObservableCollection<Zmienna> Zmienne
        {
            get { return (ObservableCollection<Zmienna>) GetValue(ZmienneProperty); }
            set { SetValue(ZmienneProperty, value); }
        }

        public WartośćZmiennej()
        {
            InitializeComponent();
        }
    }
}