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

        private readonly InterfaceService<Dirigente> _iService;

        public DirigentiController(InterfaceService<Dirigente> iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public List<Dirigente> Elenco()
        {
            return _iService.Elenco();
        }

        [HttpGet("{id}")]
        public Dirigente Cerca(int id)
        {
            return _iService.CercaPerId(id);
        }

        [HttpPost]
        public Dirigente Aggiungi([FromBody]Dirigente d)
        {
            return _iService.Aggiungi(d);
        }

        [HttpPut("{id}")]
        public Dirigente Modifica([FromRoute] int id,[FromBody]Dirigente d)
        {
            return _iService.Modifica(id, d);
        }

        [HttpDelete("{id}")]
        public Dirigente Rimuovi([FromRoute]int id)
        {
            return _iService.Rimuovi(id);
        }

    }
}
