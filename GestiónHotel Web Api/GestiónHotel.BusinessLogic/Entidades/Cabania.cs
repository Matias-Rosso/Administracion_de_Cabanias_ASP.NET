using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotel.BusinessLogic.Entidades
{
    [Index(nameof(NumeroHabitacion), IsUnique = true)]
    public class Cabania : IValidable
    {
        [Key]
        [Required] 
        [RegularExpression("[a-zA-Z ]*")]
        public string Nombre { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 500 caracteres")]
        public string Descripcion { get; set; }

        [ForeignKey(nameof(Tipo))] public string TipoNombre { get; set; }
        public Tipo Tipo { get; set; }

        public bool PoseeJacuzzi { get; set; }

        public bool Habilitada { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroHabitacion { get; set; }

        public int MaxCupos { get; set; }
        
        public Cabania() { }
        public Cabania(string nombre, string descripcion, bool poseeJacuzzi, bool habilitada, int maxCupos)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.PoseeJacuzzi = poseeJacuzzi;
            this.Habilitada = habilitada;
            this.MaxCupos = maxCupos;
        }
        public Cabania(string nombre, string descripcion, string tipoNombre, bool poseeJacuzzi,
                    bool habilitada, int maxCupos)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TipoNombre = tipoNombre;
            this.PoseeJacuzzi = poseeJacuzzi;
            this.Habilitada = habilitada;
            this.MaxCupos = maxCupos;
        }

        public void Validar(IRepositorioConfiguracion config)
        {
            if (this.Nombre.Length == 0)
                throw new CabaniaException("El nombre no puede ser vacío.");
            else if (this.Nombre.Trim() != this.Nombre)
                throw new CabaniaException("El nombre no puede tener espacios vacíos al inicio o al final");
            if (this.Descripcion.Length != 0)
            {
                if (this.Descripcion.Length < config.ObtenerInferiorPorAtributo("DescripcionCabania") || 
                    this.Descripcion.Length > config.ObtenerSuperiorPorAtributo("DescripcionCabania"))
                    throw new CabaniaException("La descripción debe tener entre " + 
                        config.ObtenerInferiorPorAtributo("DescripcionCabania") + " y " + 
                        config.ObtenerSuperiorPorAtributo("DescripcionCabania") + " caracteres");
            }
        }

    }
}