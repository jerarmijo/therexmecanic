using ImTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using therexmecanic.Models;

namespace therexmecanic.Azure
{
    public class VehiculoAzure
    {
        static string connectionString = "Server=tcp:bdtherexmecanic.database.windows.net,1433;Initial Catalog=BDtherexmecanic;Persist Security Info=False;User ID=jerk;Password=Tool1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static List<Vehiculo> vehiculos;

        public static List<Vehiculo> ObtenerVehiculos()
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlVehiculos(sqlConnection);
                var dataTable = LlenadoTabla(comando);
                return Listarvehiculo(dataTable);

            }

        }

        public static int AgregarVehiculo(Vehiculo vehiculo)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "insert into Cliente (Patente,Marca,Modelo,Anno,Color) values (@Patente,@Marca,@Modelo,@Anno,@Color)";
                sqlCommand.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                sqlCommand.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                sqlCommand.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                sqlCommand.Parameters.AddWithValue("@Anno", vehiculo.Anno);
                sqlCommand.Parameters.AddWithValue("@Color", vehiculo.Color);


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

        public static int AgregarVehiculo(string Patente, string Marca, string Modelo, int Anno, string Color)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "insert into Cliente (Patente,Marca,Modelo,Anno,Color) values (@Patente,@Marca,@Modelo,@Anno,@Color)";
                sqlCommand.Parameters.AddWithValue("@Patente", Patente);
                sqlCommand.Parameters.AddWithValue("@Marca", Marca);
                sqlCommand.Parameters.AddWithValue("@Modelo", Modelo);
                sqlCommand.Parameters.AddWithValue("@Anno", Anno);
                sqlCommand.Parameters.AddWithValue("@Color", Color);


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

        public static int EliminarVehiculoPorMarca(string Marca)
        {
            int FilasAfectadas = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "delete from Vehiculo where Marca = @Marca";
                sqlCommand.Parameters.AddWithValue("@Marca", Marca);


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

        public static int ActualizarVehiculoPorPatente(Vehiculo vehiculo)
        {
            int filasAfectadas = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "update Vehiculo SET Patente = @Patente,Marca = @Marca, Modelo = @Modelo, Anno = @Anno, Color = @Color,  where Patente = @Patente";
                sqlCommand.Parameters.AddWithValue("@CodCliente", vehiculo.CodCliente);
                sqlCommand.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                sqlCommand.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                sqlCommand.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                sqlCommand.Parameters.AddWithValue("@Anno", vehiculo.Anno);
                sqlCommand.Parameters.AddWithValue("@Color", vehiculo.Color);

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

        public static SqlCommand AbrirConexionSqlVehiculos(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Vehiculo";
            sqlConnection.Open();
            return sqlCommand;
        }

        public static SqlCommand AbrirConexionSqlVehiculo(SqlConnection sqlConnection, string query)
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

        public static List<Vehiculo> Listarvehiculo(DataTable dataTable)
        {
            vehiculos = new List<Vehiculo>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Patente = dataTable.Rows[i]["Patente"].ToString();
                vehiculo.Marca = dataTable.Rows[i]["Marca"].ToString();
                vehiculo.Modelo = dataTable.Rows[i]["Modelo"].ToString();
                vehiculo.Anno = int.Parse(dataTable.Rows[i]["Anno"].ToString());
                vehiculo.Color = dataTable.Rows[i]["Color"].ToString();
                vehiculos.Add(vehiculo);

            }
            return vehiculos;
        }

        private static Vehiculo CracionDeVehiculo(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {

                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Patente = dataTable.Rows[0]["Patente"].ToString();
                vehiculo.Marca = dataTable.Rows[0]["Marca"].ToString();
                vehiculo.Modelo = dataTable.Rows[0]["Modelo"].ToString();
                vehiculo.Anno = int.Parse(dataTable.Rows[0]["Anno"].ToString());
                vehiculo.Color = dataTable.Rows[0]["Color"].ToString();
                return vehiculo;
            }

            else
            {
                return null;
            }
        }
    }

   
}
