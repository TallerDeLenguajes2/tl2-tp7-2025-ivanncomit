namespace ProductoSpace
{
    class Producto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }


        public Producto(int id, string desc, int precio)
        {
            IdProducto = id;
            Descripcion = desc;
            Precio = precio;
        }

    }
}