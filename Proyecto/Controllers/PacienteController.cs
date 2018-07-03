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
    public class PacienteController : Controller
    {
        private readonly IPacienteServices _pacienteServices;

        public PacienteController(IPacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _pacienteServices.GetAll();

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
            var result = _pacienteServices.Get(id);

            if (result.idPaciente == 0)
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
        public IActionResult Add([FromBody]Paciente Model)
        {
            var result = _pacienteServices.Add(Model);

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
        public IActionResult Update(int id, [FromBody]Paciente Model)
        {
            Model.idPaciente = id;
            var result = _pacienteServices.Update(Model);

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

            var result = _pacienteServices.Delete(id);

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