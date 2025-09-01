using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Excepciones
{
    public class CabaniaException : Exception
    {
        public CabaniaException() { }
        public CabaniaException(string mensaje)
        : base(mensaje) { }
        public CabaniaException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
