using System;
using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        protected abstract WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące { get; }

        public abstract Type ZwracanyTyp { get; }

        public WartośćWewnętrznegoKlockaZwracającegoWartość MiejsceUmieszczenia { get; set; }

        private object Zwróć()
        {
            BłędyKonfiguracji = new ObservableCollection<BłądKonfiguracjiKlocka>();

            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlocka in KlockiKonfigurujące)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlocka[0];
                Type przyjmowanyTyp = wartośćKlocka.PrzyjmowanyTyp;

                if (klocekZwracającyWartość == null)
                    BłędyKonfiguracji.Add(new BłądKonfiguracjiKlocka {OczekiwanyTyp = przyjmowanyTyp});
                else
                {
                    object zwróconaWartość = klocekZwracającyWartość.Zwróć();
                    Type typZwróconejWartości = zwróconaWartość?.GetType();

                    if (!wartośćKlocka.PrzyjmowanyTyp.IsAssignableFrom(typZwróconejWartości))
                        BłędyKonfiguracji.Add(new BłądKonfiguracjiKlocka
                        {
                            OczekiwanyTyp = przyjmowanyTyp,
                            UmieszczonyTyp = typZwróconejWartości
                        });
                }
            }

            if (BłędyKonfiguracji.Count == 0)
            {
                Błąd = false;

                return ZwróćNiebezpiecznie();
            }

            Błąd = true;

            return ZwracanyTyp == typeof(object) ? string.Empty : Activator.CreateInstance(ZwracanyTyp);
        }

        protected abstract object ZwróćNiebezpiecznie();

        public T Zwróć<T>()
        {
            object zwróconaWartość = Zwróć();
            Type typDocelowy = typeof(T);

            if (zwróconaWartość != null)
            {
                if (typDocelowy.IsInstanceOfType(zwróconaWartość))
                    return (T) zwróconaWartość;

                try
                {
                    return (T) Convert.ChangeType(zwróconaWartość, typDocelowy);
                }
                catch (InvalidCastException)
                {
                }
            }

            Błąd = true;

            return Activator.CreateInstance<T>();
        }
    }
}