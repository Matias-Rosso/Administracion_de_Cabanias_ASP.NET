using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DTOs
{
    public class CabaniaDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string TipoNombre { get; set; }

        public double TipoCostoPorHuesped { get; set; }

        public bool PoseeJacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int NumeroHabitacion { get; set; }

        public int MaxCupos { get; set; }

        public CabaniaDTO() { }
        
        public CabaniaDTO(Cabania cabania)
        {
            this.Nombre = cabania.Nombre;
            this.Descripcion = cabania.Descripcion;
            this.TipoNombre = cabania.TipoNombre;
            this.TipoCostoPorHuesped = cabania.Tipo.CostoPorHuesped;
            this.PoseeJacuzzi = cabania.PoseeJacuzzi;
            this.Habilitada = cabania.Habilitada;
            this.NumeroHabitacion = cabania.NumeroHabitacion;
            this.MaxCupos = cabania.MaxCupos;
        }
    }
}
