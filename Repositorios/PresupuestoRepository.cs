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
                command.Parameters.AddWithValue("@NombreCrear", presupuestoaCrear.NombreDestinatario);
                command.Parameters.AddWithValue("@FechaCrear", presupuestoaCrear.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss"));
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
                        var presupuesto = new Presupuesto();
                        presupuesto.IdPresupuesto = reader.GetInt32(0);
                        presupuesto.NombreDestinatario = reader.GetString(1);
                        // Convertimos el texto de la base de datos a fecha real
                        presupuesto.FechaCreacion = DateTime.Parse(reader.GetString(2));
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
                Presupuesto presupuesto = null;

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        presupuesto = new Presupuesto();
                        presupuesto.IdPresupuesto = reader.GetInt32(0);
                        presupuesto.NombreDestinatario = reader.GetString(1);
                        presupuesto.FechaCreacion = DateTime.Parse(reader.GetString(2));
                    }
                }

                if (presupuesto != null)
                {

                    string consultaDetalle = @"SELECT P.IdProducto, P.Descripcion, P.Precio, D.Cantidad 
                                            FROM PresupuestosDetalle D 
                                            INNER JOIN Productos P ON D.IdProducto = P.IdProducto 
                                            WHERE D.IdPresupuesto = @idPres";

                    var cmdDetalle = new SqliteCommand(consultaDetalle, connection);

                    cmdDetalle.Parameters.AddWithValue("@idPres", idpresupuesto);

                    using (SqliteDataReader reader = cmdDetalle.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prod = new Producto();
                            prod.IdProducto = reader.GetInt32(0);
                            prod.Descripcion = reader.GetString(1);
                            prod.Precio = reader.GetInt32(2);

                            var detalle = new PresupuestoDetalle(prod, reader.GetInt32(3));
                            presupuesto.Detalle.Add(detalle);
                        }
                    }
                }
                connection.Close();
                return presupuesto;
            }
        }

        public void AgregarProdyCantidadID(int idPresupuesto, int idProducto, int cantidad)
        {
            string consulta = "INSERT INTO PresupuestosDetalle (IdPresupuesto, IdProducto, Cantidad) VALUES (@idP, @idProd, @cant)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);
                command.Parameters.AddWithValue("@idP", idPresupuesto);
                command.Parameters.AddWithValue("@idProd", idProducto);
                command.Parameters.AddWithValue("@cant", cantidad);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool EliminarPresupuestoPorID(int idpresupuesto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                // Adentro del using:
                connection.Open();

                // 1. Borrar detalle
                string queryDetalle = "DELETE FROM PresupuestosDetalle WHERE IdPresupuesto = @id";
                var cmdDetalle = new SqliteCommand(queryDetalle, connection);
                cmdDetalle.Parameters.AddWithValue("@id", idpresupuesto);
                cmdDetalle.ExecuteNonQuery();

                // 2. Borrar cabecera
                string queryCabecera = "DELETE FROM Presupuestos WHERE IdPresupuesto = @id";
                var cmdCabecera = new SqliteCommand(queryCabecera, connection);
                cmdCabecera.Parameters.AddWithValue("@id", idpresupuesto);
                int filas = cmdCabecera.ExecuteNonQuery();

                connection.Close();
                return filas > 0;
            }
        }       
    }
}