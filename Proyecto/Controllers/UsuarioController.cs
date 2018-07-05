using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Proyecto_Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _usuarioServices.GetAll();

            if (!result.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

       
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _usuarioServices.Get(id);

            if (result.idUsuario == 0) 
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/values/5
        [HttpGet("{filtro}")]
        public IActionResult GetFiltro(string filtro)
        {
            var result = _usuarioServices.GetFiltro(filtro);

            if (!result.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        // POST api/values
        [HttpPost]
        public IActionResult Add([FromBody]Usuario Model)
        {
            var result = _usuarioServices.Add(Model);

            if (!result)
            {
                return Json("no agregado");
            }
            else
            {
                return Json("Agregado correctamente");
            }

         }

       

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]Usuario Model)
        {
            Model.idUsuario = id;
            var result = _usuarioServices.Update(Model);

            if (!result)
            {
                return Json("no actualizado");
            }
            else
            {
                return Json("actualizado correctamente");
            }
  }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = _usuarioServices.Delete(id);

            if (!result)
            {
                return Json("no borrado");
            }
            else
            {
                return Json("borrado correctamente");
            }


        }

    }
}