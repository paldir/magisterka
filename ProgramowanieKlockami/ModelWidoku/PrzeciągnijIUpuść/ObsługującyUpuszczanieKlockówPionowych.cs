using System;
using System.Collections.ObjectModel;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówPionowych : IDropTarget
    {
        private readonly Action<ManipulacjaKlockiemPionowym> _metodaZachowującaStanAplikacji;

        public ObsługującyUpuszczanieKlockówPionowych(Action<ManipulacjaKlockiemPionowym> metodaZachowującaStanAplikacji)
        {
            _metodaZachowującaStanAplikacji = metodaZachowującaStanAplikacji;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            KlocekPionowy upuszczanyKlocek = dropInfo.Data as KlocekPionowy;
            DragDropEffects efektUpuszczenia;

            if (upuszczanyKlocek == null)
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ZawartośćKlockaPionowegoZZawartością docelowaKolekcja = (ZawartośćKlockaPionowegoZZawartością) dropInfo.TargetCollection;
            KlocekPionowy upuszczanyKlocek = (KlocekPionowy) dropInfo.Data;
            upuszczanyKlocek.Rodzic = docelowaKolekcja.KlocekPionowyZZawartością;
            upuszczanyKlocek.ZPrzybornika = false;
            int indeksDocelowy = dropInfo.InsertIndex;
            IDragInfo informacjeOPrzeciągnięciu = dropInfo.DragInfo;
            ZawartośćKlockaPionowegoZZawartością źródło = informacjeOPrzeciągnięciu.SourceCollection as ZawartośćKlockaPionowegoZZawartością;
            ManipulacjaKlockiemPionowym manipulacja = new ManipulacjaKlockiemPionowym(ManipulacjeKlockiem.Dodanie, upuszczanyKlocek)
            {
                IndeksDocelowy = indeksDocelowy,
                Cel = docelowaKolekcja
            };

            if (źródło != null)
            {
                manipulacja.IndeksŹródłowy = informacjeOPrzeciągnięciu.SourceIndex;
                manipulacja.Źródło = źródło;
            }

            docelowaKolekcja.Insert(indeksDocelowy, upuszczanyKlocek);
            _metodaZachowującaStanAplikacji(manipulacja);
        }
    }
}