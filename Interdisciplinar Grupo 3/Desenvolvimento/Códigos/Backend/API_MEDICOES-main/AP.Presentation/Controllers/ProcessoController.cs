using AM.Data.Interface;
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
    public class ProcessoController : ControllerBase
    {
        private IProcesso ProcessoPersistence;

        public ProcessoController(IProcesso procPersistence)
        {
            ProcessoPersistence = procPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Processo>> Listar()
        {
            try
            {
                return ProcessoPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Processos!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Processo>> ListarPorId(string id)
        {
            try
            {
                return ProcessoPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Processo!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Processo a)
        {
            try
            {
                await ProcessoPersistence.Cadastrar(a);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar o Processo!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await ProcessoPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Processo!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Processo a)
        {
            try
            {
                await ProcessoPersistence.Alterar(a);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Processo!");
            }
        }
    }
}
