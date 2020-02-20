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
    public class VideoGameController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public VideoGameController(IEFCoreRepository repo)
        {
           _repo = repo;
        }
        // GET: api/VideoGame
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var consoles = await _repo.GetAllConsole(true);
                return Ok(consoles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/VideoGame/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var consoles = await _repo.GetConsoleById(id, true);
                return Ok(consoles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/VideoGame
        [HttpPost]
        public async Task<IActionResult> Post(VideoGame model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Console Cadastrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Salvou");
        }

        // PUT: api/VideoGame/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VideoGame model)
        {
            try
            {
                var console = await _repo.GetConsoleById(id);
                if (console != null)
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
                var console = await _repo.GetConsoleById(id);
                if (console != null)
                {
                    _repo.Delete(console);
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
