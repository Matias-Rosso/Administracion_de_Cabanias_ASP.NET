using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorioCabania : IRepositorio<Cabania>
    {
        public Cabania GetByName(string nombreCabania);
        public IEnumerable<Cabania> GetAllByName(string nombreCabania);
        public IEnumerable<Cabania> GetAllByTipo(string nombreTipo);
        public IEnumerable<Cabania> GetAllByCupos(int cupos);
        public IEnumerable<Cabania> GetAllHabilitadas();
        public IEnumerable<String> GetTipoNombres();
    }
}
