using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.ApplicationLogic.UseCase;
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
    public class CabaniaController : Controller
    {
        private IRepositorioConfiguracion _config;
        private IUCAgregarCabania _agregarCabaniaUC;
        private IUCEditarCabania _editarCabaniaUC;
        private IUCEliminarCabania _eliminarCabaniaUC;
        private IUCObtenerCabanias _obtenerCabaniasUC;

        public CabaniaController(IRepositorioConfiguracion configuracion,
            IUCAgregarCabania agregarCabaniaUC,
            IUCEditarCabania editarCabaniaUC,
            IUCEliminarCabania eliminarCabaniaUC,
            IUCObtenerCabanias obtenerCabaniasUC)
        {
            this._config = configuracion;
            this._agregarCabaniaUC = agregarCabaniaUC;
            this._editarCabaniaUC = editarCabaniaUC;
            this._eliminarCabaniaUC = eliminarCabaniaUC;
            this._obtenerCabaniasUC = obtenerCabaniasUC;
        }

        /// <summary>
        /// Obtiene todos las cabañas que hay en la base de datos actualmente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetCabanias()
        {
            return Ok(_obtenerCabaniasUC.ObtenerCabanias());
        }

        /// <summary>
        /// Obtiene la cabaña con el nombre especificado
        /// </summary>
        /// <param name="cabaniaNombre">Nombre de la cabaña.</param>
        /// <returns>Retorna la cabaña especificada</returns>
        [HttpGet("{cabaniaNombre}")]
        public IActionResult GetCabania(string cabaniaNombre)
        {
            try
            {
                return Ok(_obtenerCabaniasUC.GetCabaniaPorNombre(cabaniaNombre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos las cabañas habilitadas que hay en la base de datos actualmente
        /// </summary>
        /// <returns></returns>
        [HttpGet("CabaniasHabilitadas")]
        public IActionResult GetCabaniasHabilitadas()
        {
            return Ok(_obtenerCabaniasUC.ObtenerCabaniasHabilitadas());
        }

        /// <summary>
        /// Obtiene todos las cabañas que tengan al menos los cupos especificados
        /// </summary>
        /// <param name="cupos">Cantidad de cupos.</param>
        /// <returns></returns>
        [HttpGet("PorCupos/{cupos}")]
        public IActionResult GetCabaniasPorCupos(int cupos)
        {
            return Ok(_obtenerCabaniasUC.ObtenerCabaniasPorCupos(cupos));
        }

        /// <summary>
        /// Obtiene todos las cabañas que contengan el texto especificado en el nombre
        /// </summary>
        /// <returns></returns>
        [HttpGet("PorNombre/{cabaniaNombre}")]
        public IActionResult GetCabaniasPorNombre(string cabaniaNombre)
        {
            return Ok(_obtenerCabaniasUC.ObtenerCabaniasPorNombre(cabaniaNombre));
        }

        /// <summary>
        /// Obtiene todos las cabañas del tipo especificado
        /// </summary>
        /// <param name="tipoNombre">Nombre del tipo.</param>
        /// <returns></returns>
        [HttpGet("PorTipo/{tipoNombre}")]
        public IActionResult GetCabaniasPorTipo(string tipoNombre)
        {
            return Ok(_obtenerCabaniasUC.ObtenerCabaniasPorTipo(tipoNombre));
        }

        /// <summary>
        /// Creacion de cabaña en la base de datos
        /// </summary>
        /// <param name="cabania">Cabaña completa.</param>
        /// <returns>Retorna la cabaña recién creada</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearCabania([FromBody] CabaniaDTO cabania)
        {
            try
            {
                return Created(new Uri("http://localhost:7040/Cabanias"), _agregarCabaniaUC.AgregarCabania(cabania, this._config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Actualización de cabaña en la base de datos
        /// </summary>
        /// <param name="cabania">Cabaña completa.</param>
        /// <param name="cabaniaNombre">Nombre de la cabaña a actualizar.</param>
        /// <returns>Retorna la cabaña recién editada</returns>
        [HttpPut("{cabaniaNombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarCabania([FromBody] CabaniaDTO cabania, string cabaniaNombre)
        {
            try
            {
                return Ok(_editarCabaniaUC.EditarCabania(cabania));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminación de cabaña en la base de datos
        /// </summary>
        /// <param name="cabaniaNombre">Nombre de la cabaña a eliminar.</param>
        /// <returns>Retorna confirmación de que la cabaña fue eliminada.</returns>
        [HttpDelete("{cabaniaNombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BorrarCabania(string cabaniaNombre)
        {
            try
            {
                _eliminarCabaniaUC.EliminarCabania(cabaniaNombre);
                return Ok("Cabaña eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
