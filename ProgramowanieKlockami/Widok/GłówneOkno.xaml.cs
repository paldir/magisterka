using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using ProgramowanieKlockami.ModelWidoku;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ProgramowanieKlockami.Widok
{
    /// <summary>
    /// Interaction logic for GłówneOkno.xaml
    /// </summary>
    public partial class GłówneOkno
    {
        private Główny ModelWidoku => (Główny) DataContext;

        public GłówneOkno()
        {
            InitializeComponent();

            InputBindings.Add(new KeyBinding(new Komenda(Nowy_OnClick), Key.N, ModifierKeys.Control));
            InputBindings.Add(new KeyBinding(new Komenda(Otwórz_OnClick), Key.O, ModifierKeys.Control));
            InputBindings.Add(new KeyBinding(new Komenda(Zapisz_OnClick), Key.S, ModifierKeys.Control));
        }

        private void Czyść()
        {
            ModelWidoku.RozpoczęcieProgramu.Zawartość.Clear();
            ModelWidoku.Zmienne.Clear();
            ModelWidoku.MagazynZmian.Wyczyść();
        }

        private void GłówneOkno_OnClosing(object sender, CancelEventArgs e)
        {
            if (ModelWidoku.Debugowanie)
                return;

            if (!OstrzeżenieOUtracie())
                e.Cancel = true;
        }

        private void Nowy_OnClick()
        {
            Nowy_OnClick(null, null);
        }

        private void Nowy_OnClick(object sender, RoutedEventArgs e)
        {
            if (ModelWidoku.Debugowanie)
                return;

            if (!OstrzeżenieOUtracie())
                return;

            ModelWidoku.ŚcieżkaPliku = null;
            Title = "Praca magisterska";

            Czyść();
        }

        private bool OstrzeżenieOUtracie()
        {
            DialogResult wybór = MessageBox.Show(@"Czy chcesz wcześniej zapisać zmiany?", string.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (wybór)
            {
                case System.Windows.Forms.DialogResult.Cancel:
                    return false;

                case System.Windows.Forms.DialogResult.Yes:
                    Zapisz_OnClick(null, null);

                    break;
            }

            return true;
        }

        private void Otwórz_OnClick()
        {
            Otwórz_OnClick(null, null);
        }

        private void Otwórz_OnClick(object sender, RoutedEventArgs e)
        {
            if (ModelWidoku.Debugowanie)
                return;

            if (!OstrzeżenieOUtracie())
                return;

            OpenFileDialog okno = new OpenFileDialog
            {
                DefaultExt = "mgr",
                Filter = @"Pliki projektu pracy mgr | *.mgr"
            };

            if (okno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Czyść();

                string ścieżkaPliku = okno.FileName;
                ModelWidoku.ŚcieżkaPliku = ścieżkaPliku;
                Title = $"Praca magisterska - {Path.GetFileName(ścieżkaPliku)}";
                XDocument dokumentXml = XDocument.Load(ścieżkaPliku);
                XElement[] węzły = dokumentXml.Elements().Elements().ToArray();
                ObservableCollection<Zmienna> zmienne = ModelWidoku.Zmienne;
                RozpoczęcieProgramu głównaFunkcja = ModelWidoku.RozpoczęcieProgramu;

                foreach (XElement zmienna in węzły.Single(w => w.Name == "Zmienne").Elements())
                    zmienne.Add(new Zmienna(zmienne) {Nazwa = zmienna.Value});

                IEnumerable<XElement> klockiWewnętrzne = węzły.Single(w => w.Name == "Klocki").Element(typeof(RozpoczęcieProgramu).FullName)?.Element("Zawartość")?.Elements();

                if (klockiWewnętrzne != null)
                {
                    foreach (XElement węzełKlockaPionowego in klockiWewnętrzne)
                    {
                        Type typKlockaPionowego = Type.GetType(węzełKlockaPionowego.Name.LocalName);

                        if (typKlockaPionowego != null)
                        {
                            KlocekPionowy klocekPionowy = (KlocekPionowy) Activator.CreateInstance(typKlockaPionowego);
                            klocekPionowy.Rodzic = głównaFunkcja;

                            klocekPionowy.PrzeczytajZXml(węzełKlockaPionowego, ModelWidoku.Konsola, ModelWidoku.Semafor, zmienne);
                            głównaFunkcja.Zawartość.Add(klocekPionowy);
                        }
                    }

                    głównaFunkcja.Semafor = ModelWidoku.Semafor;
                }
            }
        }

        private void Zapisz()
        {
            string ścieżkaPliku = ModelWidoku.ŚcieżkaPliku;

            if (!string.IsNullOrEmpty(ścieżkaPliku))
            {
                XmlWriterSettings ustawieniaXml = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = true
                };

                using (StreamWriter strumień = new StreamWriter(new FileStream(ścieżkaPliku, FileMode.Create, FileAccess.Write), Encoding.UTF8))
                using (XmlWriter pisarz = XmlWriter.Create(strumień, ustawieniaXml))
                {
                    pisarz.WriteStartDocument();
                    pisarz.WriteStartElement("Projekt");

                    pisarz.WriteStartElement("Zmienne");

                    foreach (Zmienna zmienna in ModelWidoku.Zmienne)
                        pisarz.WriteElementString("Zmienna", zmienna.Nazwa);

                    pisarz.WriteEndElement();

                    pisarz.WriteStartElement("Klocki");
                    ModelWidoku.RozpoczęcieProgramu.ZapiszJakoXml(pisarz);
                    pisarz.WriteEndElement();
                    pisarz.WriteEndElement();
                    pisarz.WriteEndDocument();
                }
            }
        }

        private void Zapisz_OnClick()
        {
            Zapisz_OnClick(null, null);
        }

        private void Zapisz_OnClick(object sender, RoutedEventArgs e)
        {
            if (ModelWidoku.Debugowanie)
                return;

            if (File.Exists(ModelWidoku.ŚcieżkaPliku))
                Zapisz();
            else
                ZapiszJako_OnClick(null, null);
        }

        private void ZapiszJako_OnClick(object sender, RoutedEventArgs e)
        {
            if (ModelWidoku.Debugowanie)
                return;

            SaveFileDialog okno = new SaveFileDialog
            {
                DefaultExt = "mgr",
                Filter = @"Pliki projektu pracy magisterskiej | *.mgr"
            };

            if (okno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ścieżkaPliku = okno.FileName;
                ModelWidoku.ŚcieżkaPliku = ścieżkaPliku;
                Title = $"Praca magisterska - {Path.GetFileName(ścieżkaPliku)}";

                Zapisz();
            }
        }
    }
}