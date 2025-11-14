/*
Repositorio de Presupuestos:
Crear un repositorio llamado PresupuestosRepository para gestionar todas las
operaciones relacionadas con Presupuestos. Este repositorio debe incluir métodos para:
● Crear un nuevo Presupuesto. (recibe un objeto Presupuesto)
● Listar todos los Presupuestos registrados. (devuelve un List de Presupuestos)
● Obtener detalles de un Presupuesto por su ID. (recibe un Id y devuelve un
Presupuesto con sus productos y cantidades)
● Agregar un producto y una cantidad a un presupuesto (recibe un Id)
● Eliminar un Presupuesto por ID
*/

using PresupuestoSpace;

using Microsoft.Data.Sqlite;

namespace PresupuestoR
{
    public class PresupuestoRepository
    {
        private string connectionString = "Data Source=DB/Tienda.db";
        void CrearPresupuesto(Presupuesto presupuestoaCrear)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                connection.Close();
            }
        }
        List<Presupuesto> ListarPresupuestos()
        {
            string consulta = "SELECT * FROM Presupuestos";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
        Presupuesto ObtenerPresupuestoID(int idpresupuesto)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();



                connection.Close();
            }
        }
        void AgregarProdyCantidadID(int idPresupuesto)
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