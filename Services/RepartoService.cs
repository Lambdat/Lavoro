using Lavoro.Data;
using Lavoro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Services
{
    //Implementiamo l'interfaccia specificando il tipo del Generic
    public class RepartoService : InterfaceService<Reparto>
    {
        private readonly DataContext _db;

        public RepartoService(DataContext db)
        {
            _db = db;
        }


        public Reparto Aggiungi(Reparto nuovo)
        {
            var elementoAggiunto = _db.Reparti.Add(nuovo);

            _db.SaveChanges();

            return elementoAggiunto.Entity;
        }

        public Reparto CercaPerId(int id)
        {
            var elementoTrovato = _db.Reparti.Include(dip => dip.Dipendenti).Include(dir => dir.Dirigenti).FirstOrDefault(rep => rep.Id == id);

            if(elementoTrovato is null)
            {
                throw new Exception("Reparto non Trovato");
            }

            return elementoTrovato;


        }

        



        public List<Reparto> Elenco()
        {
            //Da ef Core , questa sarebbe una inner join in Entity Framework usufruendo di Linq
            return _db.Reparti.Include(dip => dip.Dipendenti).Include(dir=>dir.Dirigenti).ToList();
        }

        public Reparto Modifica(int id, Reparto modifica)
        {
            var elementoModificato = _db.Reparti.Update(modifica);

            _db.SaveChanges();

            return elementoModificato.Entity;


        }

        public Reparto Rimuovi(int id)
        {
            var elementoEliminato = CercaPerId(id);

            _db.Remove(elementoEliminato);

            _db.SaveChanges();

            return elementoEliminato;
        }
    }
}
