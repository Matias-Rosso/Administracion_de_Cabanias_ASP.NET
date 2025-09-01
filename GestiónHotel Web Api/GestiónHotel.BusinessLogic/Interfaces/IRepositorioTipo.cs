using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorioTipo : IRepositorio<Tipo>
    {
        public Tipo GetByName(string nombreTipo); 
    }
}
