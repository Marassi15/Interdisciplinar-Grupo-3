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
    public class MedidaController : ControllerBase
    {
        private IMedida MedidaPersistence;

        public MedidaController(IMedida medPersistence)
        {
            MedidaPersistence = medPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Medida>> Listar()
        {
            try
            {
                return MedidaPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as Medidas!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Medida>> ListarPorId(int id)
        {
            try
            {
                return MedidaPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a Medida!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Medida r)
        {
            try
            {
                await MedidaPersistence.Cadastrar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar a Medida!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal id)
        {
            try
            {
                await MedidaPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a Medida!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Medida r)
        {
            try
            {
                await MedidaPersistence.Alterar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a Medida!");
            }
        }
    }
}
