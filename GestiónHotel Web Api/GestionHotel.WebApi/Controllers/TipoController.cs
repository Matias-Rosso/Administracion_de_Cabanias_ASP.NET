using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TipoController : Controller
    {
        private IRepositorioConfiguracion _config;
        private IUCAgregarTipo _agregarTipoUC;
        private IUCEditarTipo _editarTipoUC;
        private IUCEliminarTipo _eliminarTipoUC;
        private IUCObtenerTipos _obtenerTiposUC;

        public TipoController(IRepositorioConfiguracion configuracion,
            IUCAgregarTipo agregarTipoUC, 
            IUCEditarTipo editarTipoUC, 
            IUCEliminarTipo eliminarTipoUC, 
            IUCObtenerTipos obtenerTiposUC)
        {
            this._config = configuracion;
            this._agregarTipoUC = agregarTipoUC;
            this._editarTipoUC = editarTipoUC;
            this._eliminarTipoUC = eliminarTipoUC;
            this._obtenerTiposUC = obtenerTiposUC;
        }

        /// <summary>
        /// Obtiene todos los tipos que hay en la base de datos actualmente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetTipos()
        {
            return Ok(_obtenerTiposUC.ObtenerTipos());
        }

        /// <summary>
        /// Obtiene el tipo con el nombre especificado
        /// </summary>
        /// <param name="tipoNombre">Nombre del tipo.</param>
        /// <returns>Retorna el tipo especificado</returns>
        [HttpGet("{tipoNombre}")]
        public IActionResult GetTipo(string tipoNombre)
        {
            try
            {
                return Ok(_obtenerTiposUC.GetTipoPorNombre(tipoNombre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creacion de tipo en la base de datos
        /// </summary>
        /// <param name="tipo">Tipo completo.</param>
        /// <returns>Retorna el tipo recién creado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearTipo([FromBody] TipoDTO tipo)
        {
            try
            {
                return Created(new Uri("http://localhost:7040/Tipos"), _agregarTipoUC.AgregarTipo(tipo, this._config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Actualización de tipo en la base de datos
        /// </summary>
        /// <param name="tipo">Tipo completo.</param>
        /// <param name="tipoNombre">Nombre del tipo a actualizar.</param>
        /// <returns>Retorna el tipo recién editado</returns>
        [HttpPut("{tipoNombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarTipo([FromBody] TipoDTO tipo, string tipoNombre)
        {
            try
            {
                return Ok(_editarTipoUC.EditarTipo(tipo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminación de tipo en la base de datos
        /// </summary>
        /// <param name="tipoNombre">Nombre del tipo a eliminar.</param>
        /// <returns>Retorna confirmación de que el tipo fue eliminado.</returns>
        [HttpDelete("{tipoNombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BorrarTipo(string tipoNombre)
        {
            try
            {
                _eliminarTipoUC.EliminarTipo(tipoNombre);
                return Ok("Tipo eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
