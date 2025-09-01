using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.InterfacesUseCase
{
    public interface IUCEliminarMantenimiento
    {
        public void EliminarMantenimiento(int idMantenimiento);
    }
}
