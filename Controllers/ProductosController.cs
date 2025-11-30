using Microsoft.AspNetCore.Mvc;
using TPTDL2.Models;
using TPTDL2.Repositorys;

namespace TPTDL2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private ProductoRepository productoRepository;
        public ProductosController()
        {
            productoRepository = new ProductoRepository();
        }

        [HttpPost("AltaProducto")]

        public ActionResult<string> AltaProducto(Producto nuevoProducto)
        {
            productoRepository.Alta(nuevoProducto);
            return Ok("Producto dado de alta exitosamente");
        }

        [HttpPut("ModificarProducto/{id}")]
        public ActionResult<string> CambioProd(int id, Producto producto)
        {
            productoRepository.ModificarProd(id, producto);
            return Ok("Producto Modificado exitosamente");
        }

        [HttpGet("ListarProductos")]
        public ActionResult<List<Producto>> GetProductos()
        {
            var lista = productoRepository.GetAllProductos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetDetalleProd(int id)
        {
            var prod = productoRepository.DetallesProducto(id);
            if(prod==null) return NotFound("Producto no encontrado");
            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProducto(int id)
        {
            bool eliminado = productoRepository.EliminarProductoPorID(id);
            if (eliminado)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound($"No se encontró el producto con ID {id} para eliminar.");
            }
        }
    }
}