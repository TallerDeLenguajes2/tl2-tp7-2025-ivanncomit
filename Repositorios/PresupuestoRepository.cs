using TPTDL2.Models;

using Microsoft.Data.Sqlite;

namespace TPTDL2.Repositorys
{
    public class PresupuestoRepository
    {
        private string connectionString = "Data Source=tienda.db";
        //● Crear un nuevo Presupuesto. (recibe un objeto Presupuesto)
        public void CrearPresupuesto(Presupuesto presupuestoaCrear)
        {
            string consulta = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@NombreCrear, @FechaCrear)";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var command = new SqliteCommand(consulta, connection)
                connection.Open();
                command.Parameters.AddWithValue("@NombreCrear", presupuestoaCrear.GetDestinatario());
                command.Parameters.AddWithValue("@FechaCrear", presupuestoaCrear.GetFecha());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Presupuesto> ListarPresupuestos()
        {
            string consulta = "SELECT * FROM Presupuestos";
            List<Presupuesto> listainicial = new List<Presupuesto>();
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var presupuesto = new Presupuesto (reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        listainicial.Add(presupuesto);
                    }
                }
                return listainicial;
            }
        }
        public Presupuesto ObtenerPresupuestoID(int idpresupuesto)
        {
            string consulta = "SELECT idPresupuesto, NombreDestinatario , FechaCreacion FROM Presupuestos WHERE idPresupuesto = @idPres;";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);
                command.Parameters.AddWithValue("@idPres", idpresupuesto);
                Presupuesto nuevo = null;

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if(reader.GetInt32(0)==idpresupuesto)
                        {
                            presupuestoObtenido = new Presupuesto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2))
                        }
                    }
                }



                connection.Close();
            }
        }
        public void AgregarProdyCantidadID(int idPresupuesto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                


                connection.Close();
            }
        }
        public bool EliminarPresupuestoPorID(int idpresupuesto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }       
    }
}