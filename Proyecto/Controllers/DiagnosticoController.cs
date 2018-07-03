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
    public class DiagnosticoController : Controller
    {
        private readonly IDiagnosticoServices _diagnosticoServices;

        public DiagnosticoController(IDiagnosticoServices diagnosticoServices)
        {
            _diagnosticoServices = diagnosticoServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _diagnosticoServices.GetAll();

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
            var result = _diagnosticoServices.Get(id);

            if (result.idDiagnostico == 0)
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
        public IActionResult Add([FromBody]Diagnostico Model)
        {
            var result = _diagnosticoServices.Add(Model);

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
        public IActionResult Update(int id, [FromBody]Diagnostico Model)
        {
            Model.idDiagnostico = id;
            var result = _diagnosticoServices.Update(Model);

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

            var result = _diagnosticoServices.Delete(id);

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