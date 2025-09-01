using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorioMantenimiento : IRepositorio<Mantenimiento>
    {
        public Mantenimiento GetById(int id);
        public IEnumerable<Mantenimiento> GetAllBetween(string nombreCabania, DateTime fecha1, DateTime fecha2);
    }
}
