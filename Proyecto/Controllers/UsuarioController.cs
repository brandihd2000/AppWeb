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

    }
}