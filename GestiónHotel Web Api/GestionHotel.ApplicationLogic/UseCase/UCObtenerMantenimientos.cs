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
    public class UCObtenerMantenimientos : IUCObtenerMantenimientos
    {
        private IRepositorioMantenimiento _repositorio;

        public UCObtenerMantenimientos(IRepositorioMantenimiento repositorio)
        {
            _repositorio = repositorio;
        }

        public MantenimientoDTO GetMantenimientoPorId(int mantenimientoId)
        {
            return new MantenimientoDTO(_repositorio.GetById(mantenimientoId));
        }

        public IEnumerable<MantenimientoDTO> ObtenerMantenimientosEntreDosFechas(string nombreCabania, DateTime fecha1, DateTime fecha2)
        {
            return _repositorio.GetAllBetween(nombreCabania, fecha1, fecha2).Select(m => new MantenimientoDTO(m));
        }
    }
}
