namespace ProductoSpace
{
    class Producto
    {
        private int idProducto;
        private string descripcion;
        private float precio;

        public Producto(int id, string desc, float precio)
        {
            this.idProducto = id;
            this.descripcion = desc;
            this.precio = precio;
        }

        public int GetIdProducto() => idProducto;
        public string GetDescripcion() => descripcion;
        public float GetPrecio() => precio;
    }
}