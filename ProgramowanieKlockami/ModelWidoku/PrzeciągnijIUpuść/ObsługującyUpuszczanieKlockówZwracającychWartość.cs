using System;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówZwracającychWartość : IDropTarget
    {
        private readonly Action<ManipulacjaKlockiem> _metodaZachowującaStanAplikacji;

        public ObsługującyUpuszczanieKlockówZwracającychWartość(Action<ManipulacjaKlockiem> metodaZachowującaStanAplikacji)
        {
            _metodaZachowującaStanAplikacji = metodaZachowującaStanAplikacji;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            KlocekZwracającyWartość upuszczanyKlocek = dropInfo.Data as KlocekZwracającyWartość;
            WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlockaPrzyjmującegoWartość = (WartośćWewnętrznegoKlockaZwracającegoWartość) dropInfo.TargetCollection;
            DragDropEffects efektUpuszczenia;
            Type zwracanyTyp = upuszczanyKlocek?.ZwracanyTyp;

            if ((upuszczanyKlocek != null) && ((zwracanyTyp == null) || wartośćKlockaPrzyjmującegoWartość.PrzyjmowanyTyp.IsAssignableFrom(zwracanyTyp)))
            {
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            }
            else
                efektUpuszczenia = DragDropEffects.None;

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            WartośćWewnętrznegoKlockaZwracającegoWartość docelowaKolekcja = (WartośćWewnętrznegoKlockaZwracającegoWartość) dropInfo.TargetCollection;
            KlocekZwracającyWartość upuszczanyKlocek = (KlocekZwracającyWartość) dropInfo.Data;
            upuszczanyKlocek.MiejsceUmieszczenia = docelowaKolekcja;
            upuszczanyKlocek.ZPrzybornika = false;
            docelowaKolekcja[0] = upuszczanyKlocek;
            ManipulacjaKlockiemZwracającymWartość manipulacja = new ManipulacjaKlockiemZwracającymWartość(ManipulacjeKlockiem.Dodanie, upuszczanyKlocek) {Cel = docelowaKolekcja};
            WartośćWewnętrznegoKlockaZwracającegoWartość źródło = dropInfo.DragInfo.SourceCollection as WartośćWewnętrznegoKlockaZwracającegoWartość;

            if (źródło != null)
                manipulacja.Źródło = źródło;

            _metodaZachowującaStanAplikacji(manipulacja);
        }
    }
}