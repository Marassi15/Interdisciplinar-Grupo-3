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
    public class MedicaoController : ControllerBase
    {
        private IMedicao MedicaoPersistence;

        public MedicaoController(IMedicao medicaoPersistence)
        {
            MedicaoPersistence = medicaoPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Medicao>> Listar()
        {
            try
            {
                return MedicaoPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as Medições!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Medicao>> ListarPorId(string id)
        {
            try
            {
                return MedicaoPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a Medição!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Medicao p)
        {
            try
            {
                await MedicaoPersistence.Cadastrar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar a Medicao!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await MedicaoPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a Medicao!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Medicao p)
        {
            try
            {
                await MedicaoPersistence.Alterar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a Medicao!");
            }
        }
    }
}
