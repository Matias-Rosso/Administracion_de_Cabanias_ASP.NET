using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.InterfacesUseCase
{
    public interface IUCObtenerCabanias
    {
        public CabaniaDTO GetCabaniaPorNombre(string nombreCabania);
        public IEnumerable<CabaniaDTO> ObtenerCabanias();
        public IEnumerable<CabaniaDTO> ObtenerCabaniasHabilitadas();
        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorCupos(int cupos);
        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorNombre(string nombreCabania);
        public IEnumerable<CabaniaDTO> ObtenerCabaniasPorTipo(string nombreTipo);
    }
}
