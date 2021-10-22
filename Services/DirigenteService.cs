using Lavoro.Data;
using Lavoro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Services
{
    //Implementiamo l'interfaccia specificando il tipo del Generic
    public class DirigenteService : InterfaceService<Dirigente>
    {
        //Creiamo un campo private di tipo DataContext 
        private readonly DataContext _db;

        //Metodo Costruttore
        public DirigenteService(DataContext db)
        {
            _db = db;
        }


        public List<Dirigente> Elenco()
        {
            return _db.Dirigenti.ToList();
        }

        public Dirigente CercaPerId(int id)
        {
            var elementoTrovato = _db.Dirigenti.FirstOrDefault(dipendenti => dipendenti.Id == id);

            if (elementoTrovato is null)
            {
                throw new Exception("Nessun Dirigente esistente avente Id: " + id);
            }

            return elementoTrovato;


        }

        public Dirigente Rimuovi(int id)
        {

            var elementoDaRimuovere = _db.Dirigenti.Remove(CercaPerId(id));

            _db.SaveChanges();

            return elementoDaRimuovere.Entity; //.Entity a causa del var
        }

        public Dirigente Modifica(int id, Dirigente modifica)
        {

            var elemntoDaModificare = _db.Dirigenti.Update(modifica);

            _db.SaveChanges();

            return elemntoDaModificare.Entity; // return Dirigente DirigenteDaModificare

        }

        public Dirigente Aggiungi(Dirigente nuovo)
        {
            var elementoAggiunto = _db.Dirigenti.Add(nuovo);

            _db.SaveChanges();

            return elementoAggiunto.Entity; // return Dirigente DirigenteAggiunto
        }
    }
}
