using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using therexmecanic.Azure;
using therexmecanic.Models;

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

        [HttpGet("{Cliente}")]
        public JsonResult ObtenerCliente(string Cliente)
        {
            var conersionExitosa = int.TryParse(Cliente, out int codigoConvertido);
            Cliente clienteRetornado;

            if (conersionExitosa)
            {
                clienteRetornado = ClienteAzure.ObtenerClienteID(codigoConvertido);
            }
            else
            {
                clienteRetornado = ClienteAzure.ObtenerCliente(Cliente);
            }
            if (clienteRetornado is null)
            {
                return new JsonResult($"No se encontraron registros para : {Cliente}. Intente nuevamente");
            }
            else
            {
                return new JsonResult(clienteRetornado);
            }

            
            
        }
    }


}
