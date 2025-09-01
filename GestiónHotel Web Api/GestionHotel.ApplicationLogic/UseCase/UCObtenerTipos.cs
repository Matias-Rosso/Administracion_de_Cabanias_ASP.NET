using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.UseCase
{
    public class UCObtenerTipos : IUCObtenerTipos
    {
        private IRepositorioTipo _repositorio;

        public UCObtenerTipos(IRepositorioTipo repositorio)
        {
            _repositorio = repositorio;
        }

        public TipoDTO GetTipoPorNombre(string nombreTipo)
        {
            return new TipoDTO(_repositorio.GetByName(nombreTipo));
        }

        public IEnumerable<TipoDTO> ObtenerTipos()
        {
            return _repositorio.GetAll().Select(t => new TipoDTO(t));
        }
    }
}
