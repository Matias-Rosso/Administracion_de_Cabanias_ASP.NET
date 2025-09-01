using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DTOs
{
    public class TipoDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double CostoPorHuesped { get; set; }

        public TipoDTO() { }

        public TipoDTO(Tipo tipo)
        {
            this.Nombre = tipo.Nombre;
            this.Descripcion = tipo.Descripcion;
            this.CostoPorHuesped = tipo.CostoPorHuesped;
        }
    }
}
