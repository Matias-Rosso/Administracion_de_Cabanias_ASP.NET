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
    public class UCEditarMantenimiento : IUCEditarMantenimiento
    {
        private IRepositorioMantenimiento _repositorio;

        public UCEditarMantenimiento(IRepositorioMantenimiento repositorio)
        {
            _repositorio = repositorio;
        }

        public MantenimientoDTO EditarMantenimiento(MantenimientoDTO mantenimientoDTO)
        {
            Mantenimiento aEditar = new Mantenimiento();
            aEditar.Id = mantenimientoDTO.Id;
            aEditar.Fecha = mantenimientoDTO.Fecha;
            aEditar.Descripcion = mantenimientoDTO.Descripcion;
            aEditar.Tecnico = mantenimientoDTO.Tecnico;
            aEditar.Costo = mantenimientoDTO.Costo;
            aEditar.CabaniaNombre = mantenimientoDTO.CabaniaNombre;

            _repositorio.Update(aEditar);
            return new MantenimientoDTO(_repositorio.GetById(mantenimientoDTO.Id));
        }
    }
}
