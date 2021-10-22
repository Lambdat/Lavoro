using Lavoro.Models;
using Lavoro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DipendentiController : ControllerBase
    {
        //Campo privato di tipo interfaccia<Tipo> che fornirà al controller tutte le operazioni necessarie
        private readonly InterfaceService<Dipendente> _iService;

        public DipendentiController(InterfaceService<Dipendente> iService)
        {
            _iService = iService;
        }
        //Tipo di Chiamata HTTP
        [HttpGet]
        public List<Dipendente> Elenco()
        {
            return _iService.Elenco();
        }
        

        [HttpGet("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dipendente Cerca([FromRoute] int id)
        {
            return _iService.CercaPerId(id);
        }

        [HttpPost]
        public Dipendente Aggiungi([FromBody] Dipendente d)
        {
            return _iService.Aggiungi(d);
        }

        [HttpPut("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dipendente Modifica([FromRoute] int id, [FromBody] Dipendente d)
        {
            return _iService.Modifica(id, d);
        }

        [HttpDelete("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dipendente Rimuovi([FromRoute] int id)
        {
            return _iService.Rimuovi(id);
        }



    }
}
