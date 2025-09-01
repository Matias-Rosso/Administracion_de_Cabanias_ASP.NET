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
    public class UCEditarCabania : IUCEditarCabania
    {
        private IRepositorioCabania _repositorio;

        public UCEditarCabania(IRepositorioCabania repositorio)
        {
            _repositorio = repositorio;
        }

        public CabaniaDTO EditarCabania(CabaniaDTO cabaniaDTO)
        {
            Cabania aEditar = new Cabania();
            aEditar.Nombre = cabaniaDTO.Nombre;
            aEditar.Descripcion = cabaniaDTO.Descripcion;
            aEditar.TipoNombre = cabaniaDTO.TipoNombre;
            aEditar.PoseeJacuzzi = cabaniaDTO.PoseeJacuzzi;
            aEditar.Habilitada = cabaniaDTO.Habilitada;
            aEditar.NumeroHabitacion = cabaniaDTO.NumeroHabitacion;
            aEditar.MaxCupos = cabaniaDTO.MaxCupos;

            _repositorio.Update(aEditar);
            return new CabaniaDTO(_repositorio.GetByName(cabaniaDTO.Nombre));
        }
    }
}
