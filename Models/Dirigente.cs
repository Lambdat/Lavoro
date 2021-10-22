using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Models
{
    public class Dirigente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime Dob { get; set; }
        public double Stipendio { get; set; }
      
        public int RepartoId { get; set; } //Chive Esterna
    }
}
