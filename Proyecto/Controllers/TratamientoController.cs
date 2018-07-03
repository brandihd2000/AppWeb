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
    public class TratamientoController : Controller
    {
        private readonly ITratamientoServices _tratamientoServices;

        public TratamientoController(ITratamientoServices tratamientoServices)
        {
            _tratamientoServices = tratamientoServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _tratamientoServices.GetAll();

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
            var result = _tratamientoServices.Get(id);

            if (result.idTratamiento == 0)
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
        public IActionResult Add([FromBody]Tratamiento Model)
        {
            var result = _tratamientoServices.Add(Model);

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
        public IActionResult Update(int id, [FromBody]Tratamiento Model)
        {
            Model.idTratamiento = id;
            var result = _tratamientoServices.Update(Model);

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

            var result = _tratamientoServices.Delete(id);

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