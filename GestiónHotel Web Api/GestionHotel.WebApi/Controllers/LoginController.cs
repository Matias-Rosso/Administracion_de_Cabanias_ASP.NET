using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.ApplicationLogic.UseCase;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private ManejadorJwt ManejadorJwt;
        private IUCObtenerUsuario _obtenerUsuarioUC;        //test

        public LoginController(IConfiguration configuracion, 
            IUCObtenerUsuario obtenerUsuarioUC)
        {
            _config = configuracion;
            this.ManejadorJwt = new ManejadorJwt(/*obtenerUsuarioUC*/);
            this._obtenerUsuarioUC = obtenerUsuarioUC;      //test
        }

        /// <summary>
        /// Metodo para conseguir Token dado un usuario
        /// </summary>
        /// <param name="usuarioDTO">Credenciales de usuario que desea iniciar sesion</param>
        /// <returns>Token generado</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _obtenerUsuarioUC.ObtenerUsuario(usuarioDTO);

                var token = ManejadorJwt.GenerarToken(usuario, _config);

                return Ok(new
                {
                    Token = token,
                    Email = usuario.Email,
                    Clave = usuario.Clave
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
