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
    public class RepartiController : ControllerBase
    {

        private readonly InterfaceService<Reparto> _iService;

        public RepartiController(InterfaceService<Reparto> iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public List<Reparto> Elenco()
        {
            return _iService.Elenco();
        }

        [HttpGet("{id}")]
        public Reparto Cerca(int id)
        {
            return _iService.CercaPerId(id);
        }

        [HttpPost]
        public Reparto Aggiungi([FromBody] Reparto d)
        {
            return _iService.Aggiungi(d);
        }

        [HttpPut("{id}")]
        public Reparto Modifica([FromRoute] int id, [FromBody] Reparto d)
        {
            return _iService.Modifica(id, d);
        }

        [HttpDelete("{id}")]
        public Reparto Rimuovi([FromRoute] int id)
        {
            return _iService.Rimuovi(id);
        }



    }
}
