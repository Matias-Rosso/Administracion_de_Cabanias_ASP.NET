using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression("[a-zA-Z0-9]*")]
        public string Clave { get; set; }

        public Usuario() { }
        public Usuario(string email, string clave)
        {
            this.Email = email;
            this.Clave = clave;
        }

        public void Validar(IRepositorioConfiguracion config)
        {
            if (this.Email.Length == 0)
                throw new UsuarioException("El email no puede ser vacío.");
            if (this.Clave.Length == 0)
            {
                throw new UsuarioException("La clave no puede ser vacía.");
            } else if (this.Clave.Length < config.ObtenerSuperiorPorAtributo("ClaveUsuario"))
                throw new UsuarioException("La clave debe tener al menos " + 
                    config.ObtenerSuperiorPorAtributo("ClaveUsuario") + " caracteres.");
            else
            {
                int contadorMayusculas = 0;
                int contadorMinusculas = 0;
                int contadorDigitos = 0;
                foreach (char c in this.Clave)
                {
                    if (char.IsUpper(c))
                    {
                        contadorMayusculas++;
                    }
                    if (char.IsLower(c))
                    {
                        contadorMinusculas++;
                    }
                    if (char.IsNumber(c))
                    {
                        contadorDigitos++;
                    }
                }
                if (!(contadorMayusculas > 0))
                {
                    throw new UsuarioException("La clave debe tener al menos una letra mayúscula");
                } 
                else if (!(contadorMinusculas > 0))
                {
                    throw new UsuarioException("La clave debe tener al menos una letra minúscula");
                }
                else if (!(contadorDigitos > 0))
                {
                    throw new UsuarioException("La clave debe tener al menos un dígito");
                }
            }
        }
    }
}
