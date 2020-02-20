using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Jogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public JogoController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Jogo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var jogos = await _repo.GetAllJogos(true);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Jogo/5
        [HttpGet("{id}", Name = "GetJogo")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var jogos = await _repo.GetJogoById(id, true);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/Jogo
        [HttpPost]
        public async Task<IActionResult> Post(Jogo model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Jogo Cadastrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Salvou");
        }

        // PUT: api/Jogo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Jogo model)
        {
            try
            {
                var jogo = await _repo.GetJogoById(id);
               if (jogo != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Atualizado!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Atualizado!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var jogo = await _repo.GetJogoById(id);
                if (jogo != null)
                {
                    _repo.Delete(jogo);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Deletado!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Deletado!");
        }
    }
}
