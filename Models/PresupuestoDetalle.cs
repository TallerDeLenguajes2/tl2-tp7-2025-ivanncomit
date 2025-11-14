using ProductoSpace;
namespace PresupuestoDetalleSpace
{
    class PresupuestoDetalle
    {
        private Producto producto;
        private int cantidad;

        public PresupuestoDetalle(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public int GetCantidad()
        {
            return cantidad;
        }
        public Producto GetProducto()
        {
            return producto;
        }
    }
}