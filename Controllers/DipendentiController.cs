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
    public class DipendenteController : ControllerBase
    {

        private readonly InterfaceService<Dipendente> _iService;

        public DipendenteController(InterfaceService<Dipendente> iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public List<Dipendente> Elenco()
        {
            return _iService.Elenco();
        }

        [HttpGet("{id}")]
        public Dipendente Cerca(int id)
        {
            return _iService.CercaPerId(id);
        }

        [HttpPost]
        public Dipendente Aggiungi([FromBody] Dipendente d)
        {
            return _iService.Aggiungi(d);
        }

        [HttpPut("{id}")]
        public Dipendente Modifica([FromRoute] int id, [FromBody] Dipendente d)
        {
            return _iService.Modifica(id, d);
        }

        [HttpDelete("{id}")]
        public Dipendente Rimuovi([FromRoute] int id)
        {
            return _iService.Rimuovi(id);
        }



    }
}
