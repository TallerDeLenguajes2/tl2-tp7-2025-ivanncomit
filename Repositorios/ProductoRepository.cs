using ProductoSpace;
using Microsoft.Data.Sqlite;

namespace ProductoR
{
    class ProductoRepository
    {
        private string connectionString = "Data Source=DB/Tienda.db";
        public void Alta (Producto productoaCrear)
        {
            string consulta = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio);"; 
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var command = new SqliteCommand(consulta, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Descripcion", productoaCrear.GetDescripcion());
                command.Parameters.AddWithValue("@Precio", productoaCrear.GetPrecio());

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void ModificarProd(int idProducto, Producto producto)
        {
            string consulta = "UPDATE Productos SET Descripcion = @NuevaDescripcion , Precio = @NuevoPrecio WHERE idProducto = @idProd;";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var command = new SqliteCommand(consulta, connection);
                connection.Open();
                command.Parameters.AddWithValue("@NuevaDescripcion", producto.GetDescripcion());
                command.Parameters.AddWithValue("@NuevoPrecio", producto.GetPrecio());
                command.Parameters.AddWithValue("@idProd", idProducto);
                
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public List<Producto> GetAllProductos()
        {
            string consulta = "SELECT * FROM Productos;";
            List<Producto> listainicial = new List<Producto>();
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var producto = new Producto (reader.GetInt32(0), reader.GetString(1), (float)reader.GetDouble(2));
                        listainicial.Add(producto);
                    }
                }
                connection.Close();
            }
            return listainicial;
        }

        public Producto DetallesProducto (int idProducto)
        {
            string consulta = "SELECT idProducto, Descripcion, Precio FROM Productos WHERE idProducto = @idProd;";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);

                command.Parameters.AddWithValue("@idProd", idProducto);
                Producto nuevo = null;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        nuevo = new Producto(reader.GetInt32(0), reader.GetString(1), (float)reader.GetDouble(2));
                    }
                }

                connection.Close();
                return nuevo;
            }
        }
        public bool EliminarProductoPorID(int idProducto)
        {
            string consulta = "DELETE FROM Productos WHERE idProducto = @idProd;";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);
                command.Parameters.AddWithValue("@idProd", idProducto);

                int filas = command.ExecuteNonQuery();

                connection.Close();
                return filas > 0; 

            }
        }
    }
}