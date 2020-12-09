﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using therexmecanic.Models;

namespace therexmecanic.Azure
{
    public class ClienteAzure
    {
        //ruta
        //static string connectionString = @"Server=DESKTOP-A88JHQV\MSSQLSERVER1;Database=DBtherexmecanic;Trusted_Connection=True;"'
        static string connectionString = "Server=tcp:therexmecanicdb.database.windows.net,1433;Initial Catalog=therexmecanicBD;Persist Security Info=False;User ID=jerkzaen;Password={Tool12!&quot};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static List<Cliente> clientes;
        
        //obtener todos los clientes
        public static List<Cliente> ObtenerClientes()
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlClientes(sqlConnection);
                var dataTable = LlenadoTabla(comando);
                return Listarclientes(dataTable);

            }
            
        }

        public static Cliente ObtenerCliente(string nombreCliente)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from Cliente where Nombre = '{nombreCliente}'";
                var comando = AbrirConexionSqlCliente(sqlConnection,query);
                var dataTable = LlenadoTabla(comando);

                return CracionDeCliente(dataTable);
            }
        }

        public static Cliente ObtenerClienteID(int  codCliente)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from Cliente where CodCliente = '{codCliente}'";
                var comando = AbrirConexionSqlCliente(sqlConnection, query);
                var dataTable = LlenadoTabla(comando);

                return CracionDeCliente(dataTable);
            }
        }

        public static int AgregarClienteInstancia(Cliente cliente)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "insert into Cliente (Nombre,Apellido,Edad,Email,Domicilio,Telefono) values (@Nombre,@Apellido,@Edad,@Email,@Domicilio,@Telefono)";
                sqlCommand.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                sqlCommand.Parameters.AddWithValue("@Edad", cliente.Edad);
                sqlCommand.Parameters.AddWithValue("@Email", cliente.Email);
                sqlCommand.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);
                sqlCommand.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                try
                {
                    sqlConnection.Open();
                    FilasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return FilasAfectadas;
            }
        }

        public static int AgregarClienteParametro(string Nombre, string Apellido, int Edad, string Email, string Domicilio, int Telefono)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "insert into Cliente (Nombre,Apellido,Edad,Email,Domicilio,Telefono) values (@Nombre,@Apellido,@Edad,@Email,@Domicilio,@Telefono)";
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@Apellido", Apellido);
                sqlCommand.Parameters.AddWithValue("@Edad", Edad);
                sqlCommand.Parameters.AddWithValue("@Email", Email);
                sqlCommand.Parameters.AddWithValue("@Domicilio", Domicilio);
                sqlCommand.Parameters.AddWithValue("@Telefono", Telefono);

                try
                {
                    sqlConnection.Open();
                    FilasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return FilasAfectadas;
            }
        }

        public static int EliminarClientePorNombre(string Nombre)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "delete from Cliente where Nombre = @Nombre";
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);


                try
                {
                    sqlConnection.Open();
                    FilasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return FilasAfectadas;
            }
        }

        public static int ActualizarClientePorID(Cliente cliente)
        {
            int filasAfectadas = 0;
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null,sqlConnection);
                sqlCommand.CommandText = "update Cliente SET Nombre = @Nombre,Apellido = @Apellido, Edad = @Edad, Email = @Email, Domicilio = @Domicilio, Telefono = @Telefono where CodCliente = @CodCliente";

                sqlCommand.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("@CodCliente", cliente.CodCliente);
                sqlCommand.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                sqlCommand.Parameters.AddWithValue("@Edad", cliente.Edad);
                sqlCommand.Parameters.AddWithValue("@Email", cliente.Email);
                sqlCommand.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);
                sqlCommand.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                try
                {
                    sqlConnection.Open();
                    filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                return filasAfectadas;
            }

                
        }

        public static SqlCommand AbrirConexionSqlClientes(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Cliente";
            sqlConnection.Open();
            return sqlCommand;
        }

        public static SqlCommand AbrirConexionSqlCliente(SqlConnection sqlConnection, string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            return sqlCommand;
        }

        public static DataTable LlenadoTabla(SqlCommand comando)
        {
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static List<Cliente> Listarclientes(DataTable dataTable)
        {
            clientes = new List<Cliente>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Cliente cliente = new Cliente();
                cliente.CodCliente = int.Parse(dataTable.Rows[i]["codCliente"].ToString());
                cliente.Nombre = dataTable.Rows[i]["Nombre"].ToString();
                cliente.Apellido = dataTable.Rows[i]["Apellido"].ToString();
                cliente.Edad = int.Parse(dataTable.Rows[i]["Edad"].ToString());
                cliente.Email = dataTable.Rows[i]["Email"].ToString();
                cliente.Domicilio = dataTable.Rows[i]["Domicilio"].ToString();
                cliente.Telefono = int.Parse(dataTable.Rows[i]["Telefono"].ToString());
                clientes.Add(cliente);
                
            }
            return clientes;
        }

        private static Cliente CracionDeCliente(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Cliente cliente = new Cliente();
                cliente.CodCliente = int.Parse(dataTable.Rows[0]["CodCliente"].ToString());
                cliente.Nombre = dataTable.Rows[0]["Nombre"].ToString();
                cliente.Apellido = dataTable.Rows[0]["Apellido"].ToString();
                cliente.Edad = int.Parse(dataTable.Rows[0]["Edad"].ToString());
                cliente.Email = dataTable.Rows[0]["Email"].ToString();
                cliente.Domicilio = dataTable.Rows[0]["Domicilio"].ToString();
                cliente.Telefono = int.Parse(dataTable.Rows[0]["Telefono"].ToString());
                return cliente;
            }
            else
            {
                return null;
            }
        }

    }

}
