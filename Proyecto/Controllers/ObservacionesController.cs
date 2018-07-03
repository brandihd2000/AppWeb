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
    public class ObservacionesController : Controller
    {
        private readonly IObservacionesServices _observacionesServices;

        public ObservacionesController(IObservacionesServices observacionesServices)
        {
            _observacionesServices = observacionesServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _observacionesServices.GetAll();

            if (!result.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // _usuarioServices.Get(id)
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _observacionesServices.Get(id);

            if (result.idObservaciones == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody]Observaciones Model)
        {
            var result = _observacionesServices.Add(Model);

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
        public IActionResult Update(int id, [FromBody]Observaciones Model)
        {
            Model.idObservaciones = id;
            var result = _observacionesServices.Update(Model);

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

            var result = _observacionesServices.Delete(id);

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