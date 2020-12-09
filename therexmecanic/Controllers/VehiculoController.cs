using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therexmecanic.Azure;
using therexmecanic.Models;

namespace therexmecanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {

        [HttpGet("Listado")]
        public JsonResult obtenerVehiculos()
        {
            var vehiculosRetornados = VehiculoAzure.ObtenerVehiculos();
            return new JsonResult(vehiculosRetornados);
        }



    }
}
