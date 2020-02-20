using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Jogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly JogoContext _context;
        public ValuesController(JogoContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listJogo = _context.Jogos.Where(h => EF.Functions.Like(h.Nome, $"%{nome}")).OrderBy(h => h.Id).LastOrDefault();
            //var listJogo = (from jogo in _context.Jogos
            //                 where jogo.Nome.Contains(nome)
            //                 select jogo).ToList();
            return Ok(listJogo);
        }

        // GET api/values/5
        [HttpGet("Atualizar/{nameGame}")]
        public ActionResult<string> Get(string nameGame)
        {
            //var jogo = new Jogo { Nome = nameHero };
            var jogo = _context.Jogos.Where(h => h.Id == 2).FirstOrDefault();
            jogo.Nome = "FIFA20";
            //_context.Add(heroi);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Jogo { Nome = "God of War" },
                new Jogo { Nome = "GTA V" },
                new Jogo { Nome = "Call of Duty" }
                );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var jogo = _context.Jogos.Where(x => x.Id == id).Single();
            _context.Jogos.Remove(jogo);
            _context.SaveChanges();
        }
    }
}
