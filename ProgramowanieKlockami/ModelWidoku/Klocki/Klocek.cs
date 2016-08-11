using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class Klocek : ICloneable, INotifyPropertyChanged, IXmlSerializable
    {
        private bool _aktywny;
        private bool _błąd;
        private ObservableCollection<BłądKlocka> _błędy;
        private Brush _kolor;
        private Brush _kolorObramowania;
        private bool _posiadaSkupienie;

        protected abstract WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące { get; }

        public abstract string Nazwa { get; }
        public abstract string Opis { get; }

        public Brush KolorPierwotny { get; private set; }
        public bool ZPrzybornika { get; set; }

        public bool Aktywny
        {
            get { return _aktywny; }

            set
            {
                _aktywny = value;

                OnPropertyChanged();
            }
        }

        public bool Błąd
        {
            get { return _błąd; }

            set
            {
                _błąd = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<BłądKlocka> Błędy
        {
            get { return _błędy; }

            protected set
            {
                _błędy = value;

                OnPropertyChanged();
            }
        }

        public Brush Kolor
        {
            get { return _kolor; }

            protected set
            {
                if (KolorObramowania == null)
                    KolorObramowania = value;

                if (KolorPierwotny == null)
                    KolorPierwotny = value;

                _kolor = value;

                OnPropertyChanged();
            }
        }

        public Brush KolorObramowania
        {
            get { return _kolorObramowania; }

            set
            {
                _kolorObramowania = value;

                OnPropertyChanged();
            }
        }

        public bool PosiadaSkupienie
        {
            get { return _posiadaSkupienie; }

            set
            {
                _posiadaSkupienie = value;
                //KolorObramowania = PosiadaSkupienie ? Kolory.Skupienie : Kolor;
                KolorObramowania = Kolor;

                OnPropertyChanged();
            }
        }

        protected Klocek()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            PosiadaSkupienie = false;
        }

        protected void SprawdźPoprawnośćKlockówKonfigurujących()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            Błąd = false;

            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćWewnętrznegoKlockaZwracającegoWartość in KlockiKonfigurujące)
            {
                Type oczekiwanyTyp = wartośćWewnętrznegoKlockaZwracającegoWartość.PrzyjmowanyTyp;
                Type umieszczonyTyp = wartośćWewnętrznegoKlockaZwracającegoWartość[0]?.Zwróć<object>(true)?.GetType();

                if (!oczekiwanyTyp.IsAssignableFrom(umieszczonyTyp))
                {
                    Błąd = true;

                    Application.Current.Dispatcher.Invoke(delegate { Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(oczekiwanyTyp, umieszczonyTyp)); });
                }
            }
        }

        public virtual object Clone()
        {
            return Activator.CreateInstance(GetType());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(GetType().FullName);

            foreach (PropertyInfo właściwość in GetType().GetProperties().OrderBy(w => w.Name))
            {
                Type typWłaściwości = właściwość.PropertyType;
                object wartośćWłaściwości = właściwość.GetValue(this);

                if (wartośćWłaściwości != null)
                {
                    writer.WriteStartElement(właściwość.Name);

                    if (właściwość.GetSetMethod() == null)
                    {
                        if (typWłaściwości == typeof(WartośćWewnętrznegoKlockaZwracającegoWartość))
                        {
                            WartośćWewnętrznegoKlockaZwracającegoWartość wartość = (WartośćWewnętrznegoKlockaZwracającegoWartość) wartośćWłaściwości;

                            wartość[0]?.WriteXml(writer);
                        }
                        else if (typWłaściwości == typeof(ZawartośćKlockaPionowegoZZawartością))
                        {
                            ZawartośćKlockaPionowegoZZawartością zawartość = (ZawartośćKlockaPionowegoZZawartością) wartośćWłaściwości;

                            foreach (KlocekPionowy klocekPionowy in zawartość)
                                klocekPionowy.WriteXml(writer);
                        }
                    }
                    else
                    {
                        if (typWłaściwości == typeof(KlocekPionowyZZawartością))
                        {

                        }
                        else if (typWłaściwości == typeof(Semafor))
                        {

                        }
                        else if (typWłaściwości == typeof(WartośćWewnętrznegoKlockaZwracającegoWartość))
                        {

                        }
                        else if (typWłaściwości == typeof(Zmienna))
                        {
                            Zmienna zmienna = (Zmienna) wartośćWłaściwości;

                            writer.WriteString(zmienna.Nazwa);
                        }
                        else
                            writer.WriteString(wartośćWłaściwości.ToString());
                    }

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
        }
    }
}