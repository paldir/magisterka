﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;
using ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public IEnumerable<IKlocek> KlockiLogiczne { get; }
        public IEnumerable<IKlocek> KlockiTekstowe { get; }
        public IEnumerable<IKlocek> KlockiDotycząceZmiennych { get; }
        public ObsługującyUpuszczanieKlockówPionowych ObsługującyUpuszczanieKlockówPionowych { get; }

        private string _nazwaNowejZmiennej;

        public string NazwaNowejZmiennej
        {
            get { return _nazwaNowejZmiennej; }

            set
            {
                _nazwaNowejZmiennej = value;

                OnPropertyChanged();
            }
        }

        private double _powiększenie;

        public double Powiększenie
        {
            get { return _powiększenie; }

            set
            {
                _powiększenie = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Główny()
        {
            KlockiLogiczne = new IKlocek[]
            {
                new Jeżeli(),
                new Porównanie()
            };

            KlockiTekstowe = new IKlocek[]
            {
                new Napis(),
                new Wyświetl()
            };

            KlockiDotycząceZmiennych = new IKlocek[]
            {
                new UstawZmienną(),
                new WartośćZmiennej()
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            Powiększenie = 1;
            ObsługującyUpuszczanieKlockówPionowych = new ObsługującyUpuszczanieKlockówPionowych();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) {Nazwa = NazwaNowejZmiennej});

                NazwaNowejZmiennej = null;
            }
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = (Zmienna) zmiennaDoUsunięcia;

            Zmienne.Remove(zmienna);
        }
    }
}