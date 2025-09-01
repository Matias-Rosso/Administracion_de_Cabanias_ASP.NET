using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Entidades
{
    public class Tipo : IValidable
    {
        [Key, Required, RegularExpression("[a-zA-Z ]*")]
        public string Nombre { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 200 caracteres")]
        public string Descripcion { get; set; }

        public double CostoPorHuesped { get; set; }

        public Tipo() { }
        public Tipo(string nombre, string descripcion, double costoPorHuesped)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.CostoPorHuesped = costoPorHuesped;
        }

        public void Validar(IRepositorioConfiguracion config)
        {
            if (this.Nombre.Length == 0)
                throw new TipoException("El nombre no puede ser vacío.");
            else if (this.Nombre.Trim() != this.Nombre)
                throw new TipoException("El nombre no puede tener espacios vacíos al inicio o al final");
            if (this.Descripcion.Length != 0)
            {
                if (this.Descripcion.Length < config.ObtenerInferiorPorAtributo("DescripcionTipo") || 
                    this.Descripcion.Length > config.ObtenerSuperiorPorAtributo("DescripcionTipo"))
                    throw new TipoException("La descripción debe tener entre " +
                        config.ObtenerInferiorPorAtributo("DescripcionTipo") + " y " +
                        config.ObtenerSuperiorPorAtributo("DescripcionTipo") + " caracteres");
            }
        }
    }
}
