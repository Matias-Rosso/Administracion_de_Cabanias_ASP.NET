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
    public class UCObtenerCabanias : IUCObtenerCabanias
    {
        private IRepositorioCabania _repositorio;

        public UCObtenerCabanias(IRepositorioCabania repositorio)
        {
            _repositorio = repositorio;
        }

        public CabaniaDTO GetCabaniaPorNombre(string nombreCabania)
        {
            return new CabaniaDTO(_repositorio.GetByName(nombreCabania));
        }

        public IEnumerable<CabaniaDTO> ObtenerCabanias()
        {
            return _repositorio.GetAll().Select(c => new CabaniaDTO(c));
        }

        public IEnumerable<CabaniaDTO> ObtenerCabaniasHabilitadas()
        {
            return _repositorio.GetAllHabilitadas().Select(c => new CabaniaDTO(c));
        }

        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorCupos(int cupos)
        {
            return _repositorio.GetAllByCupos(cupos).Select(c => new CabaniaDTO(c));
        }

        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorNombre(string nombreCabania)
        {
            return _repositorio.GetAllByName(nombreCabania).Select(c => new CabaniaDTO(c));
        }

        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorTipo(string nombreTipo)
        {
            return _repositorio.GetAllByTipo(nombreTipo).Select(c => new CabaniaDTO(c));
        }
    }
}
