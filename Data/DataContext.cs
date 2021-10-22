using Lavoro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Data
{
    public class DataContext : DbContext
    {
        //Costruttore che passa al costruttore della classe padre l oggetto di tipo DbContextOptions
        public DataContext( DbContextOptions<DataContext> opzioni) : base (opzioni)
        {

        }



        //Con i DbSet definiamo effettivamente le nostre tabelle con relazioni 1-N
        public DbSet<Dipendente> Dipendenti { get; set; } //create table dipendenti(proprietà del modello) con EF
        public DbSet<Dirigente> Dirigenti { get; set; }
        public DbSet<Reparto> Reparti { get; set; }


    }
}
