using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class MantenimientoController : Controller
    {
        private IRepositorioConfiguracion _config;
        private IUCAgregarMantenimiento _agregarMantenimientoUC;
        private IUCEditarMantenimiento _editarMantenimientoUC;
        private IUCEliminarMantenimiento _eliminarMantenimientoUC;
        private IUCObtenerMantenimientos _obtenerMantenimientosUC;

        public MantenimientoController(IRepositorioConfiguracion configuracion,
            IUCAgregarMantenimiento agregarMantenimientoUC,
            IUCEditarMantenimiento editarMantenimientoUC,
            IUCEliminarMantenimiento eliminarMantenimientoUC,
            IUCObtenerMantenimientos obtenerMantenimientosUC)
        {
            this._config = configuracion;
            this._agregarMantenimientoUC = agregarMantenimientoUC;
            this._editarMantenimientoUC = editarMantenimientoUC;
            this._eliminarMantenimientoUC = eliminarMantenimientoUC;
            this._obtenerMantenimientosUC = obtenerMantenimientosUC;
        }

        /// <summary>
        /// Obtiene todos los mantenimientos a una cabaña entre dos fechas
        /// </summary>
        /// <param name="nombreCabania">Nombre de la cabaña.</param>
        /// <param name="fecha1">Primera fecha.</param>
        /// <param name="fecha2">Segunda fecha.</param>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetMantenimientosEntreDosFechas(string nombreCabania, DateTime fecha1, DateTime fecha2)
        {
            return Ok(_obtenerMantenimientosUC.ObtenerMantenimientosEntreDosFechas(nombreCabania, fecha1, fecha2));
        }

        /// <summary>
        /// Obtiene el mantenimiento con el id especificado
        /// </summary>
        /// <param name="mantenimientoId">Id del mantenimiento.</param>
        /// <returns>Retorna el mantenimiento especificado</returns>
        [HttpGet("{mantenimientoId}")]
        public IActionResult GetMantenimiento(int mantenimientoId)
        {
            try
            {
                return Ok(_obtenerMantenimientosUC.GetMantenimientoPorId(mantenimientoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creacion de mantenimiento en la base de datos
        /// </summary>
        /// <param name="mantenimiento">Mantenimiento completo.</param>
        /// <returns>Retorna el mantenimiento recién creado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearMantenimiento([FromBody] MantenimientoDTO mantenimiento)
        {
            try
            {
                return Created(new Uri("http://localhost:7040/Mantenimientos"), _agregarMantenimientoUC
                    .AgregarMantenimiento(mantenimiento, this._config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Actualización de mantenimiento en la base de datos
        /// </summary>
        /// <param name="mantenimiento">Mantenimiento completo.</param>
        /// <param name="mantenimientoId">Id del mantenimiento a actualizar.</param>
        /// <returns>Retorna el mantenimiento recién editado</returns>
        [HttpPut("{mantenimientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarMantenimiento([FromBody] MantenimientoDTO mantenimiento, int mantenimientoId)
        {
            try
            {
                return Ok(_editarMantenimientoUC.EditarMantenimiento(mantenimiento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminación de mantenimiento en la base de datos
        /// </summary>
        /// <param name="mantenimientoId">Nombre del mantenimiento a eliminar.</param>
        /// <returns>Retorna confirmación de que el mantenimiento fue eliminado.</returns>
        [HttpDelete("{mantenimientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BorrarMantenimiento(int mantenimientoId)
        {
            try
            {
                _eliminarMantenimientoUC.EliminarMantenimiento(mantenimientoId);
                return Ok("Mantenimiento eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
