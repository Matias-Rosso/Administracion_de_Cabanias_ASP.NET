using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.ApplicationLogic.UseCase;
using GestionHotel.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GestionHotel.WebApi
{
    public class ManejadorJwt
    {

        public static string GenerarToken(UsuarioDTO usuario, IConfiguration configuracion)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuracion.GetSection("AppSettings:SecretTokenKey").Value!));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
