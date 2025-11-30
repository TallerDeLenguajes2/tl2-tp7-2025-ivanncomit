using TPTDL2.Models;
namespace TPTDL2.Models
{
    public class Presupuesto
    {
        public int IdPresupuesto { get; set; }
        public string NombreDestinatario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<PresupuestoDetalle> Detalle { get; set; }


        public Presupuesto() 
        {
            Detalle = new List<PresupuestoDetalle>();
        }

        public Presupuesto(int id, string nombre, List<PresupuestoDetalle> detalles)
        {
            IdPresupuesto = id;
            NombreDestinatario = nombre;
            Detalle = detalles ?? new List<PresupuestoDetalle>();
            FechaCreacion = DateTime.Now;
        }


        public double MontoPresupuesto()
        {
            float MontoTotal = 0;
            foreach (var detalleindividual in Detalle)
            {
                MontoTotal += (detalleindividual.Producto.Precio) * (detalleindividual.Cantidad);
            }
            return MontoTotal;
        }


        public double MontoPresupuestoConIva() //considerar iva 21
        {
            return MontoPresupuesto() * (1.21);
        }


        public int CantidadProductos() //contar total de productos (sumador de todas las cantidades del detalle)
        {
            int cantidad = 0;

            foreach (var detalleindividual in Detalle)
            {
                cantidad += detalleindividual.Cantidad;
            }

            return cantidad;
        }
    }
}