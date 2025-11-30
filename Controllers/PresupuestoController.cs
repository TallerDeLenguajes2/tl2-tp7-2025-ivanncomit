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
        public ActionResult<string> AltaPresupuesto(Presupuesto nuevoPresupuesto)
        {
            presupuestoRepository.CrearPresupuesto(nuevoPresupuesto);
            return Ok("Presupuesto creado exitosamente");
        }

        [HttpPost("{id}/ProductoDetalle")]
        public ActionResult<string> AgregarProducto(int id, int idProducto, int cantidad)
        {
            presupuestoRepository.AgregarProdyCantidadID(id, idProducto, cantidad);
            return Ok($"Producto {idProducto} agregado al presupuesto {id} con cantidad {cantidad}");
        }

        [HttpGet("ListarPresupuestos")]
        public ActionResult<List<Presupuesto>> GetProductos()
        {
            var lista = presupuestoRepository.ListarPresupuestos();
            return Ok(lista);

        }
        [HttpGet("{id}")]

        public ActionResult<Presupuesto> GetDetallesPresupuesto(int id)
        {   
            var presupuesto = presupuestoRepository.ObtenerPresupuestoID(id);
            
            if (presupuesto == null) 
            {
                return NotFound("Presupuesto no encontrado");
            }
            
            return Ok(presupuesto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePresupuesto(int id)
        {
            bool eliminado = presupuestoRepository.EliminarPresupuestoPorID(id);
            if (eliminado)
            {
                return NoContent();
            }
            else
            {
                return NotFound($"No se encontró el presupuesto con ID {id} para eliminar.");
            }
        }
    }
}