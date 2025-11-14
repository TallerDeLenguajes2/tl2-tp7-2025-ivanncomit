using PresupuestoDetalleSpace;
namespace PresupuestoSpace
{
    class Presupuesto
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private date FechaCreacion
        private List<PresupuestoDetalle> detalle;

        public Presupuesto(int id, string nombre, List<PresupuestoDetalle> detalles)
        {
            this.IdPresupuesto = id;
            this.nombreDestinatario = nombre;
            this.detalle = detalles;
            //this.FechaCreacion = 
        }

        public int GetIdProducto() => idProducto;
        public string GetDestinatario() => nombreDestinatario;
        public date GetFecha() => FechaCreacion;



        public double MontoPresupuesto()
        {
            float MontoTotal = 0;
            foreach (var detalleindividual in detalle)
            {
                MontoTotal += (detalleindividual.GetProducto().Precio()) * (detalleindividual.GetCantidad());
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

            foreach (var detalleindividual in detalle)
            {
                cantidad += detalleindividual.GetCantidad();
            }

            return cantidad;
        }
    }
}