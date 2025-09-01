using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Excepciones
{
    public class MantenimientoException : Exception
    {
        public MantenimientoException() { }
        public MantenimientoException(string mensaje)
        : base(mensaje) { }
        public MantenimientoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
