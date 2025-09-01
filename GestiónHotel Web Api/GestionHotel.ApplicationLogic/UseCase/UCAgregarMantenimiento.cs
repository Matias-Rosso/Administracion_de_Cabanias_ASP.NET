using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.UseCase
{
    public class UCAgregarMantenimiento : IUCAgregarMantenimiento
    {
        private IRepositorioMantenimiento _repositorio;

        public UCAgregarMantenimiento(IRepositorioMantenimiento repositorio)
        {
            _repositorio = repositorio;
        }

        public MantenimientoDTO AgregarMantenimiento(MantenimientoDTO mantenimientoDTO, IRepositorioConfiguracion config)
        {
            Mantenimiento aAgregar = new Mantenimiento();
            aAgregar.Fecha = mantenimientoDTO.Fecha;
            aAgregar.Descripcion = mantenimientoDTO.Descripcion;
            aAgregar.Tecnico = mantenimientoDTO.Tecnico;
            aAgregar.Costo = mantenimientoDTO.Costo;
            aAgregar.CabaniaNombre = mantenimientoDTO.CabaniaNombre;

            _repositorio.Add(aAgregar, config);
            return new MantenimientoDTO(_repositorio.GetById(aAgregar.Id));
        }
    }
}
