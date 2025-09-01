using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DTOs
{
    public class UsuarioDTO
    {
        public string Email { get; set; }
        public string Clave { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario usuario)
        {
            this.Email = usuario.Email;
            this.Clave = usuario.Clave;
        }

        public UsuarioDTO(string email, string clave)
        {
            this.Email = email;
            this.Clave = clave;
        }
    }
}
