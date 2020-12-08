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
        static string connectionString = @"Server=DESKTOP-A88JHQV\MSSQLSERVER1;Database=DBtherexmecanic;Trusted_Connection=True;";
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

        public static SqlCommand AbrirConexionSqlClientes(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Cliente";
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
    
    }

}