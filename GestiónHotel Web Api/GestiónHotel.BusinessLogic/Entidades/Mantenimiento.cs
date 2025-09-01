using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Entidades
{
    public class Mantenimiento : IValidable
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 200 caracteres")]
        public string Descripcion { get; set; }

        public string Tecnico { get; set; }

        public double Costo { get; set; }

        [ForeignKey(nameof(Cabania))] public string CabaniaNombre { get; set; }
        public Cabania CabaniaReparada { get; set; }

        public Mantenimiento() { }
        public Mantenimiento(DateTime fecha, string descripcion, string tecnico, double costo)
        {
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Tecnico = tecnico;
            this.Costo = costo;
        }

        public void Validar(IRepositorioConfiguracion config)
        {
            if (this.Descripcion.Length != 0)
            {                                                                    
                if (this.Descripcion.Length < config.ObtenerInferiorPorAtributo("DescripcionMantenimiento") || 
                    this.Descripcion.Length > config.ObtenerSuperiorPorAtributo("DescripcionMantenimiento"))
                    throw new MantenimientoException("La descripción debe tener entre " + 
                        config.ObtenerInferiorPorAtributo("DescripcionMantenimiento") + " y " + 
                        config.ObtenerSuperiorPorAtributo("DescripcionMantenimiento") + " caracteres");
            }
        }
    }
}
