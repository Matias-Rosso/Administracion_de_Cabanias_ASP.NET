using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IValidable
    {
        public void Validar(IRepositorioConfiguracion config);
    }
}
