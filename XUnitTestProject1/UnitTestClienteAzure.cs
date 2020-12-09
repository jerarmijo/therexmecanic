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
        public void TestObtenerCliente()
        {
            //arrange
            string nombreClientetest = "NATHAN";
            int CodEsperado = 2;
            //act
            var clienteRetornados = ClienteAzure.ObtenerCliente(nombreClientetest);

            //assert
            Assert.Equal(CodEsperado,clienteRetornados.CodCliente);
        }

        [Fact]
        public void TestObtenerClienteID()
        {
            //arrange
            int codClienteTest = 1;
            int CodEsperado = 1;
            //act
            var clienteRetornados = ClienteAzure.ObtenerClienteID(codClienteTest);

            //assert
            Assert.Equal(CodEsperado, clienteRetornados.CodCliente);
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
            ClienteAzure.EliminarClientePorNombre(cliente.Nombre);

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
            ClienteAzure.EliminarClientePorNombre(Nombre);
            //assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestEliminarClientePorNombre()
        {
            //arrange
            Cliente cliente = new Cliente();
            cliente.Nombre = "asdf";
            cliente.Apellido = "dsasf";
            cliente.Edad = 10;
            cliente.Email = "sadasd@xd.cl";
            cliente.Domicilio = "uwu de owo #123";
            cliente.Telefono = 12414564;
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            

            string clienteEliminar = "asdf";

            ClienteAzure.AgregarClienteInstancia(cliente);

            //act
            resultadoObtenido = ClienteAzure.EliminarClientePorNombre(clienteEliminar);

            //assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}
