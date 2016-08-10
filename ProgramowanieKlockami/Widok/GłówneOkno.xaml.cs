using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using ProgramowanieKlockami.ModelWidoku;
using ProgramowanieKlockami.ModelWidoku.Klocki;

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
        }

        private void Nowy_OnClick(object sender, RoutedEventArgs e)
        {
            ModelWidoku.ŚcieżkaPliku = null;

            ModelWidoku.RozpoczęcieProgramu.Zawartość.Clear();
            ModelWidoku.Zmienne.Clear();
            ModelWidoku.MagazynZmian.Wyczyść();
        }

        private void Otwórz_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog okno = new OpenFileDialog();

            okno.ShowDialog();

            ModelWidoku.ŚcieżkaPliku = okno.FileName;
        }

        private void Zapisz_OnClick(object sender, RoutedEventArgs e)
        {
            string ścieżkaPliku = ModelWidoku.ŚcieżkaPliku;

            if (!File.Exists(ścieżkaPliku))
            {
                SaveFileDialog okno = new SaveFileDialog {FileName = "test"};

                if (okno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ścieżkaPliku = okno.FileName;
            }

            if (!string.IsNullOrEmpty(ścieżkaPliku))
            {
                XmlWriterSettings ustawieniaXml = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = true
                };

                using (StreamWriter strumień = new StreamWriter(ścieżkaPliku))
                using (XmlWriter pisarz = XmlWriter.Create(strumień, ustawieniaXml))
                {
                    ModelWidoku.ŚcieżkaPliku = ścieżkaPliku;

                    pisarz.WriteStartDocument();
                    pisarz.WriteStartElement("Projekt");
                    ModelWidoku.RozpoczęcieProgramu.WriteXml(pisarz);
                    pisarz.WriteEndElement();
                    pisarz.WriteEndDocument();
                }
            }
        }

        private void ZapiszJako_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /*private XElement Serializuj()
        {
            XElement root = new XElement(XName.Get("Projekt"));


            return root;
        }

        private static void SerializujKlocki(XContainer węzeł, KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            foreach (KlocekPionowy klocekPionowy in klocekPionowyZZawartością.Zawartość)
            {
                Type typKlockaPionowego = klocekPionowy.GetType();
                XName nazwaKlockaPionowego = XName.Get(typKlockaPionowego.FullName);
                XElement węzełKlockaPionowego = new XElement(nazwaKlockaPionowego);
                KlocekPionowyZZawartością wewnętrznyKlocekPionowyZZawartością = klocekPionowy as KlocekPionowyZZawartością;
                List<XElement> właściwościKlocka = new List<XElement>();
                var xmlKlockaPionowego=klocekPionowy.WriteXml()

                węzełKlockaPionowego.Add(właściwościKlocka);

                if (wewnętrznyKlocekPionowyZZawartością != null)
                    SerializujKlocki(węzełKlockaPionowego, wewnętrznyKlocekPionowyZZawartością);

                węzeł.Add(węzełKlockaPionowego);
            }
        }*/
    }
}