using Microsoft.AspNetCore.Mvc;
using ProductoSpace;
using ProductoR;

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
    ActionResult<string> AltaProducto(Producto nuevoProducto)
    {
        productoRepository.Alta(nuevoProducto);
        return Ok("Producto dado de alta exitosamente");
    }

    [HttpPut("CambiarNombre")]
    ActionResult<string> CambioNombreProd(int id)
    {

        return Ok();
    }

    [HttpGet("Productos")]
    ActionResult<List<Producto>> GetProductos()
    {
        List<Producto> listProductos;
        listProductos = productoRepository.ListarProductos();
        return Ok(listProductos);
    }

    [HttpGet("ProductoDetalles")]
    ActionResult<string> GetDetalleProd()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    ActionResult DeleteProducto(int id)
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