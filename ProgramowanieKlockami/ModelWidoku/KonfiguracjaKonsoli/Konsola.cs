using System.Collections.ObjectModel;
using System.Windows;

namespace ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli
{
    public class Konsola
    {
        public ObservableCollection<LiniaKonsoli> LinieKonsoli { get; }

        public bool CzekaNaUżytkownika { get; set; }

        public Konsola()
        {
            LinieKonsoli = new ObservableCollection<LiniaKonsoli>();
        }

        public void DodajLinię(string linia)
        {
            Application.Current.Dispatcher.Invoke(delegate { LinieKonsoli.Add(new LiniaKonsoli {Zawartość = linia}); });
        }

        public void DodajPoleTekstowe()
        {
            Application.Current.Dispatcher.Invoke(delegate { LinieKonsoli.Add(new LiniaKonsoli {Edytowalna = true}); });
        }
    }
}