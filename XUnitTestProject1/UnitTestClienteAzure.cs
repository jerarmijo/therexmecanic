using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using therexmecanic.Azure;
using therexmecanic.Models;

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

        [Fact]
        public void TestAgregarClientesPorInstancia()
        {
            //arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Cliente cliente = new Cliente();
            cliente.Nombre = "JER";
            cliente.Apellido = "Armijo";
            cliente.Edad = 1;
            cliente.Email = "jersonar@gmail.com";
            cliente.Domicilio = "Los uwu #1313";
            cliente.Telefono = 1;


            //act
            resultadoObtenido = ClienteAzure.AgregarClienteInstancia(cliente);

            //assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestAgregarClientesPorParametros()
        {
            //arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;


            string Nombre = "JER";
            string Apellido = "Armijo";
            int Edad = 1;
            string Email = "jersonar@gmail.com";
            string Domicilio = "Los uwu #1313";
            int Telefono = 1;


            //act
            resultadoObtenido = ClienteAzure.AgregarClienteParametro(Nombre, Apellido, Edad, Email, Domicilio,Telefono);

            //assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestEliminarClientePorCodigo()
        {
            //arrange
            Cliente cliente = new Cliente();
            int resultadoEsperado = 1;
            int ResultadoObtenido = 0;



            //act

            //assert
        }
    }
}
