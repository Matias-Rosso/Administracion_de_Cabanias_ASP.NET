using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.UseCase
{
    public class UCObtenerUsuario : IUCObtenerUsuario
    {
        private IRepositorioUsuario _repositorio;

        public UCObtenerUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioDTO ObtenerUsuario(UsuarioDTO usuarioDTO)
        {

            UsuarioDTO toReturn = new UsuarioDTO(_repositorio.GetByEmail(usuarioDTO.Email));
            
            if (toReturn == null || usuarioDTO.Clave != toReturn.Clave)
            {
                throw new UsuarioException("Datos incorrectos");
            }
            return toReturn;
        }
    }
}
