using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therexmecanic.Azure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace therexmecanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("Listado")]
        public JsonResult obtenerCliente()
        {
            var clientesRetornados = ClienteAzure.ObtenerClientes();
            return new JsonResult(clientesRetornados);
        }
    }
}
