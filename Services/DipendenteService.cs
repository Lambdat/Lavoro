using Lavoro.Data;
using Lavoro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Services
{
    //Implementiamo l'interfaccia specificando il tipo del Generic
    public class DipendenteService : InterfaceService<Dipendente>
    {
        //Creiamo un campo private di tipo DataContext 
        private readonly DataContext _db;

        //Metodo Costruttore
        public DipendenteService(DataContext db)
        {
            _db = db;
        }


        public List<Dipendente> Elenco()
        {
            return _db.Dipendenti.ToList();
        }

        public Dipendente CercaPerId(int id)
        {
            var elementoTrovato = _db.Dipendenti.FirstOrDefault(dipendenti => dipendenti.Id == id);

            if(elementoTrovato is null)
            {
                throw new Exception("Nessun Dipendente esistente avente Id: "+id);
            }

            return elementoTrovato;


        }

        public List<Dipendente> CercaPerCognome(string cognome)
        {
            var elementiTrovati = _db.Dipendenti.Where(dip => dip.Cognome == cognome).ToList();

            if(elementiTrovati is null)
            {
                throw new Exception($"Dipendenti di Cognome '{cognome}' non trovati");
            }

            return elementiTrovati;
        }




        public Dipendente Rimuovi(int id)
        {
           
            var elementoDaRimuovere=_db.Dipendenti.Remove(CercaPerId(id));

            _db.SaveChanges();

            return elementoDaRimuovere.Entity; //.Entity a causa del var
        }

        public Dipendente Modifica(int id, Dipendente modifica)
        {

            var elemntoDaModificare=_db.Dipendenti.Update(modifica);

            _db.SaveChanges();

            return elemntoDaModificare.Entity; // return Dipendente dipendenteDaModificare

        }

        public Dipendente Aggiungi(Dipendente nuovo)
        {
            var dipendenteAggiunto=_db.Dipendenti.Add(nuovo);

            _db.SaveChanges();

            return dipendenteAggiunto.Entity; // return Dipendente dipendenteAggiunto
        }











    }
}
