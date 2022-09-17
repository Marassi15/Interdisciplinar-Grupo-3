using AM.Data;
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
    public class ObjetivoController : ControllerBase
    {
        private IObjetivo ObjetivoPersistence;

        public ObjetivoController(IObjetivo objPersistence)
        {
            ObjetivoPersistence = objPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Objetivo>> Listar()
        {
            try
            {
                return ObjetivoPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Objetivos!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Objetivo>> ListarPorId(int id)
        {
            try
            {
                return ObjetivoPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Objetivo!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Objetivo p)
        {
            try
            {
                await ObjetivoPersistence.Cadastrar(p);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar o Objetivo!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal id)
        {
            try
            {
                await ObjetivoPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Objetivo!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Objetivo p)
        {
            try
            {
                await ObjetivoPersistence.Alterar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Objetivo!");
            }
        }
    }
}
