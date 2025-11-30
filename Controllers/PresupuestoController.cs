using Microsoft.AspNetCore.Mvc;
using TPTDL2.Models;
using TPTDL2.Repositorys;

namespace TPTDL2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestosController : ControllerBase
    {
        private PresupuestoRepository presupuestoRepository;
        
        public PresupuestosController()
        {
            presupuestoRepository = new PresupuestoRepository();
        }

        [HttpPost("AltaPresupuesto")]
        ActionResult<string> AltaProducto(Presupuesto nuevoProducto)
        {

            return Ok("");
        }

        [HttpPost("{id}/AsignarProductoyCantidad")]
        ActionResult<string> ModificarProducto(Presupuesto nuevoProducto)
        {

            return Ok("");
        }

        [HttpGet("ListarPresupuestos")]
        ActionResult<List<Presupuesto>> GetProductos()
        {

            return Ok();
        }
        [HttpGet("{id}")]
        ActionResult<List<Presupuesto>> GetDetallesPresupuesto()
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        ActionResult DeletePresupuesto(int id)
        {
            bool eliminado = presupuestoRepository.EliminarPresupuestoPorID(id);
            if (eliminado)
            {
                return NoContent(); // HTTP 204 (Eliminación exitosa)
            }
            else
            {
                return NotFound($"No se encontró el presupuesto con ID {id} para eliminar.");
            }
        }
    }
}