namespace ProductoSpace
{
    class Producto
    {
        private int idProducto;
        private string descripcion;
        private int precio;

        public Producto(int id, string desc, int precio)
        {
            this.idProducto = id;
            this.descripcion = desc;
            this.precio = precio;
        }

        public int IdProducto() => idProducto;
        public string GetDescripcion() => descripcion;
        public int Precio() => precio;
    }
}