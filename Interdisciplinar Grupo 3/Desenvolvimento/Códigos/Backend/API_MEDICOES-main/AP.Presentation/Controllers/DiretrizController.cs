using AM.Data.Interface;
using AM.Data.Persistence;
using AM.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretrizController : ControllerBase
    {
        private IDiretriz DiretrizPersistence;

        public DiretrizController(IDiretriz dirPersistence)
        {
            DiretrizPersistence = dirPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Diretriz>> Listar()
        {
            try
            {
                return DiretrizPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as Diretrizes!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Diretriz>> ListarPorId(string id)
        {
            try
            {
                return DiretrizPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a Diretriz!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Diretriz e)
        {
            try
            {
                await DiretrizPersistence.Cadastrar(e);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar a Diretriz!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await DiretrizPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a Diretriz!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Diretriz e)
        {
            try
            {
                await DiretrizPersistence.Alterar(e);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a Diretriz!");
            }
        }
    }
}
