using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.InterfacesUseCase
{
    public interface IUCObtenerMantenimientos
    {
        public MantenimientoDTO GetMantenimientoPorId(int mantenimientoId);
        public IEnumerable<MantenimientoDTO> ObtenerMantenimientosEntreDosFechas(string nombreCabania, 
            DateTime fecha1, DateTime fecha2);
    }
}
