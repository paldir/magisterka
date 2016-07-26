using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public abstract Type ZwracanyTyp { get; }

        public WartośćWewnętrznegoKlockaZwracającegoWartość MiejsceUmieszczenia { get; set; }

        private object Zwróć()
        {
            SprawdźPoprawność();

            if (Błąd)
                return ZwracanyTyp == typeof(object) ? string.Empty : Activator.CreateInstance(ZwracanyTyp);

            return ZwróćNiebezpiecznie();
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
                catch (Exception)
                {
                }
            }

            return Activator.CreateInstance<T>();
        }
    }
}