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
    public class DirigentiController : ControllerBase
    {
        //Campo privato di tipo interfaccia<Tipo> che fornirà al controller tutte le operazioni necessarie
        private readonly InterfaceService<Dirigente> _iService;

        public DirigentiController(InterfaceService<Dirigente> iService)
        {
            _iService = iService;
        }
        //Tipo di Chiamata HTTP
        [HttpGet]
        public List<Dirigente> Elenco()
        {
            return _iService.Elenco();
        }

        [HttpGet("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dirigente Cerca(int id)
        {
            return _iService.CercaPerId(id);
        }

        [HttpPost]
        public Dirigente Aggiungi([FromBody]Dirigente d)
        {
            return _iService.Aggiungi(d);
        }

        [HttpPut("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dirigente Modifica([FromRoute] int id,[FromBody]Dirigente d)
        {
            return _iService.Modifica(id, d);
        }

        [HttpDelete("{id}")] //{Id} è una wild card, aggiunta dopo lo "/" della Route
        public Dirigente Rimuovi([FromRoute]int id)
        {
            return _iService.Rimuovi(id);
        }

    }
}
