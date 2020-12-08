using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using therexmecanic.Azure;

namespace XUnitTestProject1
{
    public class UnitTestClienteAzure
    {
        [Fact]
        public void TestObtenerClientes()
        {
            //arrange
            bool vieneConDatos = false;
            
            //act
            var clienteRetornados = ClienteAzure.ObtenerClientes();
            vieneConDatos = clienteRetornados.Any();
            //assert
            Assert.True(vieneConDatos);
        }

    }
}
