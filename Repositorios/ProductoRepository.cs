/*
Repositorio de Productos:
Crear un repositorio llamado ProductoRepository para gestionar todas las
operaciones relacionadas con Productos. Este repositorio debe incluir métodos para:
● Crear un nuevo Producto. (recibe un objeto Producto)
● Modificar un Producto existente. (recibe un Id y un objeto Producto)
● Listar todos los Productos registrados. (devuelve un List de Producto)
● Obtener detalles de un Productos por su ID. (recibe un Id y devuelve un
Producto)
● Eliminar un Producto por ID
*/

using ProductoSpace;
using Microsoft.Data.Sqlite;

namespace ProductoR
{
    class ProductoRepository
    {
        private string connectionString = "Data Source=DB/Tienda.db";
        public void Alta (Producto productoaCrear)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
        public void ModificarProd(int idProducto, Producto producto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
        public List<Producto> ListarProductos()
        {
            string consulta = "SELECT * FROM Presupuestos";
            List<Producto> listainicial = [];
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = new SqliteCommand(consulta, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var producto = new Producto (int.Parse(reader["idProducto"]),
                        reader["Descripcion"],
                        int.Parse(reader["Precio"]))
                    }    
                }


                connection.Close();
            }
        }
        public Producto DetallesProducto (int idProducto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
        public bool EliminarProductoPorID(int idProducto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
    }
}