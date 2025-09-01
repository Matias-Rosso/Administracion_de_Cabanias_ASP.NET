using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Excepciones
{
    public class TipoException : Exception
    {
        public TipoException() { }
        public TipoException(string mensaje)
        : base(mensaje) { }
        public TipoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
