using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]



    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListaCidades")]
        [AllowAnonymous]
        public JsonResult ListaCidades()
        {
            try
            {
                var obj = _service.listaCidades();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }

        }
        [HttpGet("BuscarPorId")]
        public JsonResult BuscarPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));

        }
        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, string uf, string cep, Guid id)
        {
            var obj = new Cidade
            {
                Id = id,
                Cep = cep,
                Uf = uf,
                Nome = nome,
            };
            _service.Salvar(obj);
            return Json(true);
        }
        [HttpDelete("Deletar")]
        public JsonResult Deletar(Guid id)
        {
            _service.Remover(id);
            return Json(true);
        }

    }
}



