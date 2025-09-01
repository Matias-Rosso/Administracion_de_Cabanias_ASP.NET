using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
    {
        public int ObtenerSuperiorPorAtributo(string atributo);
        public int ObtenerInferiorPorAtributo(string atributo);
    }
}
