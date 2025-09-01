using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DTOs
{
    public class MantenimientoDTO
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Tecnico { get; set; }

        public double Costo { get; set; }

        public string CabaniaNombre { get; set; }

        public MantenimientoDTO() { }

        public MantenimientoDTO(Mantenimiento mantenimiento)
        {
            this.Id = mantenimiento.Id;
            this.Fecha = mantenimiento.Fecha;
            this.Descripcion = mantenimiento.Descripcion;
            this.Tecnico = mantenimiento.Tecnico;
            this.Costo = mantenimiento.Costo;
            this.CabaniaNombre = mantenimiento.CabaniaNombre;
        }
    }
}
