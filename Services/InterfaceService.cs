using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Services
{
    public interface InterfaceService<T>
    {
        public List<T> Elenco();

        public T CercaPerId(int id);

        public T Rimuovi(int id);

        public T Modifica(int id,T modifica);

        public T Aggiungi(T nuovo);

    }
}
