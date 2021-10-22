using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Models
{
    public class Reparto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Dipendente> Dipendenti { get; set; }
        public List<Dirigente> Dirigenti { get; set; }
    }
}
